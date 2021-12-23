using UnityEngine;

// Handles which tutorial to load
public class TutorialManager : MonoBehaviour
{
    private static TutorialGenerator tutorialGen;
    private static Animator animator;

    public static string[] tutorialOrder = { "move", "jump", "interact", "restart" };

    private void Start()
    {
        tutorialGen = GetComponent<TutorialGenerator>();
        animator = GetComponent<Animator>();
    }

    public static void StartTutorial(int ID)
    {
        tutorialGen.LoadTutorial(ID);
        animator.SetBool("enabled", true);
    }

    public static void FinishTutorial()
    {
        animator.SetBool("enabled", false);
    }

    public static void LeverTutorial()
    {
        if (LevelHandler.currentLevel == LevelHandler.STARTING_LEVEL) FinishTutorial();
        if (LevelHandler.currentLevel == LevelHandler.TRICKY_LEVER_LEVEL) StartTutorial(System.Array.IndexOf(tutorialOrder, "restart"));
    }

}