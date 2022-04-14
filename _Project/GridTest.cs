using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GridTest : MonoBehaviour
{
    public int with = 15;
    public int height = 3;
    public int cellSize = 2;
    void Start()
    {
        
        Vector3 position = new Vector3(-with/2f * cellSize, -height/2f * cellSize, 0f);
        Grid<GridCell> grid = new Grid<GridCell>(with,height,cellSize,
            (Grid<GridCell> g, int x, int y) => new GridCell(g,x,y),
            position);
        GridVisuals<GridCell> visuals = new GridVisuals<GridCell>();
        visuals.bounds(grid);
        visuals.drawDebugLines((GridCell g) => g.value,(cell => new int2(cell.x,cell.y) ));
        transform.position = position;
    }

    void Update()
    {
        
    }
}
