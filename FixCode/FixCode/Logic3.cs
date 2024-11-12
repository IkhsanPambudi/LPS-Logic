public class Laptop
{ 
    private string os;
 
    public string Os
    {
        get { return os; }
    }
 
    public Laptop(string os)
    {
        this.os = os;  
    }
}

// Penggunaan
var laptop = new Laptop("macOs");
Console.WriteLine($"Laptop OS: {laptop.Os}"); 

alasan : Data internal dilindungi dan hanya bisa diubah melalui konstruktor atau method internal.