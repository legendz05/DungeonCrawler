using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    public Vector2Int cellPosition;
    public bool isCornerCell;

    public TileConnection northConnection, southConnection, westConnection, eastConnection;

    public Dictionary<Direction, TileConnection> connections = new Dictionary<Direction, TileConnection>();

    public void InitiliazeCell(Vector2Int position)
    {
        cellPosition = position;

        connections = new()
        {
            { Direction.North, northConnection},
            { Direction.South, southConnection},
            { Direction.West, westConnection},
            { Direction.East, eastConnection}
        };
    }

    public void UpdateCell(Vector2Int position = default, bool isCorner = false)
    {
        if (position != default)
            cellPosition = position;

        isCornerCell = isCorner;
    }
}
public enum TileConnection
{
    Corridor,
    Wall,
    Doorway
}
