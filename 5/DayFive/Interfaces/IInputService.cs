﻿namespace DayFive.Interfaces;

public interface IInputService
{
    Task<List<Vents>> GetCoordinateListAsync();
}
