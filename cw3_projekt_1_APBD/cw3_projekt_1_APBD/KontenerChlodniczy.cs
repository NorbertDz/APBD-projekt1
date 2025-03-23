namespace cw3_projekt_1_APBD;

public class KontenerChlodniczy : Kontener
{
    protected double temperatura;
    protected double temperaturaKontenera;
    protected produktyKontenerChlodniczy rodzajProduktu { get; set; }
    
    public KontenerChlodniczy(produktyKontenerChlodniczy rodzajProduktu) : base(typKonteneru.C)
    {
        this.rodzajProduktu = rodzajProduktu;
        wagaKontenera = 2000;
        pojemnoscKontenera = 10000;
        
        //Losowana jest temperatura kontenera
        Random random = new Random();
        temperaturaKontenera = random.Next(-40,25);
        
        setProdukt();
    }

    public KontenerChlodniczy(): base(typKonteneru.C)
    {
        this.rodzajProduktu = randomRodzajProduktu();
        wagaKontenera = 2000;
        pojemnoscKontenera = 10000;
        setProdukt();
    }

    private void setProdukt()
    {
        switch (rodzajProduktu)
        {
            case produktyKontenerChlodniczy.Bananans:
                temperatura = 13.3;
                break;
            case produktyKontenerChlodniczy.Chocolate:
                temperatura = 18;
                break;
            case produktyKontenerChlodniczy.Fish:
                temperatura = 2;
                break;
            case produktyKontenerChlodniczy.Meat:
                temperatura = -15;
                break;
            case produktyKontenerChlodniczy.Ice_cream:
                temperatura = -18;
                break;
            case produktyKontenerChlodniczy.Frozen_pizza:
                temperatura = -30;
                break;
            case produktyKontenerChlodniczy.Chesse:
                temperatura = 7.2;
                break;
            case produktyKontenerChlodniczy.Sausages:
                temperatura = 5;
                break;
            case produktyKontenerChlodniczy.Butter:
                temperatura = 20.5;
                break;
            case produktyKontenerChlodniczy.Eggs:
                temperatura = 19;
                break;
        }
    }

    public override void ZaladowanieLadunku(double ladunek)
    {

        try
        {
            if (pojemnoscKontenera < ladunek)
            {
                masaLadunku = ladunek; 
                throw new OverfillException($"Przekroczono pojemność kontenera! Numer kontenera: {numerSeryjny}");
            }

            if (temperaturaKontenera <= temperatura)
            {
                masaLadunku = ladunek;
                throw new CriticalTemperatureException(
                $"Temperatura Kontenera jest niższa od produktu! Numer kontenera: {numerSeryjny}");
            }
                wagaKontenera += ladunek;
            masaLadunku = ladunek;
            Console.WriteLine($"\tAktualna waga kontera wraz z ladunkiem wynosi: {wagaKontenera}kg");
        }
        catch (OverfillException e)
        {
            Console.WriteLine($"Błąd: {e.Message}");
        }
        catch (CriticalTemperatureException e)
        {
            Console.WriteLine($"Błąd: {e.Message}");
        }
    }

    public override void OproznianieLadunku()
    {
        wagaKontenera = 2000;
        masaLadunku = 0;
    }

    public override string ToString()
    {
        return base.ToString()+
               $"\n\tPrzewozony produkt: {rodzajProduktu}";
    }
    
    public override produktyKontenerChlodniczy randomRodzajProduktu()
    {
        Random random = new Random();
        int i = random.Next(0, 7);
        switch (i)
        {
            case 0: return produktyKontenerChlodniczy.Bananans;
            case 1: return produktyKontenerChlodniczy.Chocolate;
            case 2: return produktyKontenerChlodniczy.Fish;
            case 3: return produktyKontenerChlodniczy.Meat;
            case 4: return produktyKontenerChlodniczy.Ice_cream;
            case 5: return produktyKontenerChlodniczy.Frozen_pizza;
            case 6: return produktyKontenerChlodniczy.Chesse;
            case 7: return produktyKontenerChlodniczy.Sausages;
            case 8: return produktyKontenerChlodniczy.Butter;
            case 9: return produktyKontenerChlodniczy.Eggs;
        }

        return produktyKontenerChlodniczy.Chocolate;
    }


}