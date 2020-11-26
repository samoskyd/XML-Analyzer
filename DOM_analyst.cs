using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace second_lab_oop
{
    class DOM_analyst : IStrategy
    {
        List<Beer> IStrategy.Commit()
        {
            List<Beer> beers = new List<Beer>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("beer.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                Beer beer = new Beer();
                beer.Sort = xnode.Attributes.GetNamedItem("sort").Value;
                beer.Brand = xnode.Attributes.GetNamedItem("brand").Value;
                {
                    string str = xnode.Attributes.GetNamedItem("price").Value;
                    string[] words = str.Split(new char[] { '.' });
                    str = words[0] + "," + words[1];
                    beer.Price = double.Parse(str);
                }
                beer.Shop = xnode.Attributes.GetNamedItem("shop").Value;
                beer.Country = xnode.Attributes.GetNamedItem("country").Value;
                {
                    string str = xnode.Attributes.GetNamedItem("reviews").Value;
                    string[] words = str.Split(new char[] { '.' });
                    str = words[0] + "," + words[1];
                    beer.Reviews = double.Parse(str);
                }
                if (xnode.Attributes.GetNamedItem("sale").Value == "Yes") beer.Sale = true;
                else beer.Sale = false;

                beers.Add(beer);
            }
            return beers;
        }
    }
}
