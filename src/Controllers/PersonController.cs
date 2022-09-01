using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.Models;
using src.Persistence;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    public PersonController(Context context)
    {
        this._context = context;
    }
    private Context _context { get; set; }

    [HttpGet]
    public List<Person> ListAll()
    {
        // Person Person = new Person("Evandro", 35, "12345678912");
        // Contract newContract = new Contract("abc123", 50.98);
        // Person.Contracts.Add(newContract);
        return _context.Persons.Include(p => p.Contracts).ToList();
    }

    [HttpPost]
    public Person Insert([FromBody] Person person)
    {
        _context.Persons.Add(person);
        _context.SaveChanges();
        return person;
    }

    [HttpPut("{id}")]
    public string Update([FromRoute] int id, [FromBody] Person person)
    {
        _context.Persons.Update(person);
        _context.SaveChanges();
        return "Dados do ID: " + id + " atualizado";
    }

    [HttpDelete("{id}")]
    public string Delete([FromRoute] int id, [FromBody] Person person)
    {
        _context.Persons.Remove(person);
        return "Pessoa com ID: " + id + " deletado com sucesso!";
    }

}