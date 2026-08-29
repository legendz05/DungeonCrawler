using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    [SerializeField] int dungeonSizeX, dungeonSizeY;
    private const int cellSize = 10;

    public GameObject tileTest;

    List<GameObject> tilesList = new List<GameObject>();

    void Start()
    {

    }

    // Update is called once per frame
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
        foreach (GameObject tile in tilesList)
        {
            Destroy(tile);
        }

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
        tilesList.Add(newTile);
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
