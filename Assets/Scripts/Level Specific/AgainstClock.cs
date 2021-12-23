using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// UNUSED AT THE MOMENT

//Handles the level in which the player must beat in a certain amount of time
public class AgainstClock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private const float TARGET_TIME = 15f;

    private float timeLeft;

    private void Start()
    {
        AudioManager.instance.Play("Hurry Music", true);
    }

    private void Update()
    {
        TimerHandler();
        Timeover();
    }

    /// <summary>
    /// Handles the timer the player has to finish the level and updates the UI text for it
    /// </summary>
    private void TimerHandler()
    {
        timeLeft = TARGET_TIME - LevelHandler.levelTimer;
        timerText.text = timeLeft.ToString();
    }

    /// <summary>
    /// If the time runs out, the level restarts
    /// </summary>
    private void Timeover()
    {
        if (timeLeft < 0) ExitHandler.RestartLevel();
    }

}