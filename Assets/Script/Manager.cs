using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Manager : MonoBehaviour
{
//Chamando atributos
    //vida p1
    //ataque p1
    //vida p2
    //ataque p2

//Chamando outros c�digos
    //public c�digo nome;
    //public c�digo nome;
    //public c�digo nome;

//Chamando GameObjects
    //public GameObject nome;
    //public c�digo nome;
    //public c�digo nome;

    private void Start()
    {
        //Time scale redundante para usar slowmo ou pause
        Time.timeScale = 1;

        //spawnar personagens nos pontos definidos
    }
    private void Update()
    {
        if(Time.timeScale == 0)
        {
            //Eventos quando o jogo � pausado ou chega ao fim
        }
    }

    //verifica��o de pontua��o de batalha
    //verifica��o de vencedor

    /*void Score()
    {
        if(p1.points > p2.points)
        {
            gameOverScreen.SetGameOverScreen(p1.points, p2.points, "Player 1 wins!");
        }
        else if(p2.points > p1.points)
        {
            gameOverScreen.SetGameOverScreen(p1.points, p2.points, "Player 2 wins!");
        }
        else
        {
            gameOverScreen.SetGameOverScreen(p1.points, p2.points, "It's a draw");
        }
    }*/
}
