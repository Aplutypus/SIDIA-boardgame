using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame( )
    {
        SceneManager.LoadScene(1);
    }

    public void NewMatch( )
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame( ) //adicionar um quit para web, para fazer uma versão do itch.io
    {
        #if UNITY_STANDALONE
            Application.Quit( );
        #endif

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
