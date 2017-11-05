using ProductManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagement.App.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public List<Category> AllCategories { get; set; }
        public List<Category> ProductCategories { get; set; }
        public string[] SelectedCategories { get; set; }

        public byte[] GetSelectedCategories()
        {
            var selectedCategories = new List<byte>();
            if (SelectedCategories != null)
            {
                foreach(var item in SelectedCategories)
                {
                    selectedCategories.Add(byte.Parse(item));
                }
            }
            return selectedCategories.ToArray();
        }
    }
}