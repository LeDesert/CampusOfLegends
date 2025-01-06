using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// G�re la lecture et la transition des pistes audio dans une playlist.
/// Permet la lecture continue et al�atoire de pistes, tout en s'assurant qu'une piste ne se r�p�te pas imm�diatement.
/// Impl�mente un singleton pour garantir qu'il n'y ait qu'une seule instance active de AudioManager.
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    public AudioClip[] playlist;
    public AudioSource audioPlayer;
    public int musicPlayedIndex;

    private void Start()
    {
        // S�lection d'une piste al�atoire au d�marrage
        musicPlayedIndex = Random.Range(0, playlist.Length);
        audioPlayer.clip = playlist[musicPlayedIndex];
        audioPlayer.Play();
    }

    private void Update()
    {
        // V�rifie si la piste actuelle est termin�e, puis joue une autre piste
        if (!audioPlayer.isPlaying)
        {
            PlayNextRandomTrack();
        }
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

    private void PlayNextRandomTrack()
    {
        int newIndex;

        do
        {
            // S�lectionne une nouvelle piste al�atoire, diff�rente de l'actuelle
            newIndex = Random.Range(0, playlist.Length);
        }
        while (newIndex == musicPlayedIndex);

        // Met � jour l'index et joue la nouvelle piste
        musicPlayedIndex = newIndex;
        audioPlayer.clip = playlist[musicPlayedIndex];
        audioPlayer.Play();
    }
}
