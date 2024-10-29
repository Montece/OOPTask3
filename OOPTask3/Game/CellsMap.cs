﻿using OOPTask3.Game.Cells;
using OOPTask3.Map;
using OOPTask3.StateMachine;

namespace OOPTask3.Game;

public sealed class CellsMap : Map2d<Cell>
{
    public CellsMap(int width, int height, List<StateView> views) : base(width, height)
    {
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                var point = new Point(x, y);
                SetElement(point, new Cell(this, point, views));
            }
        }
    }
}