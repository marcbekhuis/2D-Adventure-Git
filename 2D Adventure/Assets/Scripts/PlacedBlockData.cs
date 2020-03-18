using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class PlacedBlockData
{
    public string blockName = "None";
    public Tilemap placedOnTilemap;
    public Tile tile;
    public Vector3Int position;
    public Quaternion rotation;
}
