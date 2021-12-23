using UnityEngine;
using TMPro;

public class StatsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timesJumped, leversPushed, timesRestarted, gamesFinished, runTime, bestTime, totalTime;

    private void Start()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        if (timesJumped != null) timesJumped.text = Stats.timesJumped.ToString();
        if (leversPushed != null) leversPushed.text = Stats.leversPushed.ToString();
        if (timesRestarted != null) timesRestarted.text = Stats.timesRestarted.ToString();
        if (gamesFinished != null) gamesFinished.text = Stats.timesGameFinished.ToString();
        if (runTime != null) runTime.text = TimeConverter.MinutesSeconds(GameHandler.runTimer).ToString();
        if (bestTime != null) bestTime.text = TimeConverter.MinutesSeconds(Stats.bestTime).ToString();
        if (totalTime != null) totalTime.text =  TimeConverter.HoursMinutes(GameHandler.gameTimer).ToString();
    }

}