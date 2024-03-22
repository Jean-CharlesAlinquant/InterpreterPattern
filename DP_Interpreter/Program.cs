using DesignPatterns.Interpreter;

var domainLanguage = "order x10 '2L water bottles' from Tesco";
Order.Parse(domainLanguage)?.Dump();
