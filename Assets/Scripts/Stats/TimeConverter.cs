using UnityEngine;
using System;

// Converts total seconds into hours and or minutes
public class TimeConverter : MonoBehaviour
{
    public static string HoursMinutes(float totalSeconds)
    {
        int hours = TimeSpan.FromSeconds(totalSeconds).Hours;
        int minutes = TimeSpan.FromSeconds(totalSeconds).Minutes;

        string time = (hours.ToString() + "h:") + (minutes.ToString() + "m");
        return time;
    }

    public static string MinutesSeconds(float totalSeconds)
    {
        int minutes = TimeSpan.FromSeconds(totalSeconds).Minutes;
        int seconds = TimeSpan.FromSeconds(totalSeconds).Seconds;

        string time = (minutes.ToString() + "m:") + (seconds.ToString() + "s");
        return time;
    }
}