using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    public Vector2Int cellPosition;
    public bool isCornerCell;
    public bool isEdgeCell;

    public ConnectionTypes northConnection, southConnection, westConnection, eastConnection;
    public Transform northPoint, southPoint, westPoint, eastPoint;

    public Dictionary<Direction, ConnectionTypes> connections = new Dictionary<Direction, ConnectionTypes>();
    public Dictionary<Direction, Transform> directionPoints = new Dictionary<Direction, Transform>();

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

        directionPoints = new()
        {
            { Direction.North, northPoint},
            { Direction.South, southPoint},
            { Direction.West, westPoint},
            { Direction.East, eastPoint}
        };
    }

    public void UpdateCell(Vector2Int position = default, bool isCorner = false, bool isEdge = false)
    {
        if (position != default)
            cellPosition = position;

        isCornerCell = isCorner;
        isEdgeCell = isEdge;
    }

    public void UpdateCellFaces()
    {

    }
}
public enum ConnectionTypes
{
    Corridor,
    Wall,
    Doorway
}
