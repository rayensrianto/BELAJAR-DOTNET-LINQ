using System;

class Program
{
    static void Main(string[] args)
    {
        string sentence = "Ryan Ganteng Banget Deh!";

        int wordCount = sentence.GetWordCount();
        Console.WriteLine(wordCount);
    }
}

public static class ExtensionHelper
{
    public static int GetWordCount(this string str)
    {
        if (!String.IsNullOrEmpty(str))
            return str.Split(' ').Length;

        return 0;
    }
}