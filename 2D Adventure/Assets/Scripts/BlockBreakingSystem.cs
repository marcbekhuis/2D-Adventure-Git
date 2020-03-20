using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlockBreakingSystem : MonoBehaviour
{
    [SerializeField] private Tilemap foreGroundTilemap;
    [SerializeField] private PlacedBlocksData placedBlocks;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform raycastStartPoint;
    [SerializeField] private Transform raycastEndPoint;

    public void BreakBlock()
    {
        Vector2 heading = raycastEndPoint.position - raycastStartPoint.position;
        float distance = heading.magnitude;
        Vector2 direction = heading / distance;

        RaycastHit2D raycastHit2D = Physics2D.Raycast(raycastStartPoint.position, direction, distance: 3, layerMask: layerMask);
        if (raycastHit2D)
        {
            Vector3Int position = foreGroundTilemap.WorldToCell(raycastHit2D.point + new Vector2(0.1f,0.1f) * direction);
            foreGroundTilemap.SetTile(position, null);
            placedBlocks.PlacedBlocks[position.x, position.y] = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector2 heading = raycastEndPoint.position - raycastStartPoint.position;
        float distance = heading.magnitude;
        Vector2 direction = heading / distance;
        Gizmos.DrawRay(raycastStartPoint.position, direction);
    }
}
