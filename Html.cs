using System.IO;

public class HtmlGenerator
{
    public static void Generate(string text, string filePath = "output.html")
    {
        string html = $@"
<!DOCTYPE html>
<html lang='fr'>
<head>
    <meta charset='UTF-8'>
    <title>Texte IA</title>
</head>
<body>
    <h1>Résultat</h1>
    <p>{text}</p>
</body>
</html>";

        File.WriteAllText(filePath, html);
        Console.WriteLine($"\n Fichier HTML généré : {filePath}");
    }
}
