using dotenv.net;
using System;

DotEnv.Load();
string? apiKey = ("OPENAI_API_KEY");

if (string.IsNullOrEmpty(apiKey))
{
    Console.WriteLine("");
    return;
}

var client = new OpenAIClient(apiKey);

Console.WriteLine("Enter your text (in French):");
string inputText = Console.ReadLine();

if (string.IsNullOrWhiteSpace(inputText))
{
    Console.WriteLine(" Text cannot be empty.");
    return;
}

Console.WriteLine("\nChoose an option:");
Console.WriteLine("1. Correct grammar and spelling");
Console.WriteLine("2. Translate to American English");
Console.WriteLine("3. Translate to British English");

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
    Console.WriteLine(" Invalid option.");
    return;
}

string response = await client.SendRequest(prompt);

Console.WriteLine("\n✅ AI Response:");
Console.WriteLine(response);

HtmlGenerator.Generate(response);
