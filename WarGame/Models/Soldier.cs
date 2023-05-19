using System;
using System.Security.Cryptography.X509Certificates;

public class Soldier
{
    public Soldier(int? Id,string Name, int LifePower)
    {
        this.id = Id;
        this.name = Name;
        this.lifePower = LifePower;
    }
    public int? id { get; set; }
    public string name { get; set; }
    public int lifePower { get; set; }
}
