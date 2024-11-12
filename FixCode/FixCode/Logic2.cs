public (string Path, string Name, string Version) GetInfo()
{
    return ("C:/apps/", "Shield.exe", "1.0.0");
}

var info = GetInfo();
Console.WriteLine(info.Path);   
Console.WriteLine(info.Name);   
Console.WriteLine(info.Version);

Alasan : Penggunaan value tuple lebih ringkas dan sederhana, serta lebih efisien
dibandingkan tuple dikarenakan tuple menggunakan stack memory