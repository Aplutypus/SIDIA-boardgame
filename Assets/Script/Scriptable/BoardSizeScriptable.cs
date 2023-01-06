using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoardSize", menuName = "ScriptableObjects/Create Board Size")]
public class BoardSizeScriptable : ScriptableObject
{
    public int row;
    public int column;
}
