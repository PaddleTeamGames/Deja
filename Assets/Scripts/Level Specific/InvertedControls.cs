using UnityEngine;

//Inverts the Player controls during a specific level
public class InvertedControls : MonoBehaviour
{
    void Start()
    {
        FirstPersonMovement.invertedControls = true;
    }
}