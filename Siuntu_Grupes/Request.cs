using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;
using System.Windows.Forms;
namespace Siuntu_Grupes
{
    class Request
    {

        static string Url;
        public static string __VSTATE2;
        public static string HTMLPage;
        public static string __VSTATE;
        public static string gr__VSTATE;
        static HttpWebRequest request;
        private static CookieContainer cookes = new CookieContainer();



        /// <summary>
        /// Uzklausa randa visas siuntu grupes pagal parametrus. Grazina HTML koda.
        /// </summary>
        /// <param name="busena">Visos, Neuždaryta, Uždaryta, Perduota, Gauta, Sutikrinta, Dingusi, Atmesta</param>
        /// <param name="tipe"></param>
        /// <param name="datanuo"></param>
        /// <param name="dataiki"></param>
        /// <returns></returns>
        static public string GetSiuntuGrupes(string busena, string tipe, string datanuo, string dataiki)
        {


            //  MessageBox.Show();
            string postdata = "__EVENTTARGET=&__EVENTARGUMENT=&__LASTFOCUS=&__VSTATE=H4sIAMTyS14A%2F%2B2a72%2FbxhnHTVq0ZTu11KzR2qSTlHRt4iVy7xePpJsOi52sCxIHWuQGGDBAoMWTwkoiXZJCawwD9mZ%2FQ1%2F39V7u%2FV7Ff9f6HCUrNmYGFmlEg0AZoHnHe453n%2Bd7z%2F0A%2F6uUPla0aru953tR4A%2FCl%2BL7kRuIph9Gu3an%2F0wct9uVLW2zc9iKbM%2Bxg2hfeCPtQbsTDdDOt3tNKGT3RPjcDaNXrvgB7wSHu8cvRXjke6F76A7c6Fj77F2l9wJhR8K5XKE77yzkD12vd6kyZnKZXuBMMmXejizIdjpD57EYiEjMaKmntuSpLY3UlmZqS%2BuMpTWTJUbpTXF6U5LeVE9vytObGulNzfSm6f1K0vuVpPcrSe9XQtObsvSm6dVE0quJpFcTSa8mkl5NNL2aaHo10fRqounVRNOriaZXE02vJppeTTS9mmh6NbEzkihp6w3GGKfUsoySU1FVBa7X1OVSqaJWV1%2B5sIoZiNeOo67InNqSvC2WyvHTvdei0xcOZEHmemxROBA%2FRtonLXfkRSf%2FrveC0ZEL%2F8M3%2Fwzsk5%2FtEApuytd0Ty%2BV7vStK91xvcUD%2B%2FCp54gflQeKfI3vdf3OKNQMt3svOj4SfvdeT0RN6BIsyqJRuPX11%2FW73ZHXiVzfu7tVP%2Ffw3tZXsnVKXHVtWWlAlbVCprrU07q2s9elTHuvdk%2Br%2FfIqmvi%2F1aJs1ZYqxa6qqKq6rBZUTV1RVyvFsqaBQvxQUxu4V9Y2XojRyX9glXwc2Zoic9a%2BfZsmkC42ReCMfJmkkNS%2BsUfynsH9emsUuf3A9WSGDhmrj2GpOgpdTeEy9SgailA%2BM3rQwWXZq5Xq%2BmM7svfF8FAE2vXmo71nj7550j74S%2FNJq%2F38aeugutG%2BLUvs%2BiPP6QEDnI1B%2BcZaQQ6Jjed2%2F%2BTnyA7rz8zPX4oejKwAeuWH9b4fxIt%2FR3gd9zvIGNqu1P2tR1HYdwM7dMO6Y7v9yJbjIYLUM%2BvmrvCcix%2FdadpH8ORdNZf24V8wmqY%2FbAawRRmKwJZWsrKbL4TtgPG4hYHoD%2Bzh5NGNNfAcUCEKU3QVMxXDlavY%2BOj%2B8lrv9Ae8C6WxiEhGbaoaVFSoXnsSBH6wL8IQnmp%2F%2FsI7DI%2B%2BOnc9HA0Gk%2FsXEKcAutez6wDDcb03P9XDMwHmzU9hPRz1T%2F4VuEMfEEb2dk3Vrj8Ep%2Fhe7%2Fe3H345uZtGsWWFZu3HquxHbVV7eem29%2BwBKDxL44uTxrOsjV%2BTYXbN9TwRvI6GA63UOt8iGc0f3l%2FaUJdKlfWapn0wGVqTUVWUYwr2xmFlSY6wp5EY7sEIi9Tt6pp80zihVG%2BMR1%2FLHwUdcaaUo0Dl5eUCXAvKEjSlLIv90Q%2BGdtSKArlD3fwb2jmGX2N%2Fv%2BE4f185LQoTUPHM%2FXgO%2BStEOqmqlT8Jt%2Fc6urUU%2F9gfFLhWC%2B3brV31H4pTqU8mHQlRhT7tI8SZiRmlzw%2FiUDx%2BcCYQxZH0tLgbDIV3fCg9GMYRaPzgEkN0On6gcoKw1cCkgbgzHgwy99Yrd%2BC5NgzigS%2BDidsH447woiA2XjltQ0v0Iz9woVyz9dgZi1A%2BqEztCW%2FEgeQIIsj2VDKqtjKWoyN9P54aprP5%2BpRKdfWJZ8N0L2d0deMtrLJMX5vUpCBIfHA2sXk2UZokihQTbDKmTxgWapvn%2FFIrJfkEY51ww5qHT%2FT%2FP5%2BM4V%2BFMwyDkpiRU6leTN0i%2FBz1t7P3IkK%2FNGN8ecbcYizuZBJjijjKGWdjjC0UdyeRMcckZ5yJsU50HLczkTExjJxxJsbEICxuTiJjZpk540yMsY5x%2FLILGSPOKSF6zjgLY2QwZk7WMAk6Nkk%2B52VjzC1qTKq%2BmDEjDM%2BBMVsgxrqpk0lVFzPmup4zzsiYIHNiOtOGkDNK5rEhnBf797AhxJZlYGtSejZnUIRyZ1yxMwwUH5VsJqxUdBN25%2Bx9Rx%2FcIPM6prr66IMJ02MNlRJXg8Sy6BwY64vEGHE5i5aTV9wm1XPGmRhTPT7J%2BzBhpcJ0i1MjZ5yNMY53jtcTdcwwyhlnY0x0S3bnV8mMEUM540yMkWFRyPsoOVYYRj7nZWIMizcid%2Bc3knVM3v%2BJ9KIxxkhuVipJOuYIU54zzsSYQzCAvF8n7kF0ZuVzXkbGTJeMP07WMcH5%2BjgjY2rKbesnyTqG5V3OOBtjwqSOb75Dx%2BY84jFbJMaIyLxbiTqmiNCccSbGOo%2FPKz5NPnczmJkzzsaYcVn6N8mM%2BVzmvIViTA1ZunoxY84tguaydlsoxij%2BKqaWyBhbVh4rsjFmlin3efXEvbShG%2Fm6IiNjTuX6%2BHYiY5PSeawr6CIxxvH6%2BE7y%2BpjpVs44E2NqcanjzxJ1bBGS6zgj4%2FHZ5m%2BTGRtIzxlnYoyJLqeXzy9mbBqYUZPkjDMxRoYhj1%2B%2BSF5XMJ7rOBNj2GDEZ%2FR3S7N8UCRDCNPN9%2F5BEbDHzsJ%2BUIRMbsTf7txLDtzgsjkIHi2M4IExwZLx1oyCN%2BQCcB6CR4sseGZR%2BW3p72aNPoZJaO6MK3YGsSx5rHp%2FZmdgk%2BTOuFpnGKYVnw0%2BmDlMMWTmzrhiZ3BCZJhqzOwMzOcxZ8SfiC%2BsM3SO5QJ8ezZn6CYGh%2BTOuGJnUB6HqVLsDFVbRds6%2FKHq6oHvDw7cI60MHOg2srYxqmO0g6CGXwDn5DUbwlEAAA%3D%3D&__VIEWSTATE=&_ctl0%3AUCPackagesListView1%3APackagesScope=rbByResponsibility&_ctl0%3AUCPackagesListView1%3AddlResponsibility=1&_ctl0%3AUCPackagesListView1%3AddlStatus=" + busena + "&_ctl0%3AUCPackagesListView1%3AddlPackageType=" + tipe + "&_ctl0%3AUCPackagesListView1%3AtboxStartDate=" + datanuo + "&_ctl0%3AUCPackagesListView1%3AtboxEndDate=" + dataiki + "&_ctl0%3AUCPackagesListView1%3AcmdDefault=Atnaujinti&__LastFocusedElement=_ctl0_UCPackagesListView1_cmdDefault&__ScrollTop=240&__ScrollLeft=0&__ValidationSummaryDisplay=none";

            request = (HttpWebRequest)WebRequest.Create("http://bkisnew:83/Default.aspx?ID=205");
            byte[] byteArray = Encoding.UTF8.GetBytes(postdata);
            request.Method = "POST";
            request.KeepAlive = true;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Credentials = Form1.MyCash;// new NetworkCredential("audriussi", "post*111");
            request.CookieContainer = cookes;
            request.Host = "bkisnew:83";
            request.AllowAutoRedirect = true;
           // request.MaximumAutomaticRedirections = 1;
            request.Referer = "http://bkisnew:83/Default.aspx?ID=735";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                HTMLPage = stream.ReadToEnd();
                stream.Close();
            }


            return HTMLPage;
        }

        /// <summary>
        /// Uzklausa gauna siuntu linkus ir uzena i kiekviena, grazina kiekvieno linko HTML koda.
        /// </summary>
        /// <returns></returns>
        public static string OpenGrupe(string[] urllinks)
        {
            string[] AllUrl = urllinks;

            foreach (string Url in AllUrl)
            {


                Console.WriteLine(Url);

                request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "get";
                request.Credentials = Form1.MyCash; //new NetworkCredential("audriussi", "post*111");

                request.Host = "bkisnew:83";
                request.KeepAlive = true;
                request.CookieContainer = cookes;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    HTMLPage = stream.ReadToEnd();
                }


                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.LoadHtml(HTMLPage);
                HtmlAgilityPack.HtmlNode node = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='_ctl0_UCPackageTareWeight1_tbItemTareWeight']");
                string svoris = node.GetAttributeValue("value", "nerasta");
                __VSTATE2 = htmlDocument.GetElementbyId("__VSTATE").GetAttributeValue("value", "nerasta").ToString();
                __VSTATE2 = Uri.EscapeDataString(__VSTATE2);
                PresSutikrinti(Url, svoris);
            }
            return HTMLPage;
        }

        /// <summary>
        /// Uzklausa, paspaudzia "Sutikrinti" siuntu grupeje. 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        static public string PresSutikrinti(string url, string svoris)
        {


            string postdata = "__EVENTTARGET=&__EVENTARGUMENT=&__LASTFOCUS=&__VSTATE="+ __VSTATE2+"&__VIEWSTATE=&_ctl0%3AUCPackageTareWeight1%3AtbItemTareWeight=" + Uri.EscapeDataString(svoris) + "&_ctl0%3AcmdConfirm=Sutikrinti&__LastFocusedElement=_ctl0_cmdConfirm&__ScrollTop=252&__ScrollLeft=0&__ValidationSummaryDisplay=none";

            request = (HttpWebRequest)WebRequest.Create(url);
            byte[] byteArray = Encoding.UTF8.GetBytes(postdata);
            request.Method = "POST";
            request.KeepAlive = true; request.ContentType = "application/x-www-form-urlencoded";
            request.Credentials = Form1.MyCash; //new NetworkCredential("audriussi", "post*111");
            request.CookieContainer = cookes;
            request.Host = "bkisnew:83";
            request.AllowAutoRedirect = false;
           // request.MaximumAutomaticRedirections = 1;
            request.Referer = "http://bkisnew:83/Default.aspx?ID=202";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                HTMLPage = stream.ReadToEnd();
                stream.Close();
            }
            string Url2 = "http://bkisnew:83" + Parse.GetLink(HTMLPage).Replace("&amp;", "&");

            PresSaugoti(Url2);

            return HTMLPage;
        }


        /// <summary>
        /// Uzklausa, gauna siuntos linka, paspaudzia "Saugoti" siuntu grupeje.
        /// </summary>
        /// <param name="url2"></param>
        /// <returns></returns>
        static public string PresSaugoti(string url2)
        {
            Console.WriteLine("URL = " + url2);
            Console.WriteLine("request.RequestUri = " + request.RequestUri);
            string boundary = "---------------------------7e4199331068c";

            string postdata = @"-----------------------------7e4199331068c
Content-Disposition: form-data; name=""__EVENTTARGET""


-----------------------------7e4199331068c
Content-Disposition: form-data; name=""__EVENTARGUMENT""


-----------------------------7e4199331068c
Content-Disposition: form-data; name=""__LASTFOCUS""


-----------------------------7e4199331068c
Content-Disposition: form-data; name=""__VSTATE""

H4sIAG41pF4A /61U227TQBCt3ThNk1JXICIEyNlWXNLSpJtLQW1BgrYSKhSIcCjiKdrY63Rrx2u8a0Q+gG9APPYbeIan5rtg7NjlJl4IsrQez8yeObM7x98U/YqiGb3eHvdlyD3xkr6NWEg7XMhdYrlP6ajXK6vaotU3JfFtEspn1I+0iz1Lenjb6h+IfSaGRFrHulastdvtu63W1tY93S6rqqKXVWOO+pYcBVS7NIw8yQJA2HB4OKzZRJLygjqrJ1lHTLC+R49tW83HnooSmwV9KYnuHVPLpTa4wFlMduS69L3UHpuRZG7IfMnQgETy7AMSLPLl+DMahFFw9mkb3fL7Itj5c+08wxhvNvFmY+uwC7CLMWcHloV4qQL7mMasttIhQUiE5AK5PKQi4L4NPbETcAwJG58SAbvVH6RzafMJ3ARDf04DFg6pP+oz/+yjOO9yVrvwO49iGig2cRPXcLvWbIF3IfVeO2Kez0gkkMcHTEDzQMOicHkJjcUM1aSu5CGDvI65D4GlrJvz/c27NSKYQAEZn0oiUPWQURm9I6uQfSWrZrosFHIk+QlkPCE+8wkafyGhcAmkXU3TVITg63p6AqqRGSgzVjLjRmbcSrfOvxp/hakayRhvLYuup9E3f2O7jsR5gz9abawjwOpHfML3ML4dlwFpF74eRfYkHRxWXK0+qZbdVXLhBaO0y0ObhqYcebS0dtMcCUmH9de0X391EL8yodR/ylOMwktK7Be+NxoYhS7pH8CIvFfWFSPXWzZ31YfxDHPf4VYktHvMqcaC4E51QGWHDCgoS0Zi9cEDdNuJQC2M+7dX0S/B6uqOreLJSN2/M1NSZvRy0Sjsg4ZAoqI8Y5R6ywfAdI/D9DvG5d5yHDN5FFr0J/98DJnYqjKZ1rj33PkJJAVizVXySk2BV+Hf+Saq+E0KeaU+JSr8MLIDKFTmyzOVolNZgGZKTiq9YqrcvLIxfakJEJ4WSEuBGtMCzadAzWmBSilQ63+11p4WKJ8CbU4LpANQDn4ec7i+CQ825rqce10WaEtN3GjV8Va9gVEDb2Ns298BQ0bqxQEHAAA=""
-----------------------------7e4199331068c
Content-Disposition: form-data; name=""__VIEWSTATE""

-----------------------------7e4199331068c
Content-Disposition: form-data; name=""_ctl0:fileUploaderCheck""; filename=""""
Content-Type: application/octet-stream

-----------------------------7e4199331068c
Content-Disposition: form-data; name=""__BarCodesEntryFromKBD""

-----------------------------7e4199331068c
Content-Disposition: form-data; name=""_ctl0:cmdSave""

Išsaugoti
-----------------------------7e4199331068c
Content-Disposition: form-data; name=""__LastFocusedElement""

_ctl0_cmdSave
-----------------------------7e4199331068c
Content-Disposition: form-data; name=""__ScrollTop""

252
-----------------------------7e4199331068c
Content-Disposition: form-data; name=""__ScrollLeft""

0
-----------------------------7e4199331068c
Content-Disposition: form-data; name=""__ValidationSummaryDisplay""

none
-----------------------------7e4199331068c--
";

            request = (HttpWebRequest)WebRequest.Create(url2);
            byte[] byteArray = Encoding.UTF8.GetBytes(postdata);
            request.Method = "POST";
            request.KeepAlive = true; request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Credentials = Form1.MyCash; //new NetworkCredential("audriussi", "post*111");
            request.CookieContainer = cookes;
            request.Host = "bkisnew:83";
            request.AllowAutoRedirect = true;
            request.MaximumAutomaticRedirections = 1;
            request.Referer = Url;
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                HTMLPage = stream.ReadToEnd();
                stream.Close();
            }

            return HTMLPage;
        }
    }
}

