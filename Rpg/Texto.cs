using System;

namespace Jogo_de_RPG;

public static class Text
{
    public static string Message(string text)
    {
        Console.WriteLine(text);
        return text;
    }
    
    public static string Info(string text)
    {
        Console.Write(text);
        return text;
    }
    
    public static string Lead()
    {
        return Console.ReadLine();
    }
}