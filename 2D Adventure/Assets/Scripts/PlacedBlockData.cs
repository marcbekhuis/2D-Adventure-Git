using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class PlacedBlockData
{
    public string blockName;
    public Tilemap placedOnTilemap;
    public Tile tile;
    public Vector3Int position;
    public Quaternion rotation;

    public PlacedBlockData(Tilemap PlacedOnTilemap, Tile tile, Vector3Int Position, Quaternion Rotation, string BlockName = "None")
    {
        placedOnTilemap = PlacedOnTilemap;
        this.tile = tile;
        position = Position;
        rotation = Rotation;
        blockName = BlockName;
    }

    public PlacedBlockData(Tilemap PlacedOnTilemap, Tile tile, Vector3Int Position, string BlockName = "None")
    {
        placedOnTilemap = PlacedOnTilemap;
        this.tile = tile;
        position = Position;
        rotation = Quaternion.Euler(0,0,0);
        blockName = BlockName;
    }
}
