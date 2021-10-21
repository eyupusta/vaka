using System;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace vaka
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlAgilityPack.HtmlWeb hweb = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument hdoc = hweb.Load("https://www.hepsiemlak.com/satilik");
            int i = 1;

            Console.WriteLine("List View Title:");
            foreach (HtmlAgilityPack.HtmlNode item in hdoc.DocumentNode.SelectNodes("//div[@class = 'list-view-title']"))
            {
                if(i < 10)
                    Console.WriteLine(" " + i + ". " + item.InnerText.ToString());
                else
                    Console.WriteLine(i + ". " + item.InnerText.ToString());
                i++;
            }

            Console.WriteLine("\n\n");
            i = 1;
            Console.WriteLine("List View Price:");
            foreach (HtmlAgilityPack.HtmlNode item in hdoc.DocumentNode.SelectNodes("//div[@class = 'list-view-price']"))
            {
                if (i < 10)
                    Console.WriteLine(" " + i + ". " + item.InnerText.ToString());
                else
                    Console.WriteLine(i + ". " + item.InnerText.ToString());
                i++;
            }

            Console.WriteLine("\n\n");
            i = 1;
            Console.WriteLine("Links:");
            foreach (HtmlAgilityPack.HtmlNode item in hdoc.DocumentNode.SelectNodes("//a[@class = 'card-link']"))
            {
                if(i < 10)
                    Console.WriteLine(" " + i + ". " + "https://www.hepsiemlak.com/satilik" + item.Attributes["href"].Value);
                else
                    Console.WriteLine(i + ". " + "https://www.hepsiemlak.com/satilik" + item.Attributes["href"].Value);
                i++;
            }

            Console.WriteLine("\n\n");
            i = 1;
            Console.WriteLine("Advertiser:");
            foreach (HtmlAgilityPack.HtmlNode item in hdoc.DocumentNode.SelectNodes("//a[@class = 'card-link']"))
            {
                HtmlAgilityPack.HtmlDocument hdoc2 = hweb.Load("https://www.hepsiemlak.com" + item.Attributes["href"].Value);

                foreach (HtmlAgilityPack.HtmlNode item2 in hdoc2.DocumentNode.SelectNodes("//div[@class = 'firm-link fontRB']"))
                {
                    if(i < 10)
                        Console.WriteLine(" " + i + ". " + item2.InnerText.ToString());
                    else
                        Console.WriteLine(i + ". " + item2.InnerText.ToString());
                    i++;
                }
            }
        }
    }
}
