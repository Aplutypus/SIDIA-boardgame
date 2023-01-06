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
    public void Settings( )
    {
        //m�sica
        //VFX
        //Resolu��o da tela
    }

    public void NewMatch( )
    {
        //Resetar placar
        //Resetar perfis
        //desativar painel
        SceneManager.LoadScene(0);
    }

    public void QuitGame( ) //adicionar um quit para web, para fazer uma vers�o do itch.io
    {
        #if UNITY_STANDALONE
            Application.Quit( );
        #endif

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
