using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private int[] mysteryValue = new int[] { -1, 2 };
    public int quantity;
    public bool mystery;

    public bool attack;
    public bool life;
    public bool moves;

    private void Start()
    {
        SortMysteryStats( );
    }

    public void OnTriggerEnter(Collider other)
    {
        SoundManager.instance.PlayCollectableSound( );
        Player player = other.GetComponent<Player>( );

        if(attack) player.attack += quantity;
        else if(life) player.life += quantity;
        else if(moves) player.moves += quantity;

        Destroy(this.gameObject);
    }

    public void SortMysteryStats( )
    {
        if(mystery)
        {
            int sortType = Random.Range(0, 3);
            int sortValue = Random.Range(0, mysteryValue.Length);
            quantity = mysteryValue[sortValue];

            switch(sortType)
            {
                case 0:
                    attack = true;
                    break;

                case 1:
                    life = true;
                    break;

                case 2:
                    moves = true;
                    break;

                default:
                    life = true;
                    break;
            }
        }
    }
}
