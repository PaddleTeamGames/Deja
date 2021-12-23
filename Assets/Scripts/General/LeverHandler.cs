using UnityEngine;

public class LeverHandler : MonoBehaviour, IAction
{
    private const string UNLOCKER_TAG = "Unlocker", LOCKER_TAG = "Locker";

    private Animator animator;

    private bool activated=false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// When the player interacts with the lever this is called by the Interface
    /// </summary>
    public void Activate()
    {
        if (!activated)
        {
            LeverActivated();
            DoorStatusHandler();
        }
    }

    /// <summary>
    /// Changes the lever's status since it can only by pushed once per level
    /// </summary>
    private void LeverActivated()
    {
        activated = true;
        animator.SetBool("leverActive", activated);

        AudioManager.instance.Play("Lever");
        Stats.leversPushed++;

        OtherFunctions();
    }

    private void OtherFunctions()
    {
        TutorialManager.LeverTutorial();
        if (FirstPersonMovement.forwardDisabled) NoForward.LockedKeySwitch();
    }


    /// <summary>
    /// Depending on the lever tag either locks or unlocks the exit door
    /// </summary>
    private void DoorStatusHandler()
    {
        if (gameObject.tag == UNLOCKER_TAG)
        {
            DoorHandler.DoorStatus(!activated);
        }
        else if (gameObject.tag == LOCKER_TAG)
        {
            DoorHandler.DoorStatus(activated);
        }
    }

}