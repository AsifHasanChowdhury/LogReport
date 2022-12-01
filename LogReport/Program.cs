// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

string logFile = File.ReadAllText("C:\\Users\\shima\\Downloads\\logs\\20221019-All.log.0");
string value = "2022-10-19 08:34:28.5931 [DEBUG] - [Thread:62  ] - [== == Inside UIServices.getMenuByPageName method. pageName:home|lid:74182761amandai]";
//string pattern = @"{4}-{2}-{2}\s{2}:{2}:{2}.{4}\s[A-Z\s?]\s-\s[A-Z|a-z:{1,2}\s?";

string pattern = @"\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}.\d{4}\s\[[A-Z]*\]\s-\s\[Thread:\d{1,3}\s*?\]\s?-\s?[==\s==\s^[A-z]*\s[A-z]*.[A-z]*\s[A-z]*.\s?[A-z]*:[A-z]*\|lid:\d{1,}[A-z]+\]";
//string pattern = @" pageName:[A-z]*\|lid:\d{1,}";
MatchCollection matches = Regex.Matches(logFile, pattern);
var count1 = 0;
foreach (Match match in matches)
{
    count1 += 1;
    Console.WriteLine(match.Value);
}
Console.WriteLine(count1);
//Console.WriteLine(logFile); 