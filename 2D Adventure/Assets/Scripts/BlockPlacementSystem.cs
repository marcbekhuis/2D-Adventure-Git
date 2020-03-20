using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlacementSystem : MonoBehaviour
{
    public void PlaceTiles(PlacedBlockData[,] placedBlocksData)
    {
        foreach (var placedBlockData in placedBlocksData)
        {
            if (placedBlockData != null)
            {
                placedBlockData.placedOnTilemap.SetTile(placedBlockData.position, placedBlockData.tile);
            }
        }
    }
}
