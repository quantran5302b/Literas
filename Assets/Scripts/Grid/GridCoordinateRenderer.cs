using TMPro;
using UnityEngine;

public class GridCoordinateRenderer : MonoBehaviour
{
    public GridManager grid;
    public GameObject textPrefab;
    public bool show = true;

    void Start()
    {
        if (!show) return;

        for (int x = 0; x < grid.width; x++)
        {
            for (int y = 0; y < grid.height; y++)
            {
                Vector2Int pos = new Vector2Int(x, y);
                Vector3 worldPos = grid.GridToWorld(pos);

                GameObject textObj = Instantiate(textPrefab, worldPos, Quaternion.identity, transform);

                TextMeshPro text = textObj.GetComponent<TextMeshPro>();
                text.text = $"({x},{y})";

                // Đẩy lên trên một chút để không bị trùng object
                textObj.transform.position += new Vector3(0, 0, -1);
            }
        }
    }
}