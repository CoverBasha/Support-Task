﻿namespace Support_Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public bool EnableSize { get; set; }
        public Company Company { get; set; }


		public Product()
		{
            Company = new Company();
		}

    }
}
