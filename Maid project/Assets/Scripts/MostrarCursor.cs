using UnityEngine;

public class MostrarCursor : MonoBehaviour
{
    void Start()
    {
        // Torna o cursor do mouse vis�vel
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
