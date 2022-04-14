using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell
{
    public int x;
    public int y;
    public int value;
    public int state;

   public GridCell(Grid<GridCell> g, int x, int y)
    {
        this.x = x;
        this.y = y;
        this.value = value;
    }
   
   public GridCell(int x, int y, int value)
   {
       this.x = x;
       this.y = y;
       this.value = value;
   }
}
