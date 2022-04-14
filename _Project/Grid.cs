using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Grid<TGridObject> 
{
    public int width;
    public int height;
    public int cellSize;
    public Vector3 originPoint;
    public TGridObject[,] gridObjects;

    public Grid(int width, int height, int cellSize, Func<Grid<TGridObject>, int, int, TGridObject> createGridObject,
        Vector3 originPoint = default)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize; 
        this.originPoint = originPoint;
        gridObjects = new TGridObject[width, height];
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j ++)
            {
                gridObjects[i, j] = createGridObject(this, i, j);
            }
        }
   
    }

    public Vector3 getCellWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPoint;
    }

    public int2 getCoord(Vector3 position)
    {
        return new int2(Mathf.FloorToInt((position-originPoint).x/ cellSize), 
            Mathf.FloorToInt((position - originPoint).y / cellSize));
    }

    public TGridObject getValue (Vector3 position)
    {
        int2 coord = getCoord(position);
        return gridObjects[coord.x, coord.y];
    }

    public void setValue(Vector3 position, int value, Func<int, int, int, TGridObject> createGridObject)
    {
        int2 coord = getCoord(position);
        gridObjects[coord.x, coord.y] = createGridObject(coord.x,coord.y, value);
    }

    public void setValue(int2 gridPosition, int value, Func<int, int, int, TGridObject> createGridObject)
    {
        int2 coord = gridPosition;
        gridObjects[coord.x, coord.y] = createGridObject(coord.x, coord.y, value);
    }

    public TGridObject getValue(int2 gridPosition)
    {
        int2 coord = gridPosition;
        return gridObjects[coord.x, coord.y];
    }
  
    public void getNeighbors()
    {
        
    }

    public void inBounds()
    {
      
    }
  

}
