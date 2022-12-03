using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

public class Program
{


    static string lidPatternPage = @"pageName:[A-z]*";

    static string pattern = @"\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}.\d{4}\s\[[A-Z]*\]\s-\s\[Thread:\d{1,3}\s*?\]\s?-\s?[==\s==\s^[A-z]*\s[A-z]*.[A-z]*\s[A-z]*.\s?[A-z]*:[A-z]*\|lid:\d{1,}[A-z]+\]";

    static string lidPattern = @"lid:\d{1,}";

    static string FinalPage = @"\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}.\d{4}\s\[[A-Z]*\]\s-\s\[Thread:\d{1,3}\s*?\]\s?-\s?[==\s==\s^[A-z]*\s[A-z]*.[A-z]*\s[A-z]*.\s?[A-z]*:[A-z]*\|";

    //MatchCollection matches = Regex.Matches(logFile, pattern);

    static IDictionary<String, List<Match>> Mapped = new Dictionary<String, List<Match>>();

    static IDictionary<String, List<Match>> MappedPage = new Dictionary<String, List<Match>>();



    public static void ReadLog()
    {
            var filePaths = Directory
            .EnumerateFiles(@"C:\Users\shima\Downloads\logs\")
            .Where(f => f.EndsWith("All.log.0"));
        
            foreach (var file in filePaths)
            {
                MatchCollection matches = Regex
                .Matches(File.ReadAllText(file.ToString()), pattern);

            FindUserTrace((Dictionary<string, List<Match>>)MappedPage,
                          (Dictionary<String, List<Match>>)Mapped,
                          lidPatternPage,
                          FinalPage,
                          lidPattern,
                          matches);




        }
        //Console.WriteLine(filePaths);
    }



    public static void PrintDetail(Dictionary <String, List<Match>> MappedPage) {

        Console.WriteLine("========================================================");

        Console.WriteLine("Total Number of Unique Users " + MappedPage.Keys.Count());

        Console.WriteLine("========================================================");

        Console.WriteLine("Every Unique Users Page to Page Movement Track Details");

        


        foreach (var val in MappedPage)
        {
            Console.Write(val.Key);

            Console.Write("[");
            foreach (var val2 in val.Value)
            {
                Console.Write(" " + val2 + "=>");
            }
            Console.WriteLine("]");
        }

       
    }



    public static void FindUserTrace(
        Dictionary<String, List<Match>> MappedPage,
        Dictionary<String, List<Match>> Mapped,
        string lidPatternPage, 
        string FinalPage,
        string lidPattern,
        MatchCollection matches)

    {
        foreach (Match match in matches)
        {
            Match id = Regex.Match(match.Value, lidPattern);


            if (!Mapped.ContainsKey(id.Value))
            {
                List<Match> pagelist = new List<Match>();

                List<Match> page = new List<Match>();

                Mapped.Add(id.Value.ToString(), pagelist);

                MappedPage.Add(id.Value.ToString(), page);
            }

            if (Regex.IsMatch(match.Value, id.Value))
            {
                Match pageDetail = Regex.Match(match.Value, FinalPage);

                Match page = Regex.Match(match.Value, lidPatternPage);


                Mapped[id.Value.ToString()].Add(pageDetail);

                MappedPage[id.Value.ToString()].Add(page);
            }

        }

    }



    public static void Main(String[] args)
    {

      //  string logFile = File.ReadAllText("C:\\Users\\shima\\Downloads\\logs\\20221019-All.log.0");




        //FindUserTrace ((Dictionary<string, List<Match>>)MappedPage,
        //              (Dictionary<String, List<Match>>)Mapped,
        //              lidPatternPage,
        //              FinalPage,
        //              lidPattern,
        //              matches);

        //PrintDetail((Dictionary<string, List<Match>>)MappedPage);

        ReadLog();
        PrintDetail((Dictionary<string, List<Match>>)MappedPage);


    }
}