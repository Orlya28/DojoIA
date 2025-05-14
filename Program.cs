using dotenv.net;
using System;

DotEnv.Load();
string? apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

if (string.IsNullOrEmpty(apiKey))
{
    Console.WriteLine("❌ Clé API manquante. Vérifie ton fichier .env");
    return;
}

var client = new OpenAIClient(apiKey);

Console.WriteLine("Entrez votre texte à corriger ou traduire :");
string inputText = Console.ReadLine();

if (string.IsNullOrWhiteSpace(inputText))
{
    Console.WriteLine("❌ Texte vide !");
    return;
}

Console.WriteLine("\nChoisissez une option :");
Console.WriteLine("1. Correction");
Console.WriteLine("2. Traduction (anglais US)");
Console.WriteLine("3. Traduction (anglais UK)");

string option = Console.ReadLine();
string prompt = option switch
{
    "1" => $"Corrige les fautes d’orthographe et de grammaire : {inputText}",
    "2" => $"Traduis ce texte en anglais américain : {inputText}",
    "3" => $"Traduis ce texte en anglais britannique : {inputText}",
    _ => ""
};

if (string.IsNullOrEmpty(prompt))
{
    Console.WriteLine("❌ Option invalide.");
    return;
}

string response = await client.SendRequest(prompt);

Console.WriteLine("\n✅ Réponse de l'IA :");
Console.WriteLine(response);

HtmlGenerator.Generate(response);
