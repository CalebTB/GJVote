using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicPlaylist : MonoBehaviour
{

    public AudioClip[] clips;
    private AudioSource audioSource;
    [SerializeField] private TextMeshProUGUI currentSongPlaying;

    #region Music


    void Start() {
        audioSource = FindObjectOfType<AudioSource>();
        audioSource.loop = false;

    }

    private AudioClip GetRandomClip() {
        return clips[Random.Range(0,clips.Length)];
    }

    void Update() {
        if(!audioSource.isPlaying) {
            audioSource.clip = GetRandomClip();
            audioSource.Play();
            currentSongPlaying.text = "Song Playing: " + audioSource.clip.name;
            // Debug.Log("Song Playing: " + audioSource.clip.name.ToString());
        }
    }

    #endregion
}
