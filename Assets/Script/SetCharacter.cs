using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharacter : MonoBehaviour
{
    public CharacterScriptable characterScriptable;
    public Color characterColor;

    public void SetCharacterName(string name)
    {
        characterScriptable.characterName = name;
        characterScriptable.color = characterColor;
    }

    public void SetLife(int value)
    {
        characterScriptable.life = value;
    }

    public void SetMoves(int value)
    {
        characterScriptable.moves = value;
    }

    public void SetAttack(int value)
    {
        characterScriptable.attack = value;
    }
}
