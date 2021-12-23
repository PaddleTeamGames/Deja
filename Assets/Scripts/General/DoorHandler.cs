using UnityEngine;

// Manages the exit door which usually ends the level
public class DoorHandler : MonoBehaviour
{
    private static Animator animator;

    private static bool doorLocked=false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Unlocks or locks the door
    /// </summary>
    public static void DoorStatus(bool locked)
    {
        doorLocked = locked;
        DoorAnimation();
    }

    /// <summary>
    /// Plays the respective animation of the door unlocking or locking
    /// </summary>
    public static void DoorAnimation()
    {
        animator.SetBool("doorLocked", doorLocked);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!doorLocked) 
            {
                ExitHandler.AdvanceToNextRoom();
            }
        }
    }
}