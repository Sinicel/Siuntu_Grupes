using System;
using HtmlAgilityPack;

namespace Siuntu_Grupes
{
    class Parse
    {
       public static string HTML;


        /// <summary>
        /// Is HTML kodo grazina siuntu grupiu linkus.
        /// </summary>
        /// <returns></returns>
        static public string[] GetAllID()
        {
           // HTML = Request.GetSiuntuGrupes();

            HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(HTML);
            HtmlNodeCollection table = doc.DocumentNode.SelectNodes("//table[@id='_ctl0_UCPackagesListView1_grdPackageList']/tr/td[11]");
            table.Remove(0);

            int ii = table.Count;
            string[] All_ID = new string[ii];

            //foreach (HtmlNode item in table)
            //{
            //    item.RemoveClass("",);
            //    Console.WriteLine(item.InnerHtml);
            //}
            for (int i = 0; i < ii; i++)
            {

                All_ID[i] = "http://bkisnew:83/Default.aspx?ID=202&PACKAGE_ID=" + table[i].InnerText + "&persist=all";

            }

            return All_ID;
        }

        public static string GetLink(string htmlpage)
        {
            HTML = null;
            HTML = htmlpage;
            string link = null;

            HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(HTML);
            link = doc.DocumentNode.SelectSingleNode("//a").GetAttributeValue("href", "NERASTA");
            Console.WriteLine(link);
            return link;
        }
    }
}
