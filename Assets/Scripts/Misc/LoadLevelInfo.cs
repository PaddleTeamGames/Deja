using UnityEngine;
using TMPro;

// Loads the name of the current level
public class LoadLevelInfo : MonoBehaviour
{
    private const string BASE_PATH = "text/levels/";

    private const int LEVEL_NAME_LINE = 0;

    [SerializeField] private TextMeshProUGUI levelName;

    private void Start()
    {
        string finalPath = BASE_PATH + LocalizationHandler.CurrentLanguage() + "/" + LevelHandler.currentLevel.ToString();
        levelName.text = ResourcesHandler.GetLine(finalPath, LEVEL_NAME_LINE);
    }

}