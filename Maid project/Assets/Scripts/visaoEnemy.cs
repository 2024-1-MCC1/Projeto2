using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class visaoEnemy : MonoBehaviour
{
    [SerializeField]
    public LayerMask layerMask;
    public float alcanceDaVisao = 10f;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, alcanceDaVisao, layerMask))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
