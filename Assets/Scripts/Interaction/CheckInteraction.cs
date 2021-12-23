using UnityEngine;
using UnityEngine.InputSystem;

//Handles the Player interactions with the levers or other objects
public class CheckInteraction : MonoBehaviour
{
    private const float MIN_INTERACTION_DIST=3;

    private InputSystem playerInput;
   
    [SerializeField] private GameObject rayOrigin;
    private InteractionReceiver currentReceiver;

    private Ray ray;
    private RaycastHit hit;

    private void Awake()
    {
        playerInput = new InputSystem();
        playerInput.Player.Enable();

        playerInput.Player.Interact.performed += Interact;
    }

    void Interact(InputAction.CallbackContext context)
    {
        if (CheckRaycast()) currentReceiver.Activate();
    }

    /// <summary>
    /// Checks the distance from the player to the object to see if the interaction is possible
    /// </summary>
    private bool CheckRaycast()
    {
        ray = new Ray(rayOrigin.transform.position, rayOrigin.transform.forward);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.distance < MIN_INTERACTION_DIST)
            {
                currentReceiver = hit.transform.gameObject.GetComponent<InteractionReceiver>();

                if (currentReceiver != null)
                {
                    return true;
                   
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        return false;
    }

}