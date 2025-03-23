using System.Xml.Serialization;
using cw3_projekt_1_APBD;

ICollection<Kontener> kontenery = new List<Kontener>();

//metoda dla KontenerPlyny ktora losuje wode albo mleko
string randomThings()
{
    Random rnd = new Random();
    int randomNumber = rnd.Next(1, 3);
    switch (randomNumber)
    {
        case 1: return "Woda";
        case 2: return "Mleko";
    }
    return "";
}

//Zaladowanie dla kontenerChlodniczny
for (int i = 0; i < 4; i++)
{
    Kontener K = new KontenerChlodniczy();
    Random random = new Random();
    K.ZaladowanieLadunku(random.Next(4000,9000));
    kontenery.Add(K);
}

//Zaladowanie dla kontenerPlyny
for (int i = 0; i < 6; i++)
{
    Kontener K = new kontenerPlyny(randomThings());
    Random random = new Random();
    K.ZaladowanieLadunku(random.Next(2000,5000));
    kontenery.Add(K);
}
Kontener kl1 = new kontenerPlyny("Paliwo",false);
kl1.ZaladowanieLadunku(6000);
Kontener kl2 = new kontenerPlyny("Paliwo",false);
kl2.ZaladowanieLadunku(2000);
kontenery.Add(kl1);
kontenery.Add(kl2);

//Zaladowanie dla kontenerGaz
for (int i = 0; i < 3; i++)
{
    Kontener K = new kontenerGaz();
    Random random = new Random();
    K.ZaladowanieLadunku(random.Next(1000,4200));
    kontenery.Add(K);
}

//Wypisanie wszysykich kontenerow
foreach (Kontener K in kontenery)
{
    Console.WriteLine(K);
}

//Tworzenie Kontenerowca
Kontenerowiec Imperator = new Kontenerowiec("Imperator");
foreach (Kontener K in kontenery)
{
    Imperator.DodajKontener(K);
}

//Wypisanie wszystkich informacji na temat kontenerowac
Console.WriteLine(Imperator);
//Wypisanie kazdego kontenera Imperatora
Imperator.wyswietlnieKontenerow();

//usuwanie kontenera ze statku
Imperator.UsuniecieKontenera("KON-C-1");
Console.WriteLine(Imperator);

//Dodanie nowego statku
Kontenerowiec Tytanowiec = new Kontenerowiec("Tytanowiec");
Kontener t1 = new kontenerGaz();
Kontener t2 = new KontenerChlodniczy();
Kontener t3 = new KontenerChlodniczy();
t1.ZaladowanieLadunku(3000);
t2.ZaladowanieLadunku(2500);
t3.ZaladowanieLadunku(2300);
ICollection<Kontener> konteneryTytanowiec = new List<Kontener>();
konteneryTytanowiec.Add(t1);
konteneryTytanowiec.Add(t2);
konteneryTytanowiec.Add(t3);
Tytanowiec.DodajKontener(konteneryTytanowiec);
Console.WriteLine(Tytanowiec);

//Wyswietlenie informacji o kontenerach Tytanowca
//Tytanowiec.wyswietlnieKontenerow();


//przeniesienie kontenera z Imperatora(kontenerowiec1) do Tytanowiec
Imperator.PrzeniesienieKontenera(Tytanowiec,"KON-C-2");
Console.WriteLine(Tytanowiec);
Tytanowiec.wyswietlnieKontenerow();