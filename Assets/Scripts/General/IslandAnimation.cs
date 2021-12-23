using UnityEngine;

// Handles the island animation, if the Player is on an island the animation pauses
public class IslandAnimation : MonoBehaviour
{
    private Animator animator;

    private float originalSpeed;

    void Start()
    {
        animator = GetComponent<Animator>();
        originalSpeed = animator.speed;
    }

    private void Pause()
    {
        animator.speed = 0;
    }

    private void Resume()
    {
        animator.speed = originalSpeed;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player") Pause();
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player") Resume();
    }

}