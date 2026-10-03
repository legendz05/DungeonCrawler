using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public static DungeonGenerator Instance;

    [SerializeField] int dungeonSizeX, dungeonSizeY;
    private const int cellSize = 10;

    public GameObject tileTest;

    Dictionary<Vector2Int, GridCell> cells = new();

    private static readonly Dictionary<Direction, Vector2Int> dirToVector = new Dictionary<Direction, Vector2Int>
    {
        {Direction.North, Vector2Int.up },
        {Direction.South, Vector2Int.down },
        {Direction.East, Vector2Int.right },
        {Direction.West, Vector2Int.left }
    };

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateGrid();
            return;
        }
    }

    private void ClearDungeon()
    {
        foreach (GridCell cell in cells.Values)
        {
            Destroy(cell.gameObject);
        }

        cells.Clear();
    }

    private void GenerateGrid()
    {
        ClearDungeon();

        for (int column = 0; column < dungeonSizeY; column++)
        {
            for (int row = 0; row < dungeonSizeX; row++)
            {
                GenerateCell(new Vector2Int(row, column), cellSize);
            }
        }
    }

    private void GenerateCell(Vector2Int position, float cellSize)
    {
        Vector3 worldPos = new Vector3(position.x * cellSize, 0f, position.y * cellSize);

        GameObject newTile = Instantiate(tileTest, worldPos, Quaternion.identity);

        GridCell newCell = newTile.GetComponent<GridCell>();
        newCell.InitiliazeCell(position);
        newCell.UpdateCell(isCorner: IsCellACorner(newCell), isEdge: IsCellAnEdge(newCell));
        cells.Add(position, newCell);
    }

    public GridCell GetCellToDirection(GridCell inputCell, Direction direction)
    {
        Vector2Int outputCellPosition = inputCell.cellPosition + dirToVector[direction];

        return GetCellAtPosition(outputCellPosition);
    }

    public GridCell GetCellAtPosition(Vector2Int position)
    {
        cells.TryGetValue(position, out GridCell cell);

        return cell;
    }

    public bool IsCellACorner(GridCell cell)
    {
        if (cell.cellPosition.x == 0 && (cell.cellPosition.y == 0 || cell.cellPosition.y == dungeonSizeY - 1))
        {
            return true;
        }
        else if (cell.cellPosition.x == dungeonSizeX - 1 && (cell.cellPosition.y == 0 || cell.cellPosition.y == dungeonSizeY - 1))
        {
            return true;
        }

        return false;
    }

    public bool IsCellAnEdge(GridCell cell)
    {
        if ((cell.cellPosition.x == 0 || cell.cellPosition.x == dungeonSizeX - 1 || cell.cellPosition.y == 0 || cell.cellPosition.y == dungeonSizeY - 1) && !IsCellACorner(cell))
        {
            return true;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        for (int column = 0; column < dungeonSizeY; column++)
        {
            for (int row = 0; row < dungeonSizeX; row++)
            {
                Vector3 cubeCenter = new Vector3(row * cellSize + cellSize / 2f, 0f, column * cellSize + cellSize / 2f);
                Gizmos.DrawWireCube(cubeCenter, new Vector3(cellSize, 0.1f, cellSize));
            }
        }
    }
}

public enum Direction
{
    North,
    South,
    West,
    East
}
