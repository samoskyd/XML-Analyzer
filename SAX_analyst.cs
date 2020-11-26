using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace second_lab_oop
{
    class SAX_analyst : IStrategy
    {
        List<Beer> IStrategy.Commit()
        {
            List<Beer> beers = new List<Beer>();
            using (XmlReader xr = XmlReader.Create("beer.xml"))
            {
                while (xr.Read())
                {
                    Beer beer = new Beer();
                    if(xr.HasAttributes)
                    {
                        beer.Sort = xr.GetAttribute("sort");
                        beer.Brand = xr.GetAttribute("brand");
                        {
                            string str = xr.GetAttribute("price");
                            if (str != null)
                            {
                                string[] words = str.Split(new char[] { '.' });
                                str = words[0] + "," + words[1];
                                beer.Price = double.Parse(str);
                            }
                        }
                        beer.Shop = xr.GetAttribute("shop");
                        beer.Country = xr.GetAttribute("country");
                        {
                            string str = xr.GetAttribute("reviews");
                            if (str != null)
                            {
                                string[] words = str.Split(new char[] { '.' });
                                str = words[0] + "," + words[1];
                                beer.Reviews = double.Parse(str);
                            }
                        }
                        if (xr.GetAttribute("sale") == "Yes") beer.Sale = true;
                        else beer.Sale = false;
                    }
                    if (beer.Sort != null) beers.Add(beer);
                }
            }
            return beers;
        }
    }
}
