using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;

public class Crawler 
{ 
    private Hashtable urls = new Hashtable();
    private int count = 0;
    public string site { get; set; }

    static void Main(string[] args) { 
        Crawler myCrawler = new Crawler();

        string startUrl = "http://www.cnblogs.com/dstang2000/";
        if(args.Length>=1)startUrl = args[0];

        myCrawler.urls.Add(startUrl, false);//加入初始页面

        new Thread(myCrawler.Crawl).Start();//开始爬行
    }

    private void Crawl() 
    {
        Console.WriteLine("开始爬行了...");
        while (true) 
        {
            string current = null;
            foreach (string url in urls.Keys)
            {
                if ((bool)urls[url]) continue;
                current = url;
            }
            if (current == null||count>10) break;
            
            Console.WriteLine("爬行"+current+"页面！");

            string html = Download(current);//下载

            urls[current] = true;
            count++;

            Parse(html,current);
        }
        Console.WriteLine("爬行结束");
    }

    public string Download(string url) 
    {
        try
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string html = wc.DownloadString(url);

            string fileName = count.ToString();
            File.WriteAllText(fileName, html, Encoding.UTF8);
            return html;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return "";
        }
    }

    public void Parse(string html,string currentUrl)
    {
        string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
        MatchCollection matches = new Regex(strRef).Matches(html);
        foreach (Match match in matches)
        { 
            strRef = match.Value.Substring(match.Value.IndexOf('=')+1).Trim('"','\"','#',' ','>');

            if (!Regex.IsMatch(strRef, @"(http|HTTP)"))
            {
                Uri origin = new Uri(currentUrl);
                Uri absolute = new Uri(origin, strRef);
                strRef = absolute.ToString();
            }//相对地址转绝对地址

            if (!isAPage(strRef)) continue;
            //判断爬取的是网页

            site = GetDomainName(strRef);
            if (!strRef.Contains(site)) continue;
            //判断只爬取指定网站

            if (strRef.Length == 0) continue;
            if (urls[strRef] == null) urls[strRef] = false;
        }
    }
    private bool isAPage(string url)
    {
        if (url.IndexOf('?') > 0) url = url.Substring(0, url.IndexOf('?'));
        if (Regex.IsMatch(url, @"\.(html|hml|aspx|jsp)")) return true;
        if (Regex.IsMatch(url, @"/[^.]+$")) return true;
        if (url.EndsWith("/")) return true;
        return false;
    }
    public static string GetDomainName(string url)
    {
        string result = url;
        if (result.IndexOf("http://") > -1)
        {
            result = result.Replace("http://", string.Empty);
        }
        else if (result.IndexOf("https://") > -1)
        {
            result = result.Replace("https://", string.Empty);
        }
        result = result.Replace("/", string.Empty);
        if (result.IndexOf('/') > 0) return result.Substring(0, result.IndexOf('/'));
        else return result;
    }
}

