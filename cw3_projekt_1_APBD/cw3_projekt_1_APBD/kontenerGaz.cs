namespace cw3_projekt_1_APBD;

public class kontenerGaz : Kontener,IHazardNotifier
{
    private double cisnienie{get;set;}
    private gazyKontenerGazowy gazyKontenerGazowy { get; set; }
    
    public kontenerGaz(gazyKontenerGazowy gazyKontenerGazowy,double cisnienie) : base(typKonteneru.G)
    {
        this.gazyKontenerGazowy = gazyKontenerGazowy;
        this.cisnienie = cisnienie;
        wagaKontenera = 2000;
        pojemnoscKontenera = 5000;
    }
    
    //Jesli w konstruktorze nie zostanie podana liczba jakie jest cisnienie to default'owo zostanie dane 3000
    public kontenerGaz(gazyKontenerGazowy gazyKontenerGazowy) : base(typKonteneru.G)
    {
        this.gazyKontenerGazowy = gazyKontenerGazowy;
        this.cisnienie = 3000;
        wagaKontenera = 2000;
        pojemnoscKontenera = 5000;
    }
    
    public kontenerGaz() : base(typKonteneru.G)
    {
        gazyKontenerGazowy = randomGazowy();
        this.cisnienie = 3000;
        wagaKontenera = 2000;
        pojemnoscKontenera = 5000;
    }
    
    
    public override void OproznianieLadunku()
    {
        wagaKontenera -= masaLadunku;
        masaLadunku *= 0.05;
    }

    public override void ZaladowanieLadunku(double ladunek)
    {
        try
        {
            Notify();
            if (pojemnoscKontenera < ladunek)
            {
                masaLadunku = ladunek;
                throw new OverfillException($"Przekroczono pojemność kontenera! Numer kontenera: {numerSeryjny}");
            }
            wagaKontenera += ladunek;
            masaLadunku = ladunek;
            Console.WriteLine($"\tAktualna waga kontera wraz z ladunkiem wynosi: {wagaKontenera}kg");
        }
        catch (OverfillException e)
        {
            Console.WriteLine($"Błąd: {e.Message}");
        }
    }

    public void Notify()
    {
        Console.WriteLine($"Zachodzi niebezpieczna sytuacja. Proszę uważać. Numer kontenera: {numerSeryjny}");
    }

    public override string ToString()
    {
        return base.ToString()+
               $"\n\tPrzewozony Gaz: {gazyKontenerGazowy}" +
               $"\n\tCisnienie: {cisnienie}";
    }
    
    public override gazyKontenerGazowy randomGazowy()
    {
        Random random = new Random();
        int i = random.Next(0, 10);
        switch (i)
        {
            case 0: return gazyKontenerGazowy.Amoniak;
            case 1: return gazyKontenerGazowy.Chlor;
            case 2: return gazyKontenerGazowy.LNG;
            case 3: return gazyKontenerGazowy.Tlen;
            case 4: return gazyKontenerGazowy.Wodor;
            case 5: return gazyKontenerGazowy.LEG;
            case 6: return gazyKontenerGazowy.LPG;
        }   
        return gazyKontenerGazowy.Amoniak;
    }
}