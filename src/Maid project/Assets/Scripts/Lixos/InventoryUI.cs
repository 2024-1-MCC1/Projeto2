using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI ContadorText;

    void Start()
    {
        ContadorText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateContadorText(PlayerInventory playerInventory)
    {
        ContadorText.text = playerInventory.NumberOfContador.ToString();

        // Verificar se o jogador coletou 10 objetos
        if (playerInventory.NumberOfContador >= 10)
        {
            SceneManager.LoadScene("CenaDeVitoria"); // Carregar a cena de vit�ria
        }
    }
}
