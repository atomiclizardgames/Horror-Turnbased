using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int gridWidth = 10;
    public int gridHeight = 10;
    public float cellSize = 1f;
    public LayerMask obstacleLayer;

    public Vector3 GetWorldPosition(Vector3Int gridPosition)
    {
        return new Vector3((gridPosition.x * cellSize), 0, (gridPosition.z * cellSize));
    }

    public Vector3Int GetGridPosition(Vector3 worldPosition)
    {
        int x = Mathf.RoundToInt(worldPosition.x / cellSize);
        int z = Mathf.RoundToInt(worldPosition.z / cellSize);
        return new Vector3Int(x, 0, z);
    }

    public bool IsTileWalkable(Vector3Int gridPosition)
    {
        // Check for obstacles using a sphere cast at the grid position
        Vector3 worldPosition = GetWorldPosition(gridPosition);
        return !Physics.CheckSphere(worldPosition, cellSize/ 2f, obstacleLayer);
    }
}
