using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class visaoEnemy : MonoBehaviour
{
    [SerializeField]
    public LayerMask layerMask;
    public float alcanceDaVisao = 10f; //distancia que o inimigo consegue te ver

    // Update is called once per frame
    void Update()
    {
        //Aqui faz com que o jogo mude para a tela de Game Over caso você entre no campo de visão do inimigo
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, alcanceDaVisao, layerMask))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
