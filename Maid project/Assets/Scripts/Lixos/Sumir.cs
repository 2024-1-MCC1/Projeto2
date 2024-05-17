using UnityEngine;
using System.Collections;

public class PositionLerp : MonoBehaviour
{
    public float distanceThreshold = 5.0f;
    public Vector3 destinationPosition = new Vector3(10000f, 1000f, 0f);
    public float velocity = 5.0f;
    private bool move = false;
    public Vector3 initialPosition = new Vector3(0f, 0f, 0f);
    public float delayBeforeDisappear = 1.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Move playerMoveScript = FindObjectOfType<Move>();
            if (playerMoveScript != null)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, playerMoveScript.transform.position);
                if (distanceToPlayer <= distanceThreshold)
                {
                    StartCoroutine(StartMovementWithDelay());
                }
            }
        }

        if (!move)
            return;

        transform.position = Vector3.Lerp(
            initialPosition,
            destinationPosition,
            velocity * Time.deltaTime
        );
    }

    IEnumerator StartMovementWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeDisappear);
        move = true;
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        // Notifica o PlayerInventory sobre a coleta do objeto
        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.IncrementContador();

            // Atualiza o contador de itens na UI
            InventoryUI inventoryUI = FindObjectOfType<InventoryUI>();
            if (inventoryUI != null)
            {
                inventoryUI.UpdateContadorText(playerInventory);
            }
            else
            {
                Debug.LogWarning("InventoryUI not found.");
            }
        }
        else
        {
            Debug.LogWarning("PlayerInventory not found.");
        }
    }

}