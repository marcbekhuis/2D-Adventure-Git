using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New PrefabBlockData", menuName = "ScriptableObjects/PrefabBlockData")]
public class PrefabBlockData : ScriptableObject
{
    public string blockName = "None";
    public Tile[] tileVariants;
    [Space]
    public int spawnsBelowY = 0;
    public float spawnChange = 0;
}
