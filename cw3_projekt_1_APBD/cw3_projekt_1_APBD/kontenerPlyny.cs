namespace cw3_projekt_1_APBD;

public class kontenerPlyny : Kontener,IHazardNotifier
{
    protected bool isSafe;
    private string nazwaLadunku;
    public kontenerPlyny(string nazwaLadunku,bool isSafe) : base(typKonteneru.L)
    {
        this.nazwaLadunku = nazwaLadunku;
        this.isSafe = isSafe;
        wagaKontenera = 2200;
        pojemnoscKontenera = 8000;
    }

    public kontenerPlyny(string nazwaLadunku) : base(typKonteneru.L)
    {
        this.nazwaLadunku = nazwaLadunku;
        isSafe = true;
        wagaKontenera = 2200;
        pojemnoscKontenera = 8000;
    }

    public void Notify()
    {
        Console.WriteLine($"Zachodzi niebezpieczna sytuacja. Proszę uważać. Numer kontenera: {numerSeryjny}");
    }

    public override void OproznianieLadunku()
    {
        wagaKontenera = 2200;
        pojemnoscKontenera = 8000;  
        masaLadunku = 0;
        
    }
    
    public override void ZaladowanieLadunku(double ladunek)
    {
        try
        {        
            if (!isSafe)
            {
                pojemnoscKontenera *= 0.5;
                if (wagaKontenera + ladunek <= pojemnoscKontenera)
                {
                    Notify();
                    Console.WriteLine("Zaladowano pomyślnie");
                    wagaKontenera += ladunek;
                    masaLadunku = ladunek;
                    Console.WriteLine($"\tAktualna waga kontera wraz z ladunkiem wynosi: {wagaKontenera}kg");
                }
                else
                {
                    masaLadunku = ladunek;
                    throw new OverfillException($"Przekroczono pojemność kontenera! Numer kontenera: {numerSeryjny}");
                }
            }
            else
            {
                pojemnoscKontenera *= 0.9;
                if (pojemnoscKontenera < ladunek)
                {
                    Notify();
                    throw new OverfillException($"Przekroczono pojemność kontenera! Numer kontenera: {numerSeryjny}");
                }
                wagaKontenera += ladunek;
                masaLadunku = ladunek;
                Console.WriteLine($"Kontener: {numerSeryjny} \n\tAktualna waga kontera wraz z ladunkiem wynosi: {wagaKontenera}kg");
            }
        }
        catch (OverfillException e)
        {
            Console.WriteLine($"Błąd: {e.Message}");
        }
    }

    public override string ToString()
    {
        return base.ToString()+
               $"\n\tPrzewozony LaduneK: {nazwaLadunku}";
    }
}