using UnityEngine;

// Handles the final screen of the game, like the Stats
public class FinalHandler : MonoBehaviour
{
    [SerializeField] private GameObject winScreen, statsScreen, creditsScreen;

    private bool statsEnabled = false, creditsEnabled=false;

    private void Start()
    {
        Stats.timesGameFinished++;
        Stats.BestTimeHandler();
        LevelHandler.NewGameSettings();
        AudioManager.instance.StopAll();
    }

    private void ContinueButton()
    {
        SceneLoader.ChangeScene("Start");
    }

    private void StatsScreen()
    {
        statsEnabled = !statsEnabled;

        winScreen.SetActive(!statsEnabled);
        statsScreen.SetActive(statsEnabled);
    }

    private void CreditsScreen()
    {
        creditsEnabled = !creditsEnabled;

        statsScreen.SetActive(!creditsEnabled);
        creditsScreen.SetActive(creditsEnabled);
    }

    public void FinalButton()
    {
        AudioManager.instance.Play("click");

        if (!statsEnabled)
        {
            StatsScreen();
        }
        else if (!creditsEnabled)
        {
            CreditsScreen();
        }
        else
        {
            ContinueButton();
        }
    }

}