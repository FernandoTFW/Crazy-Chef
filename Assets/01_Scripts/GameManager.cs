using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource sfxAS;
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void PlaySFX(AudioClip sfx)
    {
        sfxAS.PlayOneShot(sfx);
    }
}
