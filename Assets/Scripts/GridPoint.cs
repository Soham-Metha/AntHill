using UnityEngine;
using UnityEngine.EventSystems;

public class GridPoint : MonoBehaviour
{
    public Vector2Int gridIndex;
    public LineRendererControlScript controller;

    public void OnMouseDown()
    {
        controller.OnPointClicked(gridIndex);
    }
}
