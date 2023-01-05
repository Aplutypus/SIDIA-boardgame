using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int column, row;
    public bool validTile;
    
    public void SetPosition(int column, int row)
    {
        this.column = column;
        this.row = row;
    }
}
