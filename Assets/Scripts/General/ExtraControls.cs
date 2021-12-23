using UnityEngine;
using UnityEngine.InputSystem;

public class ExtraControls : MonoBehaviour
{
    private InputSystem playerInput;

    private void Awake()
    {
        playerInput = new InputSystem();
        playerInput.Player.Enable();

        playerInput.Player.Restart.performed += Restart;
        playerInput.Player.Skip.performed += Skip;
        playerInput.Player.Pause.performed += Pause;
    }

    void Restart(InputAction.CallbackContext context)
    {
        ExitHandler.RestartLevel();
    }
    void Skip(InputAction.CallbackContext context)
    {
        ExitHandler.AdvanceToNextRoom();
    }
    void Pause(InputAction.CallbackContext context)
    {
        SceneLoader.ChangeScene(GameHandler.FIRST_SCENE);
    }
}