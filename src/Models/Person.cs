using System.Collections.Generic;

namespace src.Models;

public class Person
{
    public Person()
    {
        this.Name = "";
        this.Age = 0;
        this.Contracts = new List<Contract>();
        this.Active = true;
    }

    public Person(string Name, int Age, string Cpf)
    {
        this.Name = Name;
        this.Age = Age;
        this.Cpf = Cpf;
        this.Contracts = new List<Contract>();
        this.Active = true;
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public int Age { get; set; }

    public string? Cpf { get; set; }

    public bool Active { get; set; }

    public List<Contract> Contracts { get; set; }
}