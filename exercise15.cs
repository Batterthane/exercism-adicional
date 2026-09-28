// Exercism practica 15 Isandel Abreu

//The Weather in Deather

using System;
using System.Collections.Generic;
using Xunit.Sdk;

public class WeatherStation
{
    private Reading _reading;
    private readonly List<DateTime> _recordDates = new();
    private readonly List<decimal> _temperatures = new();

    public void AcceptReading(Reading reading)
    {
        _reading = reading;
        _recordDates.Add(DateTime.Now);
        _temperatures.Add(reading.Temperature);
    }

    public void ClearAll()
    {
        _reading = new Reading();
        _recordDates.Clear();
        _temperatures.Clear();
    }

    public decimal LatestTemperature => _reading.Temperature;

    public decimal LatestPressure => _reading.Pressure;

    public decimal LatestRainfall => _reading.Rainfall;

    public bool HasHistory => _recordDates.Count > 1;

    public Outlook ShortTermOutlook
    {
        get
        {
            if (_reading.Equals(new Reading())) throw new ArgumentException();

            return _reading.Pressure switch
            { 
                < 10m when _reading.Temperature < 30m => Outlook.Cool,
                _ => _reading.Temperature switch
                {
                    > 50 => Outlook.Good,
                    _ => Outlook.Warm
                }
            };
        }
    }

    public Outlook LongTermOutlook =>
        _reading switch
        {
            { WindDirection: WindDirection.Southerly } or { WindDirection: WindDirection.Easterly, Temperature: > 20 } => Outlook.Good,
            { WindDirection: WindDirection.Northerly } => Outlook.Cool,
            { WindDirection: WindDirection.Easterly, Temperature: <= 20 } => Outlook.Warm,
            { WindDirection: WindDirection.Westerly } => Outlook.Rainy,
            _ => throw new ArgumentException()
        };

    public State RunSelfTest() => _reading.Equals(new Reading()) ? State.Bad : State.Good;
}

public struct Reading
{
    public decimal Temperature { get; }
    public decimal Pressure { get; }
    public decimal Rainfall { get; }
    public WindDirection WindDirection { get; }

    public Reading(decimal temperature, decimal pressure,
        decimal rainfall, WindDirection windDirection)
    {
        Temperature = temperature;
        Pressure = pressure;
        Rainfall = rainfall;
        WindDirection = windDirection;
    }
}

public enum State
{
    Good,
    Bad
}

public enum Outlook
{
    Cool,
    Rainy,
    Warm,
    Good
}


public enum WindDirection
{
    Unknown = 0,    
    Northerly,
    Easterly,
    Southerly,
    Westerly
}

class Program
{
    static void Main()
    {
        WeatherStation station = new WeatherStation();

        Reading reading = new Reading(
            25m,
            8m,
            2m,
            WindDirection.Southerly);

        station.AcceptReading(reading);

        Console.WriteLine("Latest temperature: " + station.LatestTemperature);
        Console.WriteLine("Latest pressure: " + station.LatestPressure);
        Console.WriteLine("Latest rainfall: " + station.LatestRainfall);
        Console.WriteLine("Has history: " + station.HasHistory);
        Console.WriteLine("Short term outlook: " + station.ShortTermOutlook);
        Console.WriteLine("Long term outlook: " + station.LongTermOutlook);
        Console.WriteLine("Self test: " + station.RunSelfTest());

        station.AcceptReading(
            new Reading(
                55m,
                12m,
                0m,
                WindDirection.Westerly));

        Console.WriteLine("Has history after second reading: " + station.HasHistory);
        Console.WriteLine("Latest temperature: " + station.LatestTemperature);
    }
}