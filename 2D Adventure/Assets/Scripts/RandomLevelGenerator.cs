using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomLevelGenerator : MonoBehaviour
{

    [SerializeField] private Tilemap foregroundTilemap;
    [Space]
    [SerializeField] private PrefabBlockData grassBlock;
    [SerializeField] private PrefabBlockData dirtBlock;
    [SerializeField] private PrefabBlockData stoneBlock;
    [SerializeField] private PrefabBlockData[] oreBlocks;

    private int height = 1000;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = -300; i < 300; i++)
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
        height = Mathf.Clamp(height + Random.Range(-1, 2),0 , 2000);
    } 

    private void PlaceTile(Vector3Int position)
    {
        if (position.y == height)
        {
            foregroundTilemap.SetTile(position, grassBlock.tileVariants[0]);
            return;
        }
        else if (position.y < height && position.y > height - 5)
        {
            foregroundTilemap.SetTile(position, dirtBlock.tileVariants[0]);
            return;
        }
        else
        {
            foreach (var oreBlock in oreBlocks)
            {
                if(position.y < oreBlock.spawnsBelowY + Random.Range(-3,4))
                {
                    if (Random.Range(0,1000) < oreBlock.spawnChange * 10)
                    {
                        foregroundTilemap.SetTile(position, oreBlock.tileVariants[0]);
                        return;
                    }
                }
            }
            foregroundTilemap.SetTile(position, stoneBlock.tileVariants[0]);
        }
    }
}
