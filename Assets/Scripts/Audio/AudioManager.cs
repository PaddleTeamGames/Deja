using System;
using UnityEngine;

// Manages all audio in the game and is kept between scenes
public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public Sound[] sounds;

    private float musicLenght, musicTimer;
    private bool musicPlaylist = false;

    void Awake()
    {
        ManageScript();

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    /// <summary>
    /// Keeps this object and stops it from duplicating
    /// </summary>
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

    /// <summary>
    /// Plays an audio clip
    /// </summary>
    /// <param name="name"></param>
    /// <param name="isPlaylist"></param>
    public void Play(string name, bool isPlaylist = false)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "was not found");
            return;
        }

        if (s.loop)
        {
           StopMusic(); // Stops previous track
           if(isPlaylist) EnablePlaylist(s);
        }

        s.source.pitch = Time.timeScale;

        s.source.Play();
    }

    private void EnablePlaylist(Sound s)
    {
        musicPlaylist = true;
        musicLenght = s.clip.length;
        musicTimer = 0;
    }

    /// <summary>
    /// Stops an audio clip
    /// </summary>
    /// <param name="name"></param>
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
        musicPlaylist = false;
    }

    private void StopMusic()
    {
        Sound[] s = Array.FindAll(sounds, sound => sound.loop == true);
        for (int i = 0; i < s.Length; i++) { s[i].source.Stop(); }
        musicPlaylist = false;
    }

    /// <summary>
    /// Stops all active sounds
    /// </summary>
    public void StopAll()
    {
        foreach (Sound s in sounds)
        {
            if (s.source.isActiveAndEnabled == true)
            {
                s.source.Stop();
            }
        }
    }

    private void Update()
    {
        if (musicPlaylist == true) MusicPlaylistHandler();
    }

    private void MusicPlaylistHandler()
    {
        musicTimer += Time.deltaTime;

        if (musicTimer > musicLenght)
        {
            musicTimer = 0;
            PlaylistHandler.instance.StartPlaylist();
        }
    }

}