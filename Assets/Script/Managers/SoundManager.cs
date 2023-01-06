using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource collectableSound;
    public AudioSource diceSound;
    public AudioSource endGameSound;
    public AudioSource changeTurnSound;
    public AudioSource movementSound;
    public AudioSource menuButtonSound;

    private void Awake( )
    {
        instance = this;
    }

    public void PlayMenuButtonSound()
    {
        menuButtonSound.Stop( );
        menuButtonSound.Play( );
    }

    public void PlayMovementSound()
    {
        movementSound.Stop( );
        movementSound.Play( );
    }

    public void PlayChangeTurnSound()
    {
        changeTurnSound.Stop( );
        changeTurnSound.Play( );
    }

    public void PlayEndGameSound()
    {
        endGameSound.Stop( );
        endGameSound.Play( );
    }

    public void PlayDiceSound()
    {
        diceSound.Stop( );
        diceSound.Play( );
    }

    public void PlayCollectableSound( )
    {
        collectableSound.Stop( );
        collectableSound.Play( );
    }
}
