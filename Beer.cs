using System;
using System.Collections.Generic;
using System.Text;

namespace second_lab_oop
{
	class Beer
	{
		private string sort;
		private string brand;
		private double price;
		private string shop;
		private string country;
		private double reviews;
		private bool sale;
		private string volume = "0,5";

		public Beer() : this("Unknown")
		{
		}
		public Beer(string sort) : this(sort, "Unknown")
		{
		}
		public Beer(string sort, string brand) : this(sort, brand, 0)
		{
		}
		public Beer(string sort, string brand, double price) : this(sort, brand, price, "Unknown")
		{
		}
		public Beer(string sort, string brand, double price, string shop) : this(sort, brand, price, shop, "Unknown")
		{
		}
		public Beer(string sort, string brand, double price, string shop, string country) : this(sort, brand, price, shop, country, 0)
		{
		}
		public Beer(string sort, string brand, double price, string shop, string country, double reviews) : this(sort, brand, price, shop, country, reviews, false)
		{
		}
		public Beer(string sort, string brand, double price, string shop, string country, double reviews, bool sale)
		{
		}

		public string Sort { get { return sort; } set { sort = value; } }
		public string Brand { get { return brand; } set { brand = value; } }
		public double Price { get { return price; } set { price = value; } }
		public string Shop { get { return shop; } set { shop = value; } }
		public string Country { get { return country; } set { country = value; } }
		public double Reviews { get { return reviews; } set { reviews = value; } }
		public bool Sale { get { return sale; } set { sale = value; } }
		public string Volume { get { return volume; } }
	}
}
