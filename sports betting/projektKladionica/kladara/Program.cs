using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Sport
{
    public string sport;
    public int ID;
    public DateTime TimeStamp;

    public Sport(string sportovi, int id)
    {
        this.sport = sportovi;
        this.ID = id;
        this.TimeStamp = DateTime.Now;
    }

    public override string ToString()
    {
        return String.Format("{1};{0}", ID, sport);
    }
}

public class Par
{
    public string Nesto;
    public int ID;
    public DateTime TimeStamp;

    public Par(string nesto, int id)
    {
        this.Nesto = nesto;
        this.ID = id;
        this.TimeStamp = DateTime.Now;
    }

    public override string ToString()
    {
        return String.Format("{1};{0}", ID, Nesto);
    }
}

public class Listovi
{

    public int ID;
    public List<int> ParoviID;
    public DateTime TimeStamp;

    public Listovi(int id)
    {

        this.ID = id;
        this.ParoviID = new List<int>();
        this.TimeStamp = DateTime.Now;
    }

    public override string ToString()
    {
        return String.Format("{0}", ID);
    }
}

public class Igrac
{
    public string Ime;
    public string Prezime;
    public string Klub;
    public int ID;
    public DateTime TimeStamp;

    public Igrac(string ime, string prezime, string klub, int id)
    {
        this.Ime = ime;
        this.Prezime = prezime;
        this.Klub = klub;
        this.ID = id;
        this.TimeStamp = DateTime.Now;
    }

    public override string ToString()
    {
        return String.Format("{3};{0} {1} {2}", Ime, Prezime, Klub, ID);
    }
}

public class Zaposlenik
{
    public string Ime;
    public string Prezime;
    public string Pozicija;
    public int ID;
    public DateTime TimeStamp;

    public Zaposlenik(string ime, string prezime, string pozicija, int id)
    {
        this.Ime = ime;
        this.Prezime = prezime;
        this.Pozicija = pozicija;
        this.ID = id;
        this.TimeStamp = DateTime.Now;
    }

    public override string ToString()
    {
        return String.Format("{3};{0} {1} - {2}", Ime, Prezime, Pozicija, ID);
    }
}



class Program
{
    private static string file = "C:\\Users\\Korisnik\\Desktop\\Sportovi.txt";
    private static string file2 = "C:\\Users\\Korisnik\\Desktop\\Parovi.txt";
    private static string file3 = "C:\\Users\\Korisnik\\Desktop\\Listic.txt";
    private static string file4 = "C:\\Users\\Korisnik\\Desktop\\Igrac.txt";
    private static string file5 = "C:\\Users\\Korisnik\\Desktop\\Zaposlenici.txt";

    /*private static string file = "C:\\Users\\User\\Desktop\\Sportovi.txt";
      private static string file2 = "C:\\Users\\User\\Desktop\\Parovi.txt";
      private static string file3 = "C:\\Users\\User\\Desktop\\Listic.txt";
     private static string file4 = "C:\\Users\\User\\Desktop\\Igrac.txt";
     private static string file5 = "C:\\Users\\User\\Desktop\\Zaposlenici.txt";*/


    static void Main()
    {
        Program program = new Program();
        List<Sport> nizSportova = program.Ucitaj(file);
        List<Par> nizParova = program.Ucitaj2(file2);
        List<Listovi> nizListova = program.Ucitaj3(file3);
        List<Igrac> nizIgraca = program.Ucitaj4(file4);
        List<Zaposlenik> nizZaposlenika = program.Ucitaj5(file5);



        Console.WriteLine(" ____                        ____                   _   \r\n/ ___| _   _ _ __   ___ _ __/ ___| _ __   ___  _ __| |_ \r\n\\___ \\| | | | '_ \\ / _ \\ '__\\___ \\| '_ \\ / _ \\| '__| __|\r\n ___) | |_| | |_) |  __/ |   ___) | |_) | (_) | |  | |_ \r\n|____/ \\__,_| .__/ \\___|_|  |____/| .__/ \\___/|_|   \\__|\r\n            |_|                   |_|                   ");

        while (true)
        {
            Console.WriteLine("\nIzaberite opciju:");
            Console.WriteLine("1. Pregled sportova");
            Console.WriteLine("2. Pregled parova");
            Console.WriteLine("3. Pregled listića");
            Console.WriteLine("4. Pregled igrača");
            Console.WriteLine("5. Pregled zaposlenika");
            Console.WriteLine("6. Statistika");
            Console.WriteLine("0. Izlaz");

            char choice = Console.ReadKey().KeyChar;
            Console.Clear();

            switch (choice)
            {
                case '1':
                    program.Sportovi(nizSportova);
                    break;
                case '2':
                    program.Parovi(nizParova);
                    break;
                case '3':
                    program.Listovi(nizListova, nizParova);
                    break;
                case '4':
                    program.Igraci(nizIgraca);
                    break;
                case '5':
                    program.Zaposlenici(nizZaposlenika);
                    break;
                case '6':
                    GenerirajIzvjestajStatistike(program, nizSportova, nizParova, nizListova, nizIgraca, nizZaposlenika);
                    break;
                case '0':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Nevažeći unos. Pokušajte ponovno.");
                    break;
            }
        }
    }

    void Sportovi(List<Sport> nizSportova)
    {
        while (true)
        {
            Console.WriteLine("\nIzaberite opciju:");
            Console.WriteLine("1. Pregled sportova");
            Console.WriteLine("2. Unos novog sporta");
            Console.WriteLine("3. Ažuriranje sporta");
            Console.WriteLine("4. Obriši sport");
            Console.WriteLine("5. Povratak na glavni izbornik");

            char choice = Console.ReadKey().KeyChar;
            Console.Clear();

            switch (choice)
            {
                case '1':
                    Ispisi(nizSportova);
                    break;
                case '2':
                    nizSportova.Add(Unos());
                    break;
                case '3':
                    SpremiSportUFajl(file, nizSportova);
                    break;
                case '4':
                    DeleteSport(nizSportova);
                    break;
                case '5':
                    return;
                default:
                    Console.WriteLine("Nevažeći unos. Pokušajte ponovno.");
                    break;
            }
        }
    }

    void Parovi(List<Par> nizParova)
    {
        while (true)
        {
            Console.WriteLine("\nIzaberite opciju:");
            Console.WriteLine("1. Pregled parova");
            Console.WriteLine("2. Unos novog para");
            Console.WriteLine("3. Ažuriranje para");
            Console.WriteLine("4. Obriši par");
            Console.WriteLine("5. Povratak na glavni izbornik");

            char choice = Console.ReadKey().KeyChar;
            Console.Clear();

            switch (choice)
            {
                case '1':
                    IspisiParove(nizParova);
                    break;
                case '2':
                    nizParova.Add(UnosPara());
                    break;
                case '3':
                    SpremiParoveUFajl(file2, nizParova);
                    break;
                case '4':
                    DeletePar(nizParova);
                    break;
                case '5':
                    return;
                default:
                    Console.WriteLine("Nevažeći unos. Pokušajte ponovno.");
                    break;
            }
        }
    }


    void Listovi(List<Listovi> nizListova, List<Par> nizParova)
    {
        while (true)
        {
            Console.WriteLine("\nIzaberite opciju:");
            Console.WriteLine("1. Pregled listica");
            Console.WriteLine("2. Unos para na listic");
            Console.WriteLine("3. Spremi u datoteku");
            Console.WriteLine("4. Povratak na glavni izbornik");

            char choice = Console.ReadKey().KeyChar;
            Console.Clear();

            switch (choice)
            {
                case '1':
                    IspisiListic(nizListova, nizParova);
                    break;
                case '2':
                    nizListova.Add(UnosParaNaListicu(nizParova));
                    break;
                case '3':
                    SpremiListicUFajl(file3, nizListova);
                    break;
                case '4':
                    return;
                default:
                    Console.WriteLine("Nevažeći unos. Pokušajte ponovno.");
                    break;
            }
        }
    }

    void Igraci(List<Igrac> nizIgraca)
    {
        while (true)
        {
            Console.WriteLine("\nIzaberite opciju:");
            Console.WriteLine("1. Pregled igrača");
            Console.WriteLine("2. Unos novog igrača");
            Console.WriteLine("3. Ažuriranje igrača");
            Console.WriteLine("4. Obriši igrača");
            Console.WriteLine("5. Povratak na glavni izbornik");

            char choice = Console.ReadKey().KeyChar;
            Console.Clear();

            switch (choice)
            {
                case '1':
                    IspisiIgrace(nizIgraca);
                    break;
                case '2':
                    nizIgraca.Add(UnosIgraca());
                    break;
                case '3':
                    SpremiIgraceUFajl(file4, nizIgraca);
                    break;
                case '4':
                    DeleteIgrac(nizIgraca);
                    break;
                case '5':
                    return;
                default:
                    Console.WriteLine("Nevažeći unos. Pokušajte ponovno.");
                    break;
            }
        }
    }

    void Zaposlenici(List<Zaposlenik> nizZaposlenika)
    {
        while (true)
        {
            Console.WriteLine("\nIzaberite opciju:");
            Console.WriteLine("1. Pregled zaposlenika");
            Console.WriteLine("2. Unos novog zaposlenika");
            Console.WriteLine("3. Ažuriranje zaposlenika");
            Console.WriteLine("4. Obriši zaposlenika");
            Console.WriteLine("5. Povratak na glavni izbornik");

            char choice = Console.ReadKey().KeyChar;
            Console.Clear();

            switch (choice)
            {
                case '1':
                    IspisiZaposlenike(nizZaposlenika);
                    break;
                case '2':
                    nizZaposlenika.Add(UnosZaposlenika());
                    break;
                case '3':
                    SpremiZaposlenikeUFajl(file5, nizZaposlenika);
                    break;
                case '4':
                    DeleteZaposlenik(nizZaposlenika);
                    break;
                case '5':
                    return;
                default:
                    Console.WriteLine("Nevažeći unos. Pokušajte ponovno.");
                    break;
            }
        }
    }


    void IspisiIgrace(List<Igrac> igraci)
    {
        foreach (Igrac igrac in igraci)
        {
            Console.WriteLine(igrac.ToString());
        }
    }

    Igrac UnosIgraca()
    {
        Console.WriteLine("Unesi ime igrača: ");
        string ime = Console.ReadLine();
        Console.WriteLine("Unesi prezime igrača: ");
        string prezime = Console.ReadLine();
        Console.WriteLine("Unesi ime kluba u kojem igra: ");
        string klub = Console.ReadLine();
        Console.WriteLine("Unesi ID za igrača: ");
        int ID = Convert.ToInt32(Console.ReadLine());

        return new Igrac(ime, prezime, klub, ID);
    }

    void DeleteIgrac(List<Igrac> nizIgraca)
    {
        Console.WriteLine("Izbriši igrača po ID-u: ");
        int idIgraca = Convert.ToInt32(Console.ReadLine());

        foreach (Igrac igrac in nizIgraca)
        {
            if (igrac.ID == idIgraca)
            {
                Console.WriteLine("{0} pronađen. Brišemo igrača.", igrac.ToString());
                nizIgraca.Remove(igrac);
                return;
            }
        }
    }



    void SpremiSportUFajl(string file, List<Sport> nizSportova)
    {
        List<string> linijeZaUpis = new List<string>();
        foreach (Sport sport in nizSportova)
        {
            string linija = String.Format("{0};{1}", sport.sport, sport.ID);
            linijeZaUpis.Add(linija);
        }

        File.WriteAllLines(file, linijeZaUpis);
    }

    void Ispisi(List<Sport> sportovi)
    {
        foreach (Sport sport in sportovi)
        {
            Console.WriteLine(sport.ToString());
        }
    }

    Sport Unos()
    {
        Console.WriteLine("Unesi novi sport: ");
        string sport = Console.ReadLine();
        Console.WriteLine("Unesi novi ID za taj sport: ");
        int ID = Convert.ToInt32(Console.ReadLine());

        return new Sport(sport, ID);
    }

    void DeleteSport(List<Sport> nizSportova)
    {
        Console.WriteLine("Izbrisi sport po iD: ");
        int imeSporta = Convert.ToInt32(Console.ReadLine());

        foreach (Sport sport in nizSportova)
        {
            if (sport.ID == imeSporta)
            {
                Console.WriteLine("{0} pronađen. Brišemo sport..", sport.ToString());
                nizSportova.Remove(sport);
                return;
            }
        }
    }

    void SpremiParoveUFajl(string file, List<Par> nizParova)
    {
        List<string> linijeZaUpis = new List<string>();
        foreach (Par par in nizParova)
        {
            string linija = String.Format("{0};{1}", par.Nesto, par.ID);

            linijeZaUpis.Add(linija);
        }

        File.WriteAllLines(file, linijeZaUpis);
    }

    void IspisiParove(List<Par> parovi)
    {
        foreach (Par par in parovi)
        {
            Console.WriteLine(par.ToString());
        }
    }

    Par UnosPara()
    {
        Console.WriteLine("Unesi novi par: ");
        string nesto = Console.ReadLine();
        Console.WriteLine("Unesi novi ID za taj par: ");
        int ID = Convert.ToInt32(Console.ReadLine());

        return new Par(nesto, ID);
    }

    void DeletePar(List<Par> nizParova)
    {
        Console.WriteLine("Izbrisi par po ID: ");
        int idPara = Convert.ToInt32(Console.ReadLine());

        foreach (Par par in nizParova)
        {
            if (par.ID == idPara)
            {
                Console.WriteLine("{0} pronađen. Brišemo par.", par.ToString());
                nizParova.Remove(par);
                return;
            }
        }
    }
    void IspisiListic(List<Listovi> listovi, List<Par> nizParova)
    {
        foreach (Listovi listic in listovi)
        {
            Console.WriteLine($"Listic ID: {listic.ID}");

            Console.Write("Parovi na listiću: ");
            foreach (int parID in listic.ParoviID)
            {
                Par par = nizParova.Find(p => p.ID == parID);
                if (par != null)
                {
                    Console.Write($"{par.Nesto} ");
                }
            }

            Console.WriteLine("\n------------------------");
        }
    }

    Listovi UnosParaNaListicu(List<Par> nizParova)
    {
        Console.WriteLine("Pregled parova prije unosa na listić:");
        IspisiParove(nizParova);

        Console.WriteLine("Unesi ID para za dodavanje na listic: ");
        int ID = Convert.ToInt32(Console.ReadLine());

        Listovi listic = new Listovi(ID);
        listic.ParoviID.Add(ID);

        return listic;
    }

    void SpremiListicUFajl(string file, List<Listovi> nizListova)
    {
        List<string> linijeZaUpis = new List<string>();
        foreach (Listovi listic in nizListova)
        {
            string linija = $"{listic.ID};{string.Join(",", listic.ParoviID)}";
            linijeZaUpis.Add(linija);
        }

        File.WriteAllLines(file, linijeZaUpis);
        Console.WriteLine("Podaci o listićima su spremljeni u datoteku.");
    }

    void SpremiIgraceUFajl(string file, List<Igrac> nizIgraca)
    {
        List<string> linijeZaUpis = new List<string>();
        foreach (Igrac igrac in nizIgraca)
        {
            string linija = $"{igrac.Ime};{igrac.Prezime};{igrac.Klub};{igrac.ID}";
            linijeZaUpis.Add(linija);
        }

        File.WriteAllLines(file, linijeZaUpis);
        Console.WriteLine("Podaci o igračima su spremljeni u datoteku.");
    }

    void IspisiZaposlenike(List<Zaposlenik> zaposlenici)
    {
        foreach (Zaposlenik zaposlenik in zaposlenici)
        {
            Console.WriteLine(zaposlenik.ToString());
        }
    }

    Zaposlenik UnosZaposlenika()
    {
        Console.WriteLine("Unesi ime zaposlenika: ");
        string ime = Console.ReadLine();
        Console.WriteLine("Unesi prezime zaposlenika: ");
        string prezime = Console.ReadLine();
        Console.WriteLine("Unesi poziciju zaposlenika: ");
        string pozicija = Console.ReadLine();
        Console.WriteLine("Unesi ID za zaposlenika: ");
        int ID = Convert.ToInt32(Console.ReadLine());

        return new Zaposlenik(ime, prezime, pozicija, ID);
    }

    void DeleteZaposlenik(List<Zaposlenik> nizZaposlenika)
    {
        Console.WriteLine("Izbriši zaposlenika po ID-u: ");
        int idZaposlenika = Convert.ToInt32(Console.ReadLine());

        foreach (Zaposlenik zaposlenik in nizZaposlenika)
        {
            if (zaposlenik.ID == idZaposlenika)
            {
                Console.WriteLine("{0} pronađen. Brišemo zaposlenika.", zaposlenik.ToString());
                nizZaposlenika.Remove(zaposlenik);
                return;
            }
        }
    }

    void SpremiZaposlenikeUFajl(string file, List<Zaposlenik> nizZaposlenika)
    {
        List<string> linijeZaUpis = new List<string>();
        foreach (Zaposlenik zaposlenik in nizZaposlenika)
        {
            string linija = $"{zaposlenik.Ime};{zaposlenik.Prezime};{zaposlenik.Pozicija};{zaposlenik.ID}";
            linijeZaUpis.Add(linija);
        }

        File.WriteAllLines(file, linijeZaUpis);
        Console.WriteLine("Podaci o zaposlenicima su spremljeni u datoteku.");
    }

    void Statistika(List<Sport> nizSportova, List<Par> nizParova, List<Listovi> nizListova, List<Igrac> nizIgraca, List<Zaposlenik> nizZaposlenika, TimeSpan interval)
    {
        DateTime currentTime = DateTime.Now;

        Console.WriteLine($"Statistika za zadnji {interval.TotalDays} dana:");

        Console.WriteLine($"Broj sportova: {nizSportova.Count(sport => (currentTime - sport.TimeStamp) <= interval)}");
        Console.WriteLine($"Broj parova: {nizParova.Count(par => (currentTime - par.TimeStamp) <= interval)}");
        Console.WriteLine($"Broj listića: {nizListova.Count(list => (currentTime - list.TimeStamp) <= interval)}");
        Console.WriteLine($"Broj igrača: {nizIgraca.Count(igrac => (currentTime - igrac.TimeStamp) <= interval)}");
        Console.WriteLine($"Broj zaposlenika: {nizZaposlenika.Count(zaposlenik => (currentTime - zaposlenik.TimeStamp) <= interval)}");
    }

    void WriteReportToFile(string filePath, string reportContent)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.Write(reportContent);
        }

        Console.WriteLine($"Izvještaj spremljen u datoteku: {filePath}");
    }

    string GenerateReportContent(List<Sport> nizSportova, List<Par> nizParova, List<Listovi> nizListova, List<Igrac> nizIgraca, List<Zaposlenik> nizZaposlenika)
    {
        StringBuilder reportContent = new StringBuilder();

        reportContent.AppendLine("Izvještaj:");

        reportContent.AppendLine("\nSportovi:");
        foreach (Sport sport in nizSportova)
        {
            reportContent.AppendLine(sport.ToString());
        }

        reportContent.AppendLine("\nParovi:");
        foreach (Par par in nizParova)
        {
            reportContent.AppendLine(par.ToString());
        }

        reportContent.AppendLine("\nListici:");
        foreach (Listovi listic in nizListova)
        {
            reportContent.AppendLine(listic.ToString());
        }

        reportContent.AppendLine("\nIgraci:");
        foreach (Igrac igrac in nizIgraca)
        {
            reportContent.AppendLine(igrac.ToString());
        }

        reportContent.AppendLine("\nZaposlenici:");
        foreach (Zaposlenik zaposlenik in nizZaposlenika)
        {
            reportContent.AppendLine(zaposlenik.ToString());
        }



            return reportContent.ToString();
    }

    private static void GenerirajIzvjestajStatistike(Program program, List<Sport> nizSportova, List<Par> nizParova, List<Listovi> nizListova, List<Igrac> nizIgraca, List<Zaposlenik> nizZaposlenika)
    {
        TimeSpan interval = TimeSpan.FromDays(7);
        string reportContent = program.GenerateReportContent(nizSportova, nizParova, nizListova, nizIgraca, nizZaposlenika);
        program.WriteReportToFile("C:\\Users\\Korisnik\\Desktop\\Izvjestaj.txt", reportContent);
        program.Statistika(nizSportova, nizParova, nizListova, nizIgraca, nizZaposlenika, interval);
    }





    List<Sport> Ucitaj(string putanja)
    {
        List<Sport> sportovi = new List<Sport>();

        foreach (string linija in File.ReadAllLines(putanja))
        {
            string[] dijelovi = linija.Split(";");

            if (dijelovi.Length >= 2)
            {
                sportovi.Add(new Sport(dijelovi[0], Convert.ToInt32(dijelovi[1])));
            }
            else
            {
                Console.WriteLine("Invalid line format: {0}", linija);
            }
        }
        return sportovi;
    }

    List<Par> Ucitaj2(string putanja)
    {
        List<Par> parovi = new List<Par>();

        foreach (string linija in File.ReadAllLines(putanja))
        {
            string[] dijelovi = linija.Split(";");

            if (dijelovi.Length >= 2)
            {
                parovi.Add(new Par(dijelovi[0], Convert.ToInt32(dijelovi[1])));
            }
            else
            {
                Console.WriteLine("Invalid line format: {0}", linija);
            }
        }
        return parovi;
    }

    List<Listovi> Ucitaj3(string putanja)
    {
        List<Listovi> listovi = new List<Listovi>();

        foreach (string linija in File.ReadAllLines(putanja))
        {
            string[] dijelovi = linija.Split(";");

            if (dijelovi.Length >= 2)
            {
                listovi.Add(new Listovi(Convert.ToInt32(dijelovi[0])));
            }
            else
            {
                Console.WriteLine("Invalid line format: {0}", linija);
            }
        }
        return listovi;
    }


    List<Igrac> Ucitaj4(string putanja)
    {
        List<Igrac> igraci = new List<Igrac>();

        foreach (string linija in File.ReadAllLines(putanja))
        {
            string[] dijelovi = linija.Split(";");

            if (dijelovi.Length >= 3)
            {
                string ime = dijelovi[0];
                string prezime = dijelovi[1];
                string klub = dijelovi[2];
                int idIgraca = Convert.ToInt32(dijelovi[3]);

                igraci.Add(new Igrac(ime, prezime, klub, idIgraca));
            }
            else
            {
                Console.WriteLine("Invalid line format: {0}", linija);
            }
        }

        return igraci;
    }

    List<Zaposlenik> Ucitaj5(string putanja)
    {
        List<Zaposlenik> zaposlenici = new List<Zaposlenik>();

        foreach (string linija in File.ReadAllLines(putanja))
        {
            string[] dijelovi = linija.Split(";");

            if (dijelovi.Length >= 3)
            {
                string ime = dijelovi[0];
                string prezime = dijelovi[1];
                string pozicija = dijelovi[2];
                int idZaposlenika = Convert.ToInt32(dijelovi[3]);

                zaposlenici.Add(new Zaposlenik(ime, prezime, pozicija, idZaposlenika));
            }
            else
            {
                Console.WriteLine("Invalid line format: {0}", linija);
            }
        }

        return zaposlenici;
    }
}


