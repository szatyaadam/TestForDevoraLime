using System;
using System.Security.Cryptography.X509Certificates;

public class Soldier
{
    public Soldier(string Name, double LifePower, int maxLifePower)
    {
        this.name = Name;
        this.lifePower = LifePower;
        this.MaxLifePower= maxLifePower;
    }
    public int MaxLifePower { get; set; }
    public string name { get; }
    public double lifePower { get; set; }
}
