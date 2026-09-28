// Exercism practica 6 Isandel Abreu

//Bird Watcher 

using System.Linq;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay) => this.birdsPerDay = birdsPerDay;

    public static int[] LastWeek() => new[] {0, 2, 5, 3, 7, 8, 4};

    public int Today() => birdsPerDay.Last();

    public void IncrementTodaysCount()
    {
        birdsPerDay[^1]++;
    }

    public bool HasDayWithoutBirds() => birdsPerDay.Contains(0);

    public int CountForFirstDays(int numberOfDays) => birdsPerDay.Take(numberOfDays).Sum();

    public int BusyDays() => birdsPerDay.Count(day => day >= 5);
}

class Program
{
    static void Main()
    {
        int[] birds = { 2, 5, 0, 3, 7, 8, 4 };

        BirdCount birdCount = new BirdCount(birds);

        Console.WriteLine("Pájaros de hoy: " + birdCount.Today());

        birdCount.IncrementTodaysCount();
        Console.WriteLine("Después de incrementar: " + birdCount.Today());

        Console.WriteLine("¿Hay un día sin pájaros?: " + birdCount.HasDayWithoutBirds());

        Console.WriteLine("Pájaros en los primeros 3 días: " + birdCount.CountForFirstDays(3));

        Console.WriteLine("Días ocupados: " + birdCount.BusyDays());

        Console.ReadKey();
    }
}