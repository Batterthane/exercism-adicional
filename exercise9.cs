// Exercism practica 9 Isandel Abreu

//Need for Speed 

using System;

class RemoteControlCar
{
    private readonly int _speedInMps;
    private readonly int _batteryDrain;

    private int _distanceDriven;
    private int _batteryPercentage = 100;

    public RemoteControlCar(int speedInMps, int batteryDrain)
    {
        _speedInMps = speedInMps;
        _batteryDrain = batteryDrain;
    }

    public bool BatteryDrained() => _batteryPercentage < _batteryDrain || _batteryPercentage == 0;

    public int DistanceDriven() => _distanceDriven;

    public void Drive()
    {
        if (!BatteryDrained())
        {
            _distanceDriven += _speedInMps;
            _batteryPercentage -= _batteryDrain;
        }
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);
}

class RaceTrack
{
    private readonly int _distanceInMetres;

    public RaceTrack(int distanceInMetres) =>
        _distanceInMetres = distanceInMetres;

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained())
        {
            car.Drive();
        }

        return car.DistanceDriven() >= _distanceInMetres;
    }
}