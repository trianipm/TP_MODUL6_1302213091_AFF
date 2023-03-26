// See https://aka.ms/new-console-template for more information
using System;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    // Konstruktor
    public SayaTubeVideo(string title)
    {
        if (title == null || title.Length > 100)
            throw new ArgumentException("Judul video tidak valid.");

        this.id = new Random().Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    // Method untuk menambah jumlah playCount
    public void IncreasePlayCount(int count)
    {
        if (count > 10000000)
            throw new ArgumentException("Jumlah penambahan play count melebihi batas maksimum.");

        checked
        {
            this.playCount += count;
        }
    }

    // Method untuk mencetak detail video
    public void PrintVideoDetails()
    {
        Console.WriteLine("ID Video: " + this.id);
        Console.WriteLine("Judul Video: " + this.title);
        Console.WriteLine("Jumlah Play: " + this.playCount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Membuat video baru
        SayaTubeVideo video = null;
        try
        {
            video = new SayaTubeVideo("Tutorial Design By Contract - [Triani Putri Mumpuni]");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        // Memanggil method IncreasePlayCount sebanyak 20 kali
        for (int i = 0; i < 20; i++)
        {
            try
            {
                video.IncreasePlayCount(500000);
                video.PrintVideoDetails();
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException: Jumlah Play melebihi batas.");
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                break;
            }
        }

        Console.ReadKey();
    }
}
