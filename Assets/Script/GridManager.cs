using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int column = 16, row = 16;
    public GameObject tilePrefab;
    public Color colourPattern1;
    public Color colourPattern2;
    public Tile[ , ] gridRef;
    // == To Do ==
    //Fator random para spawnar tiles invalidos (buracos)

    public void SpawnGrid()
    {
        gridRef = new Tile[column, row]; //spawna coletaveis

        for(int i = 0 ; i < column ; i++)
        {
            for(int j = 0 ; j < row ; j++)
            {
                if(i % 2 == 0)
                {
                    if(j % 2 == 0)
                        InstantiatePrefab(colourPattern1, i, j);
                    else
                        InstantiatePrefab(colourPattern2, i, j);
                }
                else
                {
                    if(j % 2 == 0)
                        InstantiatePrefab(colourPattern2, i, j);
                    else
                        InstantiatePrefab(colourPattern1, i, j);
                }
            }
        }
    }

    private void InstantiatePrefab(Color color, int x, int z)
    {
        GameObject tileGameObject = Instantiate(tilePrefab, new Vector3(x, 1, z), Quaternion.identity);
        Tile tile = tileGameObject.GetComponent<Tile>( );
        tile.transform.SetParent(transform);
        gridRef[x, z] = tile;
        tile.SetPosition(x, z);
        tile.SetColor(color);
        tile.SetOriginalColor( );
    }

    public List<Tile> ValidMoviment(int column, int row)
    {
        List<Tile> tile = new List<Tile>();
        
        if(column + 1 < this.column) tile.Add(gridRef[column + 1, row]);
        if(column - 1 >= 0) tile.Add(gridRef[column - 1, row]);
        if(row + 1 < this.row) tile.Add(gridRef[column, row + 1]);
        if(row - 1 >= 0) tile.Add(gridRef[column, row - 1]);

        return tile;
    }
}