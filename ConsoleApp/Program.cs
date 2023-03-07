using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

class User
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int Salary { get; set; }
    public double Taxes { get; set; }
}
class Program
{

    static void Main(string[] args)
    {
        User user = new User();

        Console.WriteLine("Entrez votre ID : ");
        user.ID = int.Parse(Console.ReadLine());

        Console.WriteLine("\nEntrez votre Prénom : ");
        user.FirstName = Console.ReadLine();

        Console.WriteLine("\nEntrez votre Nom : ");
        user.LastName = Console.ReadLine();

        Console.WriteLine("\nEntrez votre Age : ");
        user.Age = int.Parse(Console.ReadLine());

        Console.WriteLine("\nEntrez votre Salaire annuel Brut : ");
        user.Salary = int.Parse(Console.ReadLine().Replace("€", ""));

        Console.WriteLine("\nEntrez votre Taux d'imposition : ");
        user.Taxes = double.Parse(Console.ReadLine().Replace("%", ""));

        string[] month = new string[] { "Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "juillet", "Aout", "Septembre", "Octobre", "Novembre", "Décembre" };
        string closedMonth = "Aout";
        double tauxPrime = 0;

        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("\nL'utilisateur suivant a été créé:");
        Console.WriteLine("ID: " + user.ID);
        Console.WriteLine("Nom: " + user.LastName);
        Console.WriteLine("Prénom: " + user.FirstName);
        Console.WriteLine("Age: " + user.Age);
        Console.WriteLine("Salaire annuel brut: " + user.Salary + "€");
        Console.WriteLine("Taux d'imposition: " + user.Taxes + "%");

        Console.WriteLine("\nQuel est le Taux de la prime de fin d'année : ");
        try
        {
            tauxPrime = double.Parse(Console.ReadLine().Replace("%", ""));
        }
        catch (FormatException)
        {
            Console.WriteLine("Le taux de la Prime de fin d'année doit être un entier");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("La division ne peux pas être par 0");
        }
        Console.WriteLine("\nAvec une prime de fin d'année de : " + tauxPrime + "%");
        double salaryNet = Math.Round((user.Salary, user.Taxes), 2);
        Console.WriteLine("\nLe salaire net de " + user.FirstName + " " + user.LastName + " est de : " + salaryNet + "€");

        switch (user.Salary)
        {
            case >= 50000:
                Console.WriteLine("Je vous conseille de faire des dons à des associations tels que l'Oeuvre des Pupilles pour réduire votre Imposition");
                break;

            case <= 1500 * 12:
                Console.WriteLine("Ce salaire est normal pour un alternant");
                break;

            case <= 40000 when user.Salary >= 30000:
                Console.WriteLine("Venez travailler chez CESI vous gagnerez 100000€ brut");

        }
    }
}





