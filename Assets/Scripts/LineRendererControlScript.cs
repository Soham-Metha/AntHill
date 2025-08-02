using System.Collections.Generic;
using UnityEngine;

public class LineRendererControlScript : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform[,] pointGrid;
    public int rows;
    public int cols;

    private List<Vector3> pathPoints = new List<Vector3>();
    private List<Vector2Int> pathIndices = new List<Vector2Int>();

    public void OnPointClicked(Vector2Int index)
    {
        if (!IsValidIndex(index)) return;

        if (pathIndices.Count == 0)
        {
            AddPoint(index);
            return;
        }

        Vector2Int last = pathIndices[pathIndices.Count - 1];
        if (IsAdjacent(last, index) && !pathIndices.Contains(index))
        {
            AddPoint(index);
        }
    }

    private void AddPoint(Vector2Int index)
    {
        pathIndices.Add(index);
        pathPoints.Add(pointGrid[index.x, index.y].position);
        UpdateLineRenderer();
    }

    private void UpdateLineRenderer()
    {
        lineRenderer.positionCount = pathPoints.Count;
        lineRenderer.SetPositions(pathPoints.ToArray());
    }

    private bool IsValidIndex(Vector2Int index)
    {
        return index.x >= 0 && index.x < rows && index.y >= 0 && index.y < cols;
    }

    private bool IsAdjacent(Vector2Int a, Vector2Int b)
    {
        int dx = Mathf.Abs(a.x - b.x);
        int dy = Mathf.Abs(a.y - b.y);
        return (dx == 1 && dy == 0) || (dx == 0 && dy == 1);
    }

    public void ClearPath()
    {
        pathIndices.Clear();
        pathPoints.Clear();
        lineRenderer.positionCount = 0;
    }
}
