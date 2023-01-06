using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GridManager gridManager;
    public GameHUD gameHUD;
    public CollectableManager collectableManager;
    public Player playerPrefab;
    private List<Player> playerList = new List<Player>();
    private int turn;
    private bool gameEnd = false;

    private void Awake()
    {
        StartGame();
    }

    private void Start()
    {
        SoundManager.instance.PlayChangeTurnSound( );
    }

    private void LateUpdate()
    {
        if(gameEnd) return;

        foreach(var item in playerList)
        {
            if(item.life <= 0)
            {
                gameHUD.OpenEndGame( );
                SoundManager.instance.PlayEndGameSound( );
                gameEnd = true;
            }
        }
    }

    public void SetTurn(bool playAudio = true)
    {
        playerList[turn].myTurn = false;
        playerList[turn].ResetValidTiles( );
        turn++;
        if(turn >= playerList.Count) turn = 0;
        playerList[turn].myTurn = true;
        playerList[turn].SetValidTiles();
        if (playAudio) SoundManager.instance.PlayChangeTurnSound( );
    }

    public void StartGame()
    {
        gridManager.SpawnGrid( );
        SpawnPlayer( );
        collectableManager.SpawnCollectables(playerList[0], playerList[1]);
        turn = playerList.Count - 1;
        SetTurn(false);
    }

    public void SpawnPlayer( )
    {
        int dividedColumn = gridManager.column / 2;
        int p1Column = UnityEngine.Random.Range(0, dividedColumn);
        int p1Row = UnityEngine.Random.Range(0, gridManager.row);
        int p2Column = UnityEngine.Random.Range(dividedColumn, gridManager.column);
        int p2Row = UnityEngine.Random.Range(0, gridManager.row);
        
        Player p1 = Instantiate(playerPrefab, new Vector3(p1Column, 2, p1Row), Quaternion.identity);
        p1.gameObject.name = "Player 1";
        gameHUD.SetPlayer1NameText(p1.gameObject.name);
        p1.SetPosition(p1Column, p1Row);
        p1.SetGameManager(this);
        p1.ResetMoves( );
        p1.life = 5;  // subject to change
        playerList.Add(p1);
        gridManager.gridRef[p1Column, p1Row].hasCharacter = true;
        
        Player p2 = Instantiate(playerPrefab, new Vector3(p2Column, 2, p2Row), Quaternion.identity);
        p2.gameObject.name = "Player 2";
        gameHUD.SetPlayer2NameText(p2.gameObject.name);
        p2.SetPosition(p2Column, p2Row);
        p2.SetGameManager(this);
        p2.ResetMoves( );
        p2.life = 5;  // subject to change
        playerList.Add(p2);
        gridManager.gridRef[p2Column, p2Row].hasCharacter = true;
    }

    public void DiceBattle(Player currentPlayer)
    {
        Player enemy = playerList.Find(item => item != currentPlayer);
        int[ ] currentPlayerDice = GetRandomDice( );
        int[ ] enemyDice = GetRandomDice( );

        gameHUD.SetRightDice(currentPlayerDice);
        gameHUD.SetRightHUDText(currentPlayer.name);
        gameHUD.SetLeftDice(enemyDice);
        gameHUD.SetLeftHUDText(enemy.name);
        gameHUD.OpenBattleHUD( );
        SoundManager.instance.PlayDiceSound( );
        int currentPlayerPoint = 0;
        int enemyPoint = 0;

        for(int i = 0 ; i < 3 ; i++)
        {
            if(currentPlayerDice[i] >= enemyDice[i])
            {
                currentPlayerPoint++;
            }
            else
                enemyPoint++;
        }

        if(currentPlayerPoint >= 2)
        {
            enemy.life -= currentPlayer.attack;
            gameHUD.SetTurnWinnerText(currentPlayer.name + " won the turn!");
        }

        if(enemyPoint >= 2)
        {
            currentPlayer.life -= enemy.attack;
            gameHUD.SetTurnWinnerText(enemy.name + " won the turn!");
        }

        if(currentPlayer.life <= 0)
            gameHUD.SetEndPanelWinnerText(currentPlayer.name + "\n has been defeated!");
        if(enemy.life <= 0)
            gameHUD.SetEndPanelWinnerText(enemy.name + "\n has been defeated!");

        SetTurn( );
    }

    public int[ ] GetRandomDice()
    {
        int[ ] dice = new int[3];

        dice[0] = UnityEngine.Random.Range(1, 7);
        dice[1] = UnityEngine.Random.Range(1, 7);
        dice[2] = UnityEngine.Random.Range(1, 7);

        Array.Sort(dice);

        return dice;
    }
}
