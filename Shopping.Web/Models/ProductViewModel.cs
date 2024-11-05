﻿using System.ComponentModel.DataAnnotations;

namespace Shopping.Web.Models
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        [Range(1, 100)]
        public int Count { get; set; } = 1;

        public string SubStringName()
        {
            if (Name.Length < 24) return Name;
            return $"{Name.Substring(0, 21)}...";
        }
        public string SubStringDescription()
        {
            if (Description.Length < 34) return Description;
            return $"{Description.Substring(0, 100)}...";
        }
    }
}
