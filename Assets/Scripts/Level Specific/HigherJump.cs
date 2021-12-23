using UnityEngine;

//Makes the player jump much higher during a specific level
public class HigherJump : MonoBehaviour
{
    private const float HIGHER_JUMP_VALUE = 10f;

    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonMovement>().JumpBoosted(HIGHER_JUMP_VALUE);
    }
}