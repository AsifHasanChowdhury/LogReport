using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

string logFile = File.ReadAllText("C:\\Users\\SECL\\Downloads\\logs\\20221019-All.log.0");
//string value = "2022-10-19 08:34:28.5931 [DEBUG] - [Thread:62  ] - [== == Inside UIServices.getMenuByPageName method. pageName:home|lid:74182761amandai]";
//string pattern = @"{4}-{2}-{2}\s{2}:{2}:{2}.{4}\s[A-Z\s?]\s-\s[A-Z|a-z:{1,2}\s?";
//string lidPattern=@" pageName:[A-z]*\|lid:\d{1,}";
//List<Tuple<Match, List<string> >> TupleMatch = new List<Tuple<Match, List<string>>>();
//List <String> idList=new List<String> ();


string lidPatternPage = @"pageName:[A-z]*\|lid:\d{1,}";

string pattern = @"\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}.\d{4}\s\[[A-Z]*\]\s-\s\[Thread:\d{1,3}\s*?\]\s?-\s?[==\s==\s^[A-z]*\s[A-z]*.[A-z]*\s[A-z]*.\s?[A-z]*:[A-z]*\|lid:\d{1,}[A-z]+\]";

string lidPattern = @"lid:\d{1,}";

string FinalPage = @"\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}.\d{4}\s\[[A-Z]*\]\s-\s\[Thread:\d{1,3}\s*?\]\s?-\s?[==\s==\s^[A-z]*\s[A-z]*.[A-z]*\s[A-z]*.\s?[A-z]*:[A-z]*\|";

MatchCollection matches = Regex.Matches(logFile, pattern);

MatchCollection LidPageMatchList = Regex.Matches(logFile, lidPatternPage);

IDictionary <String,List<Match>> Mapped=new Dictionary<String,List<Match>> ();

foreach (Match match in matches)
{
   Match id = Regex.Match(match.Value, lidPattern);
   
    if (!Mapped.ContainsKey(id.Value))
    {
        Mapped.Add(id.Value.ToString(), new List<Match>());
    }
}



foreach (var match in Mapped)
{

   // foreach( var match2 in )

    //if(Regex.IsMatch())
    Console.WriteLine(match.Key);
}



//int count = 0;
//foreach (Match match in LidPageMatchList)
//{
//    if (!UserTrackList.ContainsKey(match))
//    {
//        count += 1;
//        UserTrackList.Add(match, new List<string>());
//    }
//}

//foreach (var item in UserTrackList)
//{
//    Console.WriteLine(item.Key + " Key & Value " + item.Value);
//}



//UserTrackList.Add(match1, test);

//foreach (var val in UserTrackList)
//{
//    Console.Write(val.Key);

//    Console.Write("[ ");
//    foreach (var val2 in val.Value)
//    {
//        Console.Write(" value pair "+ val2 +" ,");
//    }
//    Console.WriteLine(" ]");
//}
//Console.WriteLine(UserTrackList.Values);

