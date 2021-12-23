using UnityEngine;

public class ExitHandler : MonoBehaviour
{
    private static bool activated;

    private void Start()
    {
        activated = false;
    }

    /// <summary>
    /// Advances the player to the next level usually after the current one is won
    /// </summary>
    public static void AdvanceToNextRoom()
    {
        if (!activated)
        {
            activated = true;
            AudioManager.instance.Play("Teleport");
            LevelHandler.AdvanceToNext();
        }
    }

    /// <summary>
    /// Restarts the current level
    /// </summary>
    public static void RestartLevel()
    {
        if (!activated)
        {
            activated = true;
            AudioManager.instance.Play("Teleport");
            Stats.timesRestarted++;
            SceneLoader.Retry();
        }
    }

}