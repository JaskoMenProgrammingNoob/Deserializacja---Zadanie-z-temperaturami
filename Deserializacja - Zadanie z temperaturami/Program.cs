using System.IO;
using System.Text.Json;
class Temperatury
{
    double[] pomiary = [18.5, 20.2, 17.8, 21.4, 23.1, 19.7, 22.6];
    double srednia_temperatur;
    double suma_temperatur = 0;


    public void przetworz_i_odczytaj_dane()
    {
        for(int i = 0; i < pomiary.Length; i++)
        {
            Console.Write(pomiary[i] + " ");
        }
        Console.WriteLine();
        string zaszyfruj_pomiar = JsonSerializer.Serialize(pomiary);
        File.WriteAllText("temperatury.txt", zaszyfruj_pomiar);
        string odczytaj_pomiar = File.ReadAllText("temperatury.txt");
        pomiary = JsonSerializer.Deserialize<double[]>(odczytaj_pomiar);
        for (int i = 0; i < pomiary.Length; i++)
        {
            suma_temperatur += pomiary[i];
        }
        Console.WriteLine();
        srednia_temperatur = suma_temperatur / pomiary.Length;
        Console.Write("Średnia temperatura wynosi: ");
        Console.Write($"{srednia_temperatur:F2}");


    }




    static void Main(string[] args)
    {
        Temperatury temperatury = new Temperatury();
        temperatury.przetworz_i_odczytaj_dane();

    }
}
