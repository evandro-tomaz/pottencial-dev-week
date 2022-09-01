using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{

    [HttpGet]
    public Person GetPerson()
    {
        Person Person = new Person("Evandro", 35, "12345678912");
        Contract newContract = new Contract("abc123", 50.98);
        Person.Contracts.Add(newContract);
        return Person;
    }

    [HttpPost]
    public Person PostPerson([FromBody] Person person)
    {
        return person;
    }

    [HttpPut("{id}")]
    public string Update([FromRoute] int id, [FromBody] Person person)
    {
        return "Dados do ID: " + id + " atualizado";
    }

    [HttpDelete("{id}")]
    public string Delete([FromRoute] int id)
    {
        return "Pessoa com ID: " + id + " deletado com sucesso!";
    }

}