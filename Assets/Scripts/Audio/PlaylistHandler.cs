using System.Collections.Generic;
using UnityEngine;

//Manages the music playlist that plays during the game
public class PlaylistHandler : MonoBehaviour
{
    private const int NUMBER_OF_TRACKS = 7;

    private readonly List<int> possibleTracks = new List<int>();

    public static PlaylistHandler instance;

    private AudioManager audioManager;

    void Awake()
    {
        audioManager = GetComponent<AudioManager>();
        ManageScript();
    }

    private void ManageScript()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


    private void InitializeList()
    {
        for (int i = 0; i < NUMBER_OF_TRACKS; i++)
        {
            possibleTracks.Add(i);
        }
    }

    /// <summary>
    /// Starts the playlist with priority for songs that have not been played yet
    /// </summary>
    public void StartPlaylist()
    {
        if (possibleTracks.Count <= 0) InitializeList();
        int random = Random.Range(0, possibleTracks.Count);

        audioManager.Play(possibleTracks[random].ToString(), true);
        possibleTracks.RemoveAt(random);
    }

}