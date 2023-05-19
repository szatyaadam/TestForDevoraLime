using System;
using System.Security.Cryptography.X509Certificates;

public class Soldier
{

    public Soldier(string Name, int LifePower)
    {
       
        this.name = Name;
        this.lifePower = LifePower;
    }
    public string name { get; set; }
    public int lifePower { get; set; }
}
