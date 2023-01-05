using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // == Variáveis ==
    public int column = 16, row = 16;
    // == GameObjects ==
    public GameObject tilePrefab1;
    public GameObject tilePrefab2;
    public GameObject tileInvalid;
    public GameObject[ , ] gridRef; //referencia para spawn de coletaveis

    // == To Do ==
    //Fator random para spawnar tiles invalidos (buracos)
    //Adicionar modificação no tamanho do tabuleiro (valores column e row)


    public void SpawnGrid()
    {
        gridRef = new GameObject[column, row]; //spawna coletaveis

        for(int i = 0 ; i < column ; i++)
        {
            for(int j = 0 ; j < row ; j++)
            {
                if(i % 2 == 0)
                {
                    if(j % 2 == 0)
                        InstantiatePrefab(tilePrefab1, i, j);
                    else
                        InstantiatePrefab(tilePrefab2, i, j);
                }
                else
                {
                    if(j % 2 == 0)
                        InstantiatePrefab(tilePrefab2, i, j);
                    else
                        InstantiatePrefab(tilePrefab1, i, j);
                }
            }
        }
    }

    private void InstantiatePrefab(GameObject tilePrefab, int x, int z)
    {
        GameObject tile = Instantiate(tilePrefab, new Vector3(x, 1, z), Quaternion.identity);
        tile.transform.SetParent(transform);
        gridRef[x, z] = tile;
        tile.GetComponent<Tile>( ).SetPosition(x, z);
    }
}