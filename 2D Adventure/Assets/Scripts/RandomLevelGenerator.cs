using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomLevelGenerator : MonoBehaviour
{

    [SerializeField] private Tilemap foregroundTilemap;
    [SerializeField] private PlacedBlocksData placedBlocksData;
    [Space]
    [SerializeField] private PrefabBlockData grassBlock;
    [SerializeField] private PrefabBlockData dirtBlock;
    [SerializeField] private PrefabBlockData stoneBlock;
    [SerializeField] private PrefabBlockData[] oreBlocks;

    private int height = 1000;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 4700; i < 5300; i++)
        {
            GenerateHeight();
            GenerateXPillar(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void GenerateXPillar(int x)
    {
        for (int y = height; y > 0; y--)
        {
            Vector3Int position = new Vector3Int(x, y, 0);
            PlaceTile(position);
        }
    }

    private void GenerateHeight()
    {
        height = Mathf.Clamp(height + Random.Range(-1, 2), 0, 2000);
    }

    private void PlaceTile(Vector3Int position)
    {
        if (position.y == height)
        {
            Tile tile = grassBlock.tileVariants[0];
            foregroundTilemap.SetTile(position, tile);
            placedBlocksData.PlacedBlocks[position.x, position.y] = new PlacedBlockData(foregroundTilemap, tile, position, grassBlock.name);
            return;
        }
        else if (position.y < height && position.y > height - 5)
        {
            Tile tile = dirtBlock.tileVariants[0];
            foregroundTilemap.SetTile(position, tile);
            placedBlocksData.PlacedBlocks[position.x, position.y] = new PlacedBlockData(foregroundTilemap, tile, position, dirtBlock.name);
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
                        foregroundTilemap.SetTile(position, tile);
                        placedBlocksData.PlacedBlocks[position.x, position.y] = new PlacedBlockData(foregroundTilemap, tile, position, oreBlock.name);
                        return;
                    }
                }
            }
            tile = stoneBlock.tileVariants[0];
            foregroundTilemap.SetTile(position, tile);
            placedBlocksData.PlacedBlocks[position.x, position.y] = new PlacedBlockData(foregroundTilemap, tile, position, stoneBlock.name);
        }
    }
}

