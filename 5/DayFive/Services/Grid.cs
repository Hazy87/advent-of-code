﻿namespace DayFive.Services
{
    public class Grid
    {
       public Dictionary<(int x, int y), int> VentPlacements { get; set; } = new Dictionary<(int x, int y), int>();
    }
}