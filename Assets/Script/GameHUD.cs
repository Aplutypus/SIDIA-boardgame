using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameHUD : MonoBehaviour
{
    public GameObject battleHUD;
    public GameObject panelEndGame;
    public TMP_Text endPanelWinnerText;
    public TMP_Text winnerText;
    public TMP_Text p1Life;
    public TMP_Text p1Moves;
    public TMP_Text p1Attack;
    public TMP_Text p2Life;
    public TMP_Text p2Moves;
    public TMP_Text p2Attack;
    public TMP_Text p1BattleName;
    public TMP_Text p2BattleName;
    public TMP_Text p1HUDName;
    public TMP_Text p2HUDName;
    public Image[ ] diceHudP1;
    public Image[ ] diceHudP2;
    public Sprite[ ] diceImages;

    public void OpenBattleHUD()
    {
        battleHUD.SetActive(true);
    }

    public void OpenEndGame()
    {
        panelEndGame.SetActive(true);
    }

    public void SetRightDice(int[ ] sortedDice)
    {
        for(int i = 0 ; i < diceHudP1.Length ; i++)
        {
            diceHudP1[i].sprite = diceImages[sortedDice[i] - 1];
        }
    }

    public void SetLeftDice(int[ ] sortedDice)
    {
        for(int i = 0 ; i < diceHudP1.Length ; i++)
        {
            diceHudP2[i].sprite = diceImages[sortedDice[i] - 1];
        }
    }
    public void SetEndPanelWinnerText(string text)
    {
        endPanelWinnerText.text = text;
    }

    public void SetTurnWinnerText(string text)
    {
        winnerText.text = text;
    }

    public void SetPlayer1NameText(string text)
    {
        p1HUDName.text = text;
    }

    public void SetPlayer2NameText(string text)
    {
        p2HUDName.text = text;
    }

    public void SetRightHUDText(string text)
    {
        p1BattleName.text = text;
    }

    public void SetLeftHUDText(string text)
    {
        p2BattleName.text = text;
    }
}
