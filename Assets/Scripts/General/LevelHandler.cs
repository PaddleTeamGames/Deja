using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private GameObject levelObjects;

    public const int STARTING_LEVEL = 1, TRICKY_LEVER_LEVEL = 3;
    public const float START_TIME = 7, TIME_ADD = 24/GameHandler.NUMBER_OF_LEVELS;

    public static float timeOfDay = START_TIME;

    public static int currentLevel = STARTING_LEVEL;
    public static float levelTimer = 0;

    private void Start()
    {
        ResetSettings();
        LoadLevelObjects();
        AreThereUnlockers();
    }

    private void Update(){ if(FirstPersonMovement.playerHasMoved) levelTimer += Time.deltaTime; }

    public static void AdvanceToNext()
    {
        if (currentLevel != GameHandler.NUMBER_OF_LEVELS)
        {
            currentLevel++;
            SceneLoader.Retry();
        }
        else
        {
            GameHandler.GameFinished();
        }
    }

    public static void NewGameSettings()
    {
        currentLevel = STARTING_LEVEL;
    }

    private void ResetSettings()
    {
        if (currentLevel == STARTING_LEVEL) GameHandler.ResetRunTimer();
        levelTimer = 0;
        timeOfDay = START_TIME + (TIME_ADD * currentLevel);
    }

    /// <summary>
    /// Loads the objects of the current level by reading the name of the parent object on the editor
    /// </summary>
    private void LoadLevelObjects()
    {
        levelObjects.transform.Find(currentLevel.ToString()).gameObject.SetActive(true);
    }

    /// <summary>
    /// Looks through objects to see if there are any with the tag Unlocker
    /// </summary>
    private static void AreThereUnlockers() // Could be improved if it just looked through the specific levels game objects
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Unlocker");
        if (gameObjects.Length == 0) { DoorHandler.DoorStatus(false);} else { DoorHandler.DoorStatus(true); }
    }

}