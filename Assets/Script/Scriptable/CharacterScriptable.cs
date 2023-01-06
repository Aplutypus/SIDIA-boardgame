using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Create Character")]
public class CharacterScriptable : ScriptableObject
{
    public string characterName;
    public int life;
    public int moves;
    public int attack;
    public Color color;
}
