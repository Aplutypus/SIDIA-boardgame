using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // == Menu Principal ==
    public void StartGame() //PRONTO
    {
        SceneManager.LoadScene(1);
    }
    public void Settings() //nada por enquanto
    {
        //música
        //VFX
        //Resolução da tela
    }
    public void NewMatch() //Por enquanto volta ao menu. Falta Placar, perfis e desativar paineis
    {
        //Resetar placar
        //Resetar perfis
        //desativar painel
        SceneManager.LoadScene(0);
    }
    public void QuitGame() //PRONTO
    {
        #if UNITY_STANDALONE
            Application.Quit( ); //quit exe
        #endif

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; //quit unity editor
        #endif
    }
}
