﻿namespace FormulaOne.Controllers.DTOs.DriverDTOs
{
    public class DriverInfo
    {
        public required string FullName { get; set; } = null!;

        public required string BirthDate { get; set; } = null!;

        public required string Nationality { get; set; } = null!;

        public required string TeamName { get; set; } = null!;
    }
}
