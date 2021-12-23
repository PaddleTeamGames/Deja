using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour {

    void Start () {
        DetermineSaveOrLoad();
	}

    /// <summary>
    /// Depending on the loaded scene this script determines if the game is going to be saved or loaded
    /// </summary>
    private void DetermineSaveOrLoad()
    {
        if (SceneManager.GetActiveScene().name == GameHandler.FIRST_SCENE)
        {
            AutoLoad();
        }
        else
        {
            AutoSave();
        }
    }

    /// <summary>
    /// Automatically saves the game at certain points
    /// </summary>
    public static void AutoSave()
    {
        PlayerPrefs.SetInt("Level", LevelHandler.currentLevel);

        PlayerPrefs.SetInt("Jumps", Stats.timesJumped);
        PlayerPrefs.SetInt("Levers", Stats.leversPushed);
        PlayerPrefs.SetInt("Restarts", Stats.timesRestarted);
        PlayerPrefs.SetInt("Finished", Stats.timesGameFinished);

        PlayerPrefs.SetFloat("Run Timer", GameHandler.runTimer);
        PlayerPrefs.SetFloat("Total Timer", GameHandler.gameTimer);
        PlayerPrefs.SetFloat("Best", Stats.bestTime);
    }

    /// <summary>
    /// Automatically loads the game at certain points
    /// </summary>
    public void AutoLoad()
    {
        LevelHandler.currentLevel = PlayerPrefs.GetInt("Level", LevelHandler.STARTING_LEVEL);

        Stats.timesJumped = PlayerPrefs.GetInt("Jumps", 0);
        Stats.leversPushed = PlayerPrefs.GetInt("Levers", 0);
        Stats.timesRestarted = PlayerPrefs.GetInt("Restarts", 0);
        Stats.timesGameFinished = PlayerPrefs.GetInt("Finished", 0);

        GameHandler.runTimer = PlayerPrefs.GetFloat("Run Timer", 0);
        GameHandler.gameTimer = PlayerPrefs.GetFloat("Total Timer", 0);
        Stats.bestTime = PlayerPrefs.GetFloat("Best", Stats.DEFAULT_BEST_TIME);
    }

    /// <summary>
    /// Deletes the save file if the Player choses to do so
    /// </summary>
    public static void ResetSave()
    {
        PlayerPrefs.SetInt("Level", LevelHandler.STARTING_LEVEL);
        PlayerPrefs.SetFloat("Run Timer", 0);

        Debug.Log("Game Reset");

        LevelHandler.NewGameSettings();
    }

}