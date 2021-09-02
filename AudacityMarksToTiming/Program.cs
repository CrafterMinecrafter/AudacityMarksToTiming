using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static void Main(string[] MyFile)
    {
        if (MyFile == null)
        {
            Console.WriteLine("pls put file with AudacityMarks in exe");
            return;
        }

        string directoryName = Path.GetDirectoryName(MyFile[0]);
        string[] dataLines = File.ReadAllLines(MyFile[0]);

        List<AudacityMark> audacityMarksList = new List<AudacityMark>();
        foreach (string data in dataLines)
        {
            audacityMarksList.Add(new AudacityMark(data));
        }

        string[] contents = ACMarksToOsuTiming(audacityMarksList.ToArray());
        File.WriteAllLines(Path.Combine(directoryName, "Timing.txt"), contents);
    }

    public static string[] ACMarksToOsuTiming(AudacityMark[] marks)
    {
        List<string> list = new List<string>();
        foreach (AudacityMark audacityMark in marks)
        {
            list.Add($"{audacityMark.StartMS},{audacityMark.intervalMS * 2},1,2,100,100,1,0");
        }
        return list.ToArray();
    }
}
