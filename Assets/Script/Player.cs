using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life;
    public int attack;
    public int moves;
    public int column;
    public int row;

    public void SetPosition(int column, int row)
    {
        this.column = column;
        this.row = row;
    }



}
