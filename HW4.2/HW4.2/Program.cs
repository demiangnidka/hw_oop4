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
        decimal uahAmount = 1337m;
        decimal usdAmount = 67m;
        decimal eurAmount = 228m;

        Console.WriteLine("Convert from UAH: ");
        Console.WriteLine($"{uahAmount} UAH = {convertor.ConvertToUsd(uahAmount)} USD");
        Console.WriteLine($"{uahAmount} UAH = {convertor.ConvertToEur(uahAmount)} EUR");

        Console.WriteLine("Convert to UAH: ");
        Console.WriteLine($"{usdAmount} USD = {convertor.ConvertFromUsd(usdAmount)} UAH");
        Console.WriteLine($"{eurAmount} EUR = {convertor.ConvertFromUsd(eurAmount)} UAH");
    }
}