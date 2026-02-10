public class Activity
{
    private string _date;
    private int _length;

    public Activity(string date, int length)
    {
        _date = date;
        _length = length;
    }

    public string GetDate()
    {
        return _date;
    }

    public int GetLength()
    {
        return _length;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public string GetSummary()
    {
        return  $"{_date} {GetType().Name} ({_length} min) - " +
                $"Distance: {GetDistance():0.0} km, " +
                $"Speed: {GetSpeed():0.0} kph, " +
                $"Pace: {GetPace():0.0} min per km";
    }
}