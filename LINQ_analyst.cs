using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace second_lab_oop
{
    class LINQ_analyst : IStrategy
    {
        List<Beer> IStrategy.Commit()
        {
            List<Beer> beers = new List<Beer>();
            XDocument doc = XDocument.Load("beer.xml");
            foreach (XElement item in doc.Element("beerlist").Elements("beer"))
            {
                Beer beer = new Beer();
                XAttribute sort = item.Attribute("sort");
                XAttribute brand = item.Attribute("brand");
                XAttribute price = item.Attribute("price");
                XAttribute shop = item.Attribute("shop");
                XAttribute country = item.Attribute("country");
                XAttribute reviews = item.Attribute("reviews");
                XAttribute sale = item.Attribute("sale");
                if (sort != null && brand != null && price != null && shop != null && country != null && reviews != null && sale != null)
                {
                    beer.Sort = sort.Value;
                    beer.Brand = brand.Value;
                    {
                        string str = price.Value;
                        string[] words = str.Split(new char[] { '.' });
                        str = words[0] + "," + words[1];
                        beer.Price = double.Parse(str);
                    }
                    beer.Shop = shop.Value;
                    beer.Country = country.Value;
                    {
                        string str = reviews.Value;
                        string[] words = str.Split(new char[] { '.' });
                        str = words[0] + "," + words[1];
                        beer.Reviews = double.Parse(str);
                    }
                    if (sale.Value == "Yes") beer.Sale = true;
                    else beer.Sale = false;
                }
                beers.Add(beer);
            }
            return beers;
        }
    }
}
