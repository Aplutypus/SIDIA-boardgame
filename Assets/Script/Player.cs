using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Tile> movementTiles = new List<Tile>( );
    private List<Tile> battleTiles = new List<Tile>( );
    public GameManager gameManager;
    public TMP_Text Text_Life;
    public TMP_Text Text_Moves;
    public TMP_Text Text_Attack;

    public bool myTurn; //trocar nome depois
    public int life;
    public int attack;
    public int moves;
    public int column;
    public int row;

    public void LateUpdate( )
    {
        if(!myTurn) return;

        if(moves <= 0)
        {
            gameManager.SetTurn( );
            ResetMoves( );
        }

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
                Tile tile = hit.transform.GetComponent<Tile>( );

                if(tile != null && tile.validMovement)
                {
                    ResetValidTiles( );
                    gameManager.gridManager.gridRef[column, row].hasCharacter = false;

                    transform.position = new Vector3(tile.transform.position.x, 2, tile.transform.position.z);
                    column = tile.column;
                    row = tile.row;
                    moves--;
                    Text_Moves.text = moves.ToString( );
                    tile.hasCharacter = true;
                    SetValidTiles( );
                    SoundManager.instance.PlayMovementSound( );
                }
                else if(tile != null && tile.validBattle)
                {
                    gameManager.DiceBattle(this);
                }
            }
        }
    }

    public void SetHUDTexts(TMP_Text life, TMP_Text move, TMP_Text attack)
    {
        Text_Attack = attack;
        Text_Moves = move;
        Text_Life = life;
    }

    public void SetInitialTexts()
    {
        Text_Attack.text = attack.ToString();
        Text_Moves.text = moves.ToString( );
        Text_Life.text = life.ToString( );
    }

    public void SetValidTiles( ) //trocar nome depois
    {
        movementTiles.Clear( );
        movementTiles = gameManager.gridManager.GetValidMovement(column, row);

        foreach(var item in movementTiles)
        {
            item.validMovement = true;
            item.SetColor(Color.yellow);
        }

        battleTiles.Clear( );
        battleTiles = gameManager.gridManager.GetBattleTiles(column, row);

        foreach(var item in battleTiles)
        {
            item.validBattle = true;
            item.SetColor(Color.red);
        }
    }

    public void ResetValidTiles( )
    {
        foreach(var item in movementTiles)
        {
            item.validMovement = false;
            item.ResetColor();
        }

        foreach(var item in battleTiles)
        {
            item.validBattle = false;
            item.ResetColor( );
        }
    }

    public void ResetMoves()
    {
        moves = 3;
        Text_Moves.text = moves.ToString( );
    }

    public void SetPosition(int column, int row)
    {
        this.column = column;
        this.row = row;
    }

    public void SetGameManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }
}
