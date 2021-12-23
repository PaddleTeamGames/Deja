using UnityEngine;

public class GameSpeedHandler : MonoBehaviour
{
    private void Awake()
    {
        ResetToNormal();
    }

    /// <summary>
    /// Resets the game speed to normal
    /// </summary>
    public static void ResetToNormal()
    {
        Time.timeScale = 1;
    }

    /// <summary>
    /// Changes the game speed to a certain amount
    /// </summary>
    public static void ChangeSpeed(float value)
    {
        Time.timeScale = value;
    }
}