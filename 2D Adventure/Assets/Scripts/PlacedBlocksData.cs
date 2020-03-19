using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedBlocksData : MonoBehaviour
{
    public PlacedBlockData[,] PlacedBlocks = new PlacedBlockData[10000, 2000];
}

public enum BlockBreakTool
{
    Hand,
    Axe,
    PickAxe,
    Sword,
    Shovel
}
