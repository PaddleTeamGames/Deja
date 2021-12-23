using UnityEngine;

//Makes the whole game run faster during a specific level
public class FastLevel : MonoBehaviour
{
    private const float SPEED_VALUE = 3;

    void Start()
    {
        GameSpeedHandler.ChangeSpeed(SPEED_VALUE);
        PlaylistHandler.instance.StartPlaylist();
    }
}