using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ce script g�re les param�tres globaux du jeu, tels que le volume de la musique, le volume des sons, le mode plein �cran, 
/// et la r�solution de l'�cran. Il permet de centraliser et d'ajuster ces param�tres depuis diff�rentes parties du jeu.
/// </summary>
public class SettingsManager : MonoBehaviour
{
    /// <summary>
    /// Instance statique du SettingsManager. Assure qu'il y a une seule instance dans toute l'application (Singleton Pattern).
    /// </summary>
    public static SettingsManager Instance { get; private set; }

    [SerializeField] private float musicVolume = 1f;
    [SerializeField] private float soundVolume = 1f;
    [SerializeField] private bool isFullScreen = true;
    [SerializeField] private int resolutionIndex = 0;
    [SerializeField] private AudioSource audioSourceMusic;
    [SerializeField] private List<AudioSource> audioSourceSounds = new List<AudioSource>();

    public float MusicVolume
    {
        get { return musicVolume; }
        set { musicVolume = value; }
    }
    public float SoundVolume
    {
        get { return soundVolume; }
        set { soundVolume = value; }
    }

    public bool IsFullScreen
    {
        get { return isFullScreen; }
        set { isFullScreen = value; }
    }

    public int ResolutionIndex
    {
        get { return resolutionIndex; }
        set { resolutionIndex = value; }
    }

    public AudioSource MusicSource
    {
        get { return audioSourceMusic; }
        set { audioSourceMusic = value; }
    }
    public List<AudioSource> SoundsSource
    {
        get { return audioSourceSounds; }
        set { audioSourceSounds = value; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
