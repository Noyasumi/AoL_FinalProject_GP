using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Sound
{
    public string name;
    public AudioClip source;
    public bool loop;

    [Range(0f, 1f)]
    public float volume;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private Sound[] audios;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        PlayMusic("Game Audio");
    }

    public void PlayMusic(string name)
    {
        Sound music = Array.Find(audios, sound => sound.name == name);
        if (music != null)
        {
            musicSource.clip = music.source;
            musicSource.volume = music.volume;
            musicSource.loop = music.loop;
            musicSource.Play();
        }
    }
    public void StopAllMusic()
    {
        musicSource.Stop();
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }
}
