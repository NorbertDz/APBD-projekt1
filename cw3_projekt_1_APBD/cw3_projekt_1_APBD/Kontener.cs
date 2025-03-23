using static cw3_projekt_1_APBD.typKonteneru;

namespace cw3_projekt_1_APBD;

public class Kontener
{
    //parametry wagowe kontenera
    protected double masaLadunku { get; set; }
    protected double wagaKontenera { get; set; }
    protected double pojemnoscKontenera { get; set; }
    
    //numer seryjny kontenera
    protected string numerSeryjny { get; set; }
    
    //wymiary
    protected int glebokosc { get; set; } = 20;
    protected int wysokosc { get; set; } = 4;
    
    //typy kontenerow
    private typKonteneru typKonteneru { get; set; }
    private static int typeC = 1;
    private static int typeL = 1;
    private static int typeG = 1;
    private int typeNumber;

    public Kontener(typKonteneru typKonteneru)
    {
        this.typKonteneru = typKonteneru;
        setKontener();
        numerSeryjny = $"KON-{this.typKonteneru}-{typeNumber}";
        Console.WriteLine($"Nowy kontener: {numerSeryjny}");
        pojemnoscKontenera = 0;
    }

    public string getNumerSeryjny()
    {
        return numerSeryjny;
    }

    private void setKontener()
    {
        switch (typKonteneru)
        {
            case typKonteneru.C:
                typeNumber = typeC++;
                break;
            case typKonteneru.L:
                typeNumber = typeL++;
                break;
            case typKonteneru.G:
                typeNumber = typeG++;
                break;
        }
    }

    public virtual void OproznianieLadunku()
    {
        masaLadunku = 0;
    }

    public virtual void ZaladowanieLadunku(double ladunek)
    {
        try
        {
            if (pojemnoscKontenera < ladunek)
                throw new OverfillException($"Przekroczono pojemność kontenera! Numer kontenera: {numerSeryjny}");
            wagaKontenera += ladunek;
            Console.WriteLine($"\tAktualna waga kontera wraz z ladunkiem wynosi: {wagaKontenera}kg");
        }
        catch (OverfillException e)
        {
            Console.WriteLine($"Błąd: {e.Message}");
        }
    }

    public static int getTypeC()
    {
        return typeC;
    }
    public static int getTypeL()
    {
        return typeL;
    }
    public static int getTypeG()
    {
        return typeG;
    }

    public override string ToString()
    {
        return $"=============Informacje dotyczace {numerSeryjny}=============" +
               $"\n\tMasa ladunku: {masaLadunku}kg" +
               $"\n\tMasa kontenera: {wagaKontenera}kg" +
               $"\n\tPojemnosc kontenera: {pojemnoscKontenera}kg" +
               $"\n\tWysokosc kontenera: {wysokosc}" +
               $"\n\tGlebokosc kontenera: {glebokosc}";
    }

    public virtual produktyKontenerChlodniczy randomRodzajProduktu()
    {
        return produktyKontenerChlodniczy.Bananans;
    }
    
    public virtual gazyKontenerGazowy randomGazowy()
    {
        return gazyKontenerGazowy.Amoniak;
    }
}