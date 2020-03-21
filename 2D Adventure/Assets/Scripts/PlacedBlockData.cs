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
    public BlockBreakTool blockBreakTool;
    public bool loaded;

    public PlacedBlockData(Tilemap PlacedOnTilemap, Tile tile, Vector3Int Position, Quaternion Rotation, BlockBreakTool blockBreakTool, string BlockName = "None", bool Loaded = false)
    {
        placedOnTilemap = PlacedOnTilemap;
        this.tile = tile;
        position = Position;
        rotation = Rotation;
        blockName = BlockName;
        this.blockBreakTool = blockBreakTool;
        loaded = Loaded;
    }

    public PlacedBlockData(Tilemap PlacedOnTilemap, Tile tile, Vector3Int Position, BlockBreakTool blockBreakTool, string BlockName = "None", bool Loaded = false)
    {
        placedOnTilemap = PlacedOnTilemap;
        this.tile = tile;
        position = Position;
        rotation = Quaternion.Euler(0,0,0);
        blockName = BlockName;
        this.blockBreakTool = blockBreakTool;
        loaded = Loaded;
    }
}
