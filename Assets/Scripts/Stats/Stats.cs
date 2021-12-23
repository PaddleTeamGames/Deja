using UnityEngine;

//Keeps track of all of the game's stats
public class Stats : MonoBehaviour
{
    public const float DEFAULT_BEST_TIME = 600;

    public static int timesJumped, leversPushed, timesRestarted, timesGameFinished;
    public static float bestTime=DEFAULT_BEST_TIME;

    /// <summary>
    /// Records the best time between runs
    /// </summary>
    public static void BestTimeHandler()
    {
        if (GameHandler.runTimer < bestTime || bestTime == 0) bestTime = GameHandler.runTimer;
    }
}