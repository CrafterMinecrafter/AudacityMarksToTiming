using System;
public class AudacityMark
{
    public AudacityMark(string data)
    {
        string[] parsed_data = data.Replace('.', ',').Replace('\t', ' ').Split(new char[]
        {
            ' '
        });
        StartMS = Convert.ToInt32(double.Parse(parsed_data[0]) * 1000.0);

        EndMS = Convert.ToInt32(double.Parse(parsed_data[1]) * 1000.0);
    }

    public int intervalMS
    {
        get => EndMS - StartMS;
    }

    public int StartMS;

    public int EndMS;
}
