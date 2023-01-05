using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Tile> listTile = new List<Tile>();
    public GridManager gridManager;

    public bool myTurn; //trocar nome depois
    public int life;
    public int attack;
    public int moves;
    public int column;
    public int row;

    public void Update()
    {
        if(!myTurn) return;

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100))
            {
                Tile tile = hit.transform.GetComponent<Tile>( );

                if(tile != null && tile.validTile)
                {
                    ResetValidTiles( );
                    gridManager.gridRef[column, row].hasCharacter = false;

                    transform.position = new Vector3(tile.transform.position.x, 2, tile.transform.position.z);
                    column = tile.column;
                    row = tile.row;
                    tile.hasCharacter = true;
                    SetValidTiles( );
                }
            }
        }
    }

    public void SetValidTiles() //trocar nome depois
    {
        listTile.Clear( );
        listTile = gridManager.ValidMoviment(column, row);
        foreach(var item in listTile)
        {
            item.validTile = true;
            item.SetColor(Color.yellow);
        }
    }

    public void ResetValidTiles() //trocar nome depois
    {
        foreach(var item in listTile)
        {
            item.validTile = false;
            item.ResetColor();
        }
    }

    public void SetPosition(int column, int row)
    {
        this.column = column;
        this.row = row;
    }

    public void SetGridManager(GridManager gridManager)
    {
        this.gridManager = gridManager;
    }
}
