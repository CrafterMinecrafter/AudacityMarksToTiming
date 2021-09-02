using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static void Main(string[] MyFiles)
    {
        if (MyFiles == null)
        {
            Console.WriteLine("pls put file with AudacityMarks in exe");
            Console.ReadLine();
            return;
        }

        string directoryName = Path.GetDirectoryName(MyFiles[0]);
        string[] dataLines = File.ReadAllLines(MyFiles[0]);

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
