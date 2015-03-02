using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


static class TestCase
{
    private static StreamReader reader;
    private static StreamReader outputReader;
    private static string file, outputFile;
    private static bool correct = true;
    private static int writeIndex = 0;
    private static char[] currentLine;

    /// <summary>
    /// Load a testcase with this function
    /// </summary>
    /// <param name="fileName"></param>
    public static void Load(string fileName)
    {
        outputFile = fileName.Replace(".in", ".uit");
        file = fileName;
        reader = new StreamReader("TestCases/" + file);
        try
        {
            outputReader = new StreamReader("TestCases/" + outputFile);
        }
        catch { Console.WriteLine("Output file not found"); }
    }

    /// <summary>
    /// Use this were you would normally use Console.ReadLine()
    /// </summary>
    /// <returns></returns>
    public static string ReadLine()
    {
        try
        {
            return reader.ReadLine();
        }
        catch { return null; }
    }

    /// <summary>
    /// Use this were you would normally use Console.WriteLine(). Automagically tests if your answer is correct.
    /// </summary>
    /// <param name="answer"></param>
    public static void WriteLine(object answer)
    {
        writeIndex = 0;
        string[] lines = answer.ToString().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        for (int i = 0; i < lines.Length; i++)
        {
            string correctAnswer = outputReader.ReadLine();

            currentLine = correctAnswer.ToCharArray();
            if (lines[i] == correctAnswer)
            {
                Console.WriteLine(lines[i]);
            }
            else
            {
                Console.WriteLine(lines[i] + " INCORRECT ANSWER. CORRECT ANSWER: " + correctAnswer);
                correct = false;
            }
        }
    }

    public static void Write(object answer)
    {
        char[] ans = answer.ToString().ToCharArray();
        bool correct = true;
        if (writeIndex == 0)
        {
            currentLine = outputReader.ReadLine().ToCharArray();
        }
        for (int i = 0; i < ans.Length; i++)
        {
            if (writeIndex >= currentLine.Length)
            {
                return;
            }
            if (ans[i] != currentLine[writeIndex])
                correct = false;
            Console.Write(ans[i]);
            writeIndex++;
        }
        if (!correct)
            Console.Write(" (False) ");
    }

    public static void WriteLine(int? answer)
    {
        WriteLine(answer.ToString());
    }

    public static bool Correct
    {
        get { return correct; }
    }
}
