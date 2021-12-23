using UnityEngine;

//Locks certain keys during a specific level
public class NoForward : MonoBehaviour
{
    void Start()
    {
        FirstPersonMovement.forwardDisabled = true;
    }

    /// <summary>
    /// When the Player pushes the lever on the level this switches the keys that are disabled
    /// </summary>
    public static void LockedKeySwitch()
    {
        FirstPersonMovement.forwardDisabled = false;
        FirstPersonMovement.restDisabled = true;
    }
}