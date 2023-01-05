using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Referencia dos outros codigos para iniciar o jogo
    public GridManager gridManager;
    public CollectableManager collectableManager;
    public Player player;
    private List<Player> playerList = new List<Player>();

    private void Awake()
    {
        StartGame();
    }

    public void StartGame()
    {
        gridManager.SpawnGrid( );
        SpawnPlayer( );
        collectableManager.SpawnCollectables(playerList[0], playerList[1]);
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
        playerList.Add(p1);
        Player p2 = Instantiate(player, new Vector3(p2Column, 2, p2Row), Quaternion.identity);
        p2.SetPosition(p2Column, p2Row);
        playerList.Add(p2);
    }
}
