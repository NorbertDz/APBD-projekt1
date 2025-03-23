namespace cw3_projekt_1_APBD;

public class Kontenerowiec
{
    protected ICollection<Kontener> kontenery;
    private string nazwaKontenerowca;
    private double predkoscWwezlach = 25;
    private int maksymalnaIloscKontenerow = 8000;
    private int maksymalnaWagaWszystkichKontenerow = 48000;
    private Kontener tmpKontener;
    
    public Kontenerowiec(string nazwaKontenerowca)
    {
        kontenery = new List<Kontener>();
        this.nazwaKontenerowca = nazwaKontenerowca;
    }

    public override string ToString()
    {
        return $"\n\n\n\n=====================Informacje dotyczace {nazwaKontenerowca}=====================" +
               $"\n\tIlosc Kontenerow: {kontenery.Count}" +
               $"\n\tIlosc kontenerow Chlodniczych: {Kontener.getTypeC()}" +
               $"\n\tIlosc kontenerow Gazowych: {Kontener.getTypeG()}" +
               $"\n\tIlosc kontenerow z Plynami: {Kontener.getTypeL()}" +
               $"\n\tPredkosc wezlach: {predkoscWwezlach}" +
               $"\n\tMaksymalna ilosc Kontenerow: {maksymalnaIloscKontenerow}" +
               $"\n\tMaksymalna waga wszystkich kontenerow: {maksymalnaWagaWszystkichKontenerow}ton\n";
    }


    public void wyswietlnieKontenerow()
    {
        Console.WriteLine($"Wyswietlenie informacji na temat kazdego kontenera z {nazwaKontenerowca}");
        foreach (Kontener K in kontenery)
        {
            Console.WriteLine(K+"\n");
        }
    }
    public void UsuniecieKontenera(string numerSeryjny)
    {
        Console.WriteLine($"Usuwanie kontenera {numerSeryjny}");
        foreach (var k in kontenery)
        {
            if (k.getNumerSeryjny().Equals(numerSeryjny))
            {
                tmpKontener = k;
                kontenery.Remove(k);
                break;
            }
        }
    }

    public void DodajKontener(ICollection<Kontener> k)
    {
        Console.WriteLine("Kontenery zostaly dodane");
        foreach (Kontener K in k)
        {
            kontenery.Add(K);
        }
    }

    public void DodajKontener(Kontener K)
    {
        Console.WriteLine("Kontener zostaly dodany");
        kontenery.Add(K);
    }

    public void RozladowanieKontenera()
    {
        kontenery.Clear();
        Console.WriteLine($"Kontenerowiec {nazwaKontenerowca} został rozładowany");
    }

    public void PrzeniesienieKontenera(Kontenerowiec k,string nr)
    {
        Console.WriteLine($"\n\nPrzeniesienie kontenera o numerze seryjnym {nr} z {nazwaKontenerowca} do {k.nazwaKontenerowca}\n");
        UsuniecieKontenera(nr);
        k.DodajKontener(tmpKontener);
    }
}