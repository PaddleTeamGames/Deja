using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static Animator animator;

    private static string levelToLoad;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Starts loading a specific Scene
    /// </summary>
    public static void ChangeScene(string name)
    {
        FirstPersonMovement.LockPlayerMovement();
        SaveGame.AutoSave();
        levelToLoad = name;
        animator.SetTrigger("fadeOut");
    }

    /// <summary>
    /// Reloads current Scene
    /// </summary>
    public static void Retry()
    {
        ChangeScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Loads the scene once the fade is complete
    /// </summary>
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}