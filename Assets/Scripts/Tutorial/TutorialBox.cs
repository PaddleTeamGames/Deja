using UnityEngine;

public class TutorialBox : MonoBehaviour
{
    public int tutorialID;
    public bool tutorialStart;

    /// <summary>
    /// Triggers the respective tutorial when the player collides with this invisible object
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (tutorialStart == true)
        {
            TutorialManager.StartTutorial(tutorialID);
        }
        else
        {
            TutorialManager.FinishTutorial();
        }
    }
}