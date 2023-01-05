using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GridManager gridManager;
    public CollectableManager collectableManager;
    public Player player;
    private List<Player> playerList = new List<Player>();
    private int turn;

    private void Awake()
    {
        StartGame();
    }

    public void SetTurn()
    {
        playerList[turn].myTurn = false;
        playerList[turn].ResetValidTiles( );
        turn++;
        if(turn >= playerList.Count) turn = 0;
        playerList[turn].myTurn = true;
        playerList[turn].SetValidTiles();
    }

    public void StartGame()
    {
        turn = playerList.Count;
        gridManager.SpawnGrid( );
        SpawnPlayer( );
        collectableManager.SpawnCollectables(playerList[0], playerList[1]);
        SetTurn( );
    }

    public void SpawnPlayer( )
    {
        int dividedColumn = gridManager.column / 2;
        int p1Column = Random.Range(0, dividedColumn);
        int p1Row = Random.Range(0, gridManager.row);
        int p2Column = Random.Range(dividedColumn, gridManager.column);
        int p2Row = Random.Range(0, gridManager.row);
        
        Player p1 = Instantiate(player, new Vector3(p1Column, 2, p1Row), Quaternion.identity);
        p1.SetPosition(p1Column, p1Row);
        p1.SetGridManager(gridManager);
        playerList.Add(p1);
        
        Player p2 = Instantiate(player, new Vector3(p2Column, 2, p2Row), Quaternion.identity);
        p2.SetPosition(p2Column, p2Row);
        p2.SetGridManager(gridManager);
        playerList.Add(p2);
    }
}
