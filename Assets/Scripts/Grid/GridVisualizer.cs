using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class GridVisualizer : MonoBehaviour
{
    private GridManager grid;

    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.widthMultiplier = 0.05f;
        grid = GridManager.Instance;
        DrawGrid();
    }

    void DrawGrid()
    {
        int width = grid.width;
        int height = grid.height;
        float size = grid.cellSize;

        int lines = (width + 1) + (height + 1);
        line.positionCount = lines * 2;

        int index = 0;

        // Vertical
        for (int x = 0; x <= width; x++)
        {
            line.SetPosition(index++, new Vector3(x * size, 0, 0));
            line.SetPosition(index++, new Vector3(x * size, height * size, 0));
        }

        // Horizontal
        for (int y = 0; y <= height; y++)
        {
            line.SetPosition(index++, new Vector3(0, y * size, 0));
            line.SetPosition(index++, new Vector3(width * size, y * size, 0));
        }
    }
}