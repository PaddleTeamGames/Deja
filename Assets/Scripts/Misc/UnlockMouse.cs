using UnityEngine;

// Makes it so the Player can move the mouse around the menu after being in FPS mode
public class UnlockMouse : MonoBehaviour
{
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}