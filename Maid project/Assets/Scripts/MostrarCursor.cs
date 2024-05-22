using UnityEngine;

public class MostrarCursor : MonoBehaviour
{
    void Start()
    {
        //Esse código serve para as telas de game over e tela de vitória
        // Torna o cursor do mouse vis�vel
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
