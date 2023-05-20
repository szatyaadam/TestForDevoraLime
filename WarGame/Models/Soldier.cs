using System;
using System.Security.Cryptography.X509Certificates;

public class Soldier
{
    public Soldier(string Name, double LifePower)
    {
        this.name = Name;
        this.lifePower = LifePower;
    }
    
    public string name { get; }
    public double lifePower { get; set; }
}
