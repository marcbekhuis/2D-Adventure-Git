using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlockPlacementSystem : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float loadDistanceX = 40;
    [SerializeField] private float loadDistanceY = 20;
    [SerializeField] private PlacedBlocksData placedBlocksData;
    [SerializeField] private Tilemap tilemap;

    private Vector3 previeusPlayerPos = new Vector3(0,0,0);

    public void PlaceTiles(PlacedBlockData[,] placedBlocksData)
    {
        foreach (var placedBlockData in placedBlocksData)
        {
            if (placedBlockData != null)
            {
                placedBlockData.placedOnTilemap.SetTile(placedBlockData.position, placedBlockData.tile);
                placedBlockData.loaded = true;
            }
        }
    }

    public void PlaceTiles()
    {
        if (player.position != previeusPlayerPos)
        {
            Vector3 playerLocGrid = tilemap.WorldToCell(player.position);
            int minY = Mathf.Clamp(Mathf.RoundToInt(playerLocGrid.y - loadDistanceY), 0, 2000);
            int maxY = Mathf.Clamp(Mathf.RoundToInt(playerLocGrid.y + loadDistanceY), 0, 2000);
            int minX = Mathf.Clamp(Mathf.RoundToInt(playerLocGrid.x - loadDistanceX), 0, 10000);
            int maxX = Mathf.Clamp(Mathf.RoundToInt(playerLocGrid.x + loadDistanceX), 0, 10000);
            //Debug.Log("MinY: " + minY + " MaxY: " + maxY + " MinX: " + minX + " MaxX: " + maxX);


            for (int y = minY; y < maxY; y++)
            {
                for (int x = minX; x < maxX; x++)
                {
                    if (placedBlocksData.PlacedBlocks[x, y] != null)
                    {
                        if (!placedBlocksData.PlacedBlocks[x, y].loaded)
                        {
                            placedBlocksData.PlacedBlocks[x, y].placedOnTilemap.SetTile(placedBlocksData.PlacedBlocks[x, y].position, placedBlocksData.PlacedBlocks[x, y].tile);
                            placedBlocksData.PlacedBlocks[x, y].loaded = true;
                        }
                    }
                }
            }
        }
    }

    private void Update()
    {
        PlaceTiles();
    }
}
