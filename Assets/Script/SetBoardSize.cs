using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBoardSize : MonoBehaviour
{
    public BoardSizeScriptable boardSizeScriptable;

    public void SetRow(int value)
    {
        boardSizeScriptable.row = value;
    }
    public void SetColumn(int value)
    {
        boardSizeScriptable.column = value;
    }
}
