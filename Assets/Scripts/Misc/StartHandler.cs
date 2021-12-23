using UnityEngine;

// Handles the first screen of the game
public class StartHandler : MonoBehaviour
{
    private InputSystem inputSystem;

    private void Awake()
    {
        inputSystem = new InputSystem();
        inputSystem.Player.Disable();
        inputSystem.Menu.Enable();
    }

    private void Start()
    {
        VolumeSlider.GetVolume();
        AudioManager.instance.Play("Menu");
    }

    private void Update()
    {
        inputSystem.Menu.Interact.started += InputDetector.OnJoin;
    }

    public void StartButton()
    {
        CommonButton();
        PlaylistHandler.instance.StartPlaylist();
        SceneLoader.ChangeScene("Main");
    }

    public void ResetButton() { CommonButton(); SaveGame.ResetSave(); }

    public static void CloseGame()
    {
        CommonButton();
        SaveGame.AutoSave();
        Application.Quit();
    }

    private static void CommonButton()
    {
        AudioManager.instance.Play("click");
    }

    private void OnDestroy()
    {
        inputSystem.Menu.Disable();
    }
}