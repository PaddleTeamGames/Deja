using UnityEngine;

[RequireComponent(typeof(Collider))]
public class InteractionReceiver : MonoBehaviour
{
    public void Activate()
    {
        gameObject.GetComponent<IAction>().Activate();
    }
}