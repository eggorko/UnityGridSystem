using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Eggorko;
using TMPro;
using Unity.Mathematics;

public class GridVisuals<T>
{
    private Grid<T> grid;
    public void bounds(Grid<T> grid)
    {
        this.grid = grid;
       
    }

    public void drawDebugLines(Func<T, int> doStuff, Func<T,int2> doStuff2 )
    {
        for (int i = 0; i < grid.width; i++)
        {
            for (int j = 0; j < grid.height; j++)
            {
                Utils.CreateWorldText(doStuff(grid.getValue(new int2(i, j))).ToString(), null,
                    grid.getCellWorldPosition(i, j) + new Vector3(grid.cellSize, grid.cellSize) * .5f);
                Utils.CreateWorldText(doStuff2(grid.getValue(new int2(i, j))).ToString(), null,
                    grid.getCellWorldPosition(i, j) + new Vector3(grid.cellSize, grid.cellSize) * .2f,5);
                Debug.DrawLine(grid.getCellWorldPosition(i, j), grid.getCellWorldPosition(i, j + 1), Color.white, 100f);
                Debug.DrawLine(grid.getCellWorldPosition(i, j), grid.getCellWorldPosition(i + 1, j), Color.white, 100f); 
            }
        }
        Debug.DrawLine(grid.getCellWorldPosition(0,grid.height), grid.getCellWorldPosition(grid.width, grid.height),Color.white,100f);
        Debug.DrawLine(grid.getCellWorldPosition(grid.width, 0), grid.getCellWorldPosition(grid.width, grid.height),Color.white,100f);
    } 
    
}
