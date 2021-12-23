using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Handles the text and images necessary for the tutorial
public class TutorialGenerator : MonoBehaviour
{
    private const string BASE_PATH = "text/misc/";
    private const string TUTORIAL_PATH = "/tutorial";

    private const string PATH_IMAGE_MK = "image/tutorial/mk/";
    private const string PATH_IMAGE_CONTROLLER = "image/tutorial/controller/";

    [SerializeField] private Image tutorialIcon;
    [SerializeField] private TextMeshProUGUI tutorialText;

    public void LoadTutorial(int id)
    {
        string finalPath = BASE_PATH + LocalizationHandler.CurrentLanguage() + TUTORIAL_PATH;
        tutorialText.text = ResourcesHandler.GetLine(finalPath,id);
        IconManager(id);
    }

    /// <summary>
    /// Depending on the control method it loads the correct image for the button
    /// </summary>
    private void IconManager(int id)
    {
        string path;
        switch (GameHandler.controlMethod)
        {
            case ControlMethod.MouseKeyboard:
                path = PATH_IMAGE_MK;
                break;
            case ControlMethod.Controller:
                path = PATH_IMAGE_CONTROLLER;
                break;
            default:
                path = PATH_IMAGE_MK;
                break;
        }
        tutorialIcon.sprite = ResourcesHandler.GetSprite(path + TutorialManager.tutorialOrder[id].ToString());
    }

}