using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public List<Collectable> Collectables = new List<Collectable>();
    public GridManager GridManager;

    public void SpawnCollectables(Player p1, Player p2)
    {
        for(int i = 0 ; i < GridManager.gridRef.GetLength(0) ; i++)
        {
            for(int j = 0 ; j < GridManager.gridRef.GetLength(1) ; j++)
            {
                if(p1.column == i && p1.row == j)
                    continue;
                if(p2.column == i && p2.row == j)
                    continue;

                int randomCollectable = UnityEngine.Random.Range(0, Collectables.Count);
                Tile tile = GridManager.gridRef[i, j]; //corrige possição de spawn de acordo com o tabuleiro
                Collectable collectable = Instantiate(Collectables[randomCollectable], new Vector3(tile.transform.position.x, 2, tile.transform.position.z), Quaternion.identity);
                collectable.transform.SetParent(transform);

                //if(tile.validTile) dont
            }
        }
    }
}
