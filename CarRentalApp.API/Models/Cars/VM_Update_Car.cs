﻿namespace CarRentalApp.API.Models.Cars
{
    public class VM_Update_Car
    {
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
