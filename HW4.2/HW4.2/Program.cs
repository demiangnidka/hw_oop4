public class Convertor
{
    private decimal _usdRate = 44.90m;
    private decimal _eurRate = 50.55m;

    public Convertor(decimal usd, decimal eur)
    {
        _usdRate = usd;
        _eurRate = eur;
    }

    public decimal ConvertToUsd(decimal uahAmount)
    {
        return uahAmount / _usdRate;
    }
    public decimal ConvertToEur(decimal uahAmount)
    {
        return uahAmount / _eurRate;
    }
    public decimal ConvertFromUsd(decimal usdAmount)
    {
        return usdAmount * _usdRate;
    }
    public decimal ConvertFromEur(decimal eurAmount)
    {
        return eurAmount * _eurRate;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Convertor convertor = new Convertor(44.90m, 50.55m);
        while (true)
        {
            Console.WriteLine("\n ===== Convertor =====");
            Console.WriteLine("1. UAH -> USD");
            Console.WriteLine("2. UAH -> EUR");
            Console.WriteLine("3. USD -> UAH");
            Console.WriteLine("4. EUR -> UAH");
            Console.WriteLine("0. Exit");
            Console.Write("Select action: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter amount in UAH: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal uahToUsd))
                    {
                        Console.WriteLine($"{uahToUsd} UAH = {convertor.ConvertToUsd(uahToUsd):F2} USD");
                    }
                    break;

                case "2":
                    Console.Write("Enter amount in UAH: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal uahToEur))
                        Console.WriteLine($"{uahToEur} UAH = {convertor.ConvertToEur(uahToEur):F2} EUR");
                    break;

                case "3":
                    Console.Write("Enter amount in USD: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal usdToUah))
                        Console.WriteLine($"{usdToUah} USD = {convertor.ConvertFromUsd(usdToUah):F2} UAH");
                    break;

                case "4":
                    Console.Write("Enter amount in EUR: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal eurToUah))
                        Console.WriteLine($"{eurToUah} EUR = {convertor.ConvertFromEur(eurToUah):F2} UAH");
                    break;

                case "0":
                    Console.WriteLine("The program has been completed");
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
     }
}

