using UnityEngine;

//Makes the player jump constantly during a specific level
public class NonStopJump : MonoBehaviour
{
    void Start()
    {
        FirstPersonMovement.alwaysJump = true;
    }
}