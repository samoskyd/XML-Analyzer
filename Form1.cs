using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml;
using System.IO;

namespace second_lab_oop
{
    public partial class Form1 : Form
    {
        private bool box1 = false;
        private bool box2 = false;
        private bool box3 = false;
        private bool box4 = false;
        private bool box5 = false;
        private bool box6 = false;
        private bool box7 = false;
        private string combo1 = "";
        private string combo2 = "";
        private string combo3 = "";
        private string combo4 = "";
        private string combo5 = "";
        private string combo6 = "";
        private string combo7 = "";
        private string radio = "";
        private Context strat;
        private SAX_analyst s_a = new SAX_analyst();
        private DOM_analyst d_a = new DOM_analyst();
        private LINQ_analyst l_a = new LINQ_analyst();

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo1 = (string)comboBox1.SelectedItem;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo2 = (string)comboBox2.SelectedItem;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo3 = (string)comboBox3.SelectedItem;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo4 = (string)comboBox4.SelectedItem;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo5 = (string)comboBox5.SelectedItem;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo6 = (string)comboBox6.SelectedItem;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo7 = (string)comboBox7.SelectedItem;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (box1 == true) box1 = false;
            else if (box1 == false) box1 = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (box2 == true) box2 = false;
            else if (box2 == false) box2 = true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (box3 == true) box3 = false;
            else if (box3 == false) box3 = true;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (box4 == true) box4 = false;
            else if (box4 == false) box4 = true;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if(box5 == true) box5 = false;
            else if (box5 == false) box5 = true;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (box6 == true) box6 = false;
            else if (box6 == false) box6 = true;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (box7 == true) box7 = false;
            else if (box7 == false) box7 = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radio = "sax";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radio = "dom";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            radio = "linq";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConvertToHTML();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radio == "sax")
            {
                strat = new Context(s_a);
            }
            else if (radio == "dom")
            {
                strat = new Context(d_a);
            }
            else if (radio == "linq")
            {
                strat = new Context(l_a);
            }
            else
            {
                richTextBox1.AppendText("Будь ласка, виберіть спосіб аналізу XML, шивдко! (sax, dom або linq)");
                return;
            }
            List<Beer> beers = SearchResult(strat.Analyze_XML());
            string result = ConvertToString(beers);
            richTextBox1.Clear();
            richTextBox1.AppendText(result);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Пакеда!");
        }

        private List<Beer> SearchResult(List<Beer> beers)
        {
            List<Beer> result = new List<Beer>();
            foreach (Beer beer in beers) result.Add(beer);
            foreach (Beer beer in beers)
            {
                if (box1 == true && beer.Sort != combo1) result.Remove(beer);
                if (box2 == true && beer.Brand != combo2) result.Remove(beer);
                if (box3 == true)
                {
                    string[] price_range = combo3.Split(new char[] { '-' });
                    if (!PriceCheck(price_range, beer.Price)) result.Remove(beer);
                }
                if (box4 == true && beer.Shop != combo4) result.Remove(beer);
                if (box5 == true && beer.Country != combo5) result.Remove(beer);
                if (box6 == true)
                {
                        string[] reviews_range = combo6.Split(new char[] { '-' });
                        if (!ReviewsCheck(reviews_range, beer.Reviews)) result.Remove(beer);//
                }
                if (box7 == true)
                {
                    bool temp = false;
                    if (combo7 == "Так") temp = true;
                    if (beer.Sale != temp) result.Remove(beer);
                }
            }
            return result;
        }

        private string ConvertToString(List<Beer> beers)
        {
            string result = "";
            foreach (Beer beer in beers)
            {
                result += "Вид: " + beer.Sort;
                result += "\n";
                result += "Бренд: " + beer.Brand;
                result += "\n";
                result += "Ціна: " + beer.Price;
                result += "\n";
                result += "Магазин: " + beer.Shop;
                result += "\n";
                result += "Країна: " + beer.Country;
                result += "\n";
                result += "Відгуки: " + beer.Reviews;
                result += "\n";
                if (beer.Sale == true) result += "Зі знижкою";
                else result += "Без знижки";
                result += "\n";
                result += "Об'єм: " + beer.Volume;
                result += "\n" + " " + "\n";
            }
            return result;
        }

        private bool PriceCheck(string[] price_range, double price)
        {
            bool flag = false;
            double lower_bound, upper_bound = 0;
            if (price_range[0].Contains("+"))
            {
                lower_bound = 60;
                flag = true;
            }
            else lower_bound = double.Parse(price_range[0]);
            if (!price_range[0].Contains("+"))
            {
                string[] temp = price_range[1].Split(new char[] { ' ' });
                upper_bound = double.Parse(temp[0]);
            }
            if (price >= lower_bound && (price <= upper_bound || flag)) return true;
            else return false;
        }

        private bool ReviewsCheck(string[] reviews_range, double review)
        {
            double lower_bound = double.Parse(reviews_range[0]);
            string[] temp = reviews_range[1].Split(new char[] { ' ' });
            double upper_bound = double.Parse(temp[0]);
            if (review >= lower_bound && review <= upper_bound) return true;
            else return false;
        }

        private void ConvertToHTML()
        {
            XPathDocument xml = new XPathDocument("beer.xml");
            XslTransform xsl = new XslTransform();
            xsl.Load("web_beer.xsl");
            XmlTextWriter writer = new XmlTextWriter("result.html", null);
            xsl.Transform(xml, null, writer);
            writer.Close();
            System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "result.html");
        }

        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MessageBox.Show("так, тут все просто:\n" + "1. Відмітьте ті поля, по яким ви хочете здійснити пошук\n" + "2. Виберіть в списку навпроти відповідний фільтр\n" + "3. Виберіть метод, яким буде здійсеюватись пошук (результат від нього не залежить)\n" + "4. Натисніть кнопку ПОШУК\n" + "5. Для того, щоб очистити результат, використайте відповідну кнопку (ОЧИСТИТИ)\n" + "6. Щоб переглянути всі результати в HTML натисніть КОНВЕРТУВАТИ В HTML\n");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("так, тут все просто:\n" + "1. Відмітьте ті поля, по яким ви хочете здійснити пошук\n" + "2. Виберіть в списку навпроти відповідний фільтр\n" + "3. Виберіть метод, яким буде здійсеюватись пошук (результат від нього не залежить)\n" + "4. Натисніть кнопку ПОШУК\n" + "5. Для того, щоб очистити результат, використайте відповідну кнопку (ОЧИСТИТИ)\n" + "6. Щоб переглянути всі результати в HTML натисніть КОНВЕРТУВАТИ В HTML\n");
        }
    }
}
