using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource collectableSound;

    private void Awake( )
    {
        instance = this;
    }

    public void PlayCollectableSound( )
    {
        collectableSound.Stop( );
        collectableSound.Play( );
    }
}
