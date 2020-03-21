using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomLevelGenerator : MonoBehaviour
{

    [SerializeField] private Tilemap foregroundTilemap;
    [SerializeField] private PlacedBlocksData placedBlocksData;
    [SerializeField] private BlockPlacementSystem blockPlacementSystem;
    [Space]
    [SerializeField] private PrefabBlockData grassBlock;
    [SerializeField] private PrefabBlockData dirtBlock;
    [SerializeField] private PrefabBlockData stoneBlock;
    [SerializeField] private PrefabBlockData[] oreBlocks;

    private int height1 = 1000;
    private int height2;
    private int height3;

    // Start is called before the first frame update
    void Start()
    {
        height2 = height1;
        height3 = height2;

        for (int i = 0; i < 10000; i++)
        {
            GenerateHeight();
            GenerateXPillar(i);
        }
        //Debug.LogError("Done Generating Map");
        //blockPlacementSystem.PlaceTiles(placedBlocksData.PlacedBlocks);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void GenerateXPillar(int x)
    {
        for (int y = height2; y > 0; y--)
        {
            Vector3Int position = new Vector3Int(x, y, 0);
            PlaceTile(position);
        }
    }

    private void GenerateHeight()
    {
        height1 = height2;
        height2 = height3;
        height3 = Mathf.Clamp(height3 + Random.Range(-1, 2), 0, 2000);
        if (height1 == height3)
        {
            height2 = height1;
        }
    }

    private void PlaceTile(Vector3Int position)
    {
        if (position.y == height2)
        {
            Tile tile = grassBlock.tileVariants[0];
            placedBlocksData.PlacedBlocks[position.x, position.y] = new PlacedBlockData(foregroundTilemap, tile, position, grassBlock.blockBreakTool, grassBlock.name);
            return;
        }
        else if (position.y < height2 && position.y > height2 - 5)
        {
            Tile tile = dirtBlock.tileVariants[0];
            placedBlocksData.PlacedBlocks[position.x, position.y] = new PlacedBlockData(foregroundTilemap, tile, position, dirtBlock.blockBreakTool, dirtBlock.name);
            return;
        }
        else
        {
            Tile tile;
            foreach (var oreBlock in oreBlocks)
            {
                if (position.y < oreBlock.spawnsBelowY + Random.Range(-3, 4))
                {
                    if (Random.Range(0, 1000) < oreBlock.spawnChange * 10)
                    {
                        tile = oreBlock.tileVariants[0];
                        placedBlocksData.PlacedBlocks[position.x, position.y] = new PlacedBlockData(foregroundTilemap, tile, position, oreBlock.blockBreakTool, oreBlock.name);
                        return;
                    }
                }
            }
            tile = stoneBlock.tileVariants[0];
            placedBlocksData.PlacedBlocks[position.x, position.y] = new PlacedBlockData(foregroundTilemap, tile, position, stoneBlock.blockBreakTool, stoneBlock.name);
        }
    }
}

