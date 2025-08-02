using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public GameObject gridPointPrefab;
    public LineRendererControlScript controller;

    public int rows = 3;
    public int cols = 3;
    public float spacing = 1.5f;

    void Start()
    {
        Transform[,] pointGrid = new Transform[rows, cols];

        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < cols; y++)
            {
                Vector3 pos = new Vector3(x * spacing, y * spacing, 0);
                GameObject point = Instantiate(gridPointPrefab, pos, Quaternion.identity, transform);

                GridPoint gp = point.GetComponent<GridPoint>();
                gp.gridIndex = new Vector2Int(x, y);
                gp.controller = controller;

                pointGrid[x, y] = point.transform;
            }
        }

        controller.rows = rows;
        controller.cols = cols;
        controller.pointGrid = pointGrid;
    }
}
