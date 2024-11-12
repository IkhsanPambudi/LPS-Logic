static void Main(string[] args)
{
    var myList = new List<Product>();
    int maxSize = 10000; 

    while (true)
    { 
        if (myList.Count >= maxSize)
        {
            myList.RemoveRange(0, 500);  
        }
        
        for (int i = 0; i < 1000; i++)
        {
            myList.Add(new Product(Guid.NewGuid().ToString(), i));
        }

        // Lakukan sesuatu dengan list
        Console.WriteLine($"List size: {myList.Count}");
    }
}

alasan : Penggunaan RemoveRange berfungsi untuk menghindari memory leak
   