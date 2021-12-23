using UnityEngine;
using UnityEngine.InputSystem;

public class InputDetector : MonoBehaviour
{
    public static void OnJoin(InputAction.CallbackContext ctx)
    {
        if (ctx.control.device is Keyboard || ctx.control.device is Mouse)
        {
            GameHandler.controlMethod = ControlMethod.MouseKeyboard;
        }
        else if (ctx.control.device is Gamepad)
        {
            GameHandler.controlMethod = ControlMethod.Controller;
        }
    }

}