using System;

namespace SafErgyReal.Models
{
    public class ScanResultViewModel
    {
        public List<FoodItem> IdentifiedFoodItems { get; set; } = new List<FoodItem>();
    }

    public class FoodItem
    {
        public string Name { get; set; }
        public float Value { get; set; }
    }

}

