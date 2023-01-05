using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int column, row;
    public bool validTile = false;
    private Color originalColor;

    public void SetOriginalColor()
    {
        originalColor = GetComponent<Renderer>( ).material.color;
    }

    public void SetPosition(int column, int row)
    {
        this.column = column;
        this.row = row;
    }

    public void SetColor(Color color)
    {
        GetComponent<Renderer>( ).material.color = color;
    }

    public void ResetColor()
    {
        GetComponent<Renderer>( ).material.color = originalColor;
    }
}
