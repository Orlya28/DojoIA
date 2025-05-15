using System.IO;

public class HtmlGenerator
{
    public static void Generate(string text, string filePath = "output.html")
    {
        string html = $@"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <title>AI Text</title>
</head>
<body>
    <h1>Result</h1>
    <p>{text}</p>
</body>
</html>";

        File.WriteAllText(filePath, html);
        Console.WriteLine($"\n HTML file generated: {filePath}");
    }
}
