using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public const string FIRST_SCENE = "Start", GAME_SCENE = "Main";

    public const int NUMBER_OF_LEVELS = 10;

    public const float OUT_OF_BOUNDS_Y = -10;

    public static GameHandler instance;

    public static float runTimer; // Keeps track of the current run
    public static float gameTimer; // Keeps track of ALL runs

    public static ControlMethod controlMethod = ControlMethod.MouseKeyboard;

    private void Update()
    {
        Timers();
        Debug.Log(controlMethod);
    }

    private void Timers()
    {
        runTimer += Time.deltaTime;
        gameTimer += Time.deltaTime;
    }

    public static void ResetRunTimer()
    {
        runTimer = 0;
    }

    public static void GameFinished()
    {
        LevelHandler.NewGameSettings();
        SceneLoader.ChangeScene("Final");
    }

}