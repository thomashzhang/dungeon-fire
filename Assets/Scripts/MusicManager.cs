using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void StartMusic()
    {
        audioSource.Play();
    }
}
