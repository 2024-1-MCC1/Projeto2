using UnityEngine;

public class MostrarCursor : MonoBehaviour
{
    void Start()
    {
        // Torna o cursor do mouse visível
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
