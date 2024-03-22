using System.Text.RegularExpressions;

var domainLanguage = "order x10 '2L water bottles' from Tesco";
Order.Parse(domainLanguage)?.Dump();

// Grammar Representation

public class Order
{
    const string optionalSpace = " ?";
    const string qty = "x(?<qty>\\d+)" + optionalSpace;
    const string product = "'(?<product>[\\w ]+)'" + optionalSpace;
    const string source = "from (?<source>\\w+)";
    const string orderCommand = "order" + optionalSpace + qty + product + source;

    static Regex _regex = new Regex(orderCommand);

    public Order(int qty, string product, string source)
    {
        Qty = qty;
        Product = product;
        Source = source;
    }

    public int Qty { get; }
    public string Product { get; }
    public string Source { get; }

    // Interpreter
    public static Order? Parse(string command)
    {
        var match = _regex.Match(command);
        if (!match.Success) return null;

        var qty = int.Parse(match.Groups["qty"].Value);
        var product = match.Groups["product"].Value;
        var source = match.Groups["source"].Value;

        return new Order(qty, product, source);
    }

    public void Dump()
    {
        Console.WriteLine($"Product: {Product}");
        Console.WriteLine($"Source: {Source}");
        Console.WriteLine($"Quantity: {Qty}");
    }
}