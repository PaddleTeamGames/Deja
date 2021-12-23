using UnityEngine;

// If object goes out of bounds, the level is automatically restarted
public class OutOfBounds : MonoBehaviour
{
    private bool outOfBounds = false;

    void Update()
    {
        if (gameObject.transform.position.y <= GameHandler.OUT_OF_BOUNDS_Y && !outOfBounds) 
        {
            outOfBounds = true;
            ExitHandler.RestartLevel(); 
        }
    }
}