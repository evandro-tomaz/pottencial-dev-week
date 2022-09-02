using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.Models;
using src.Persistence;
using System.Net;

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
    public ActionResult<List<Person>> ListAll()
    {
        var result = _context.Persons.Include(p => p.Contracts).ToList();

        if (!result.Any()) return NoContent();

        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Person> Insert([FromBody] Person person)
    {
        try
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {
            return BadRequest(new
            {
                msg = "Não foi possível processar a solicitação"
            });
        }

        return Created("Criado com sucesso!", person);
    }

    [HttpPut("{id}")]
    public ActionResult<Object> Update([FromRoute] int id, [FromBody] Person person)
    {
        var result = _context.Persons.SingleOrDefault(e => e.Id == id);
        if (result is null)
        {
            return NotFound(new
            {
                msg = $"Não foi possível encontrar o registro {id} no sistema.",
                status = HttpStatusCode.NotFound
            });
        }

        try
        {
            _context.Persons.Update(person);
            _context.SaveChanges();

        }
        catch (System.Exception)
        {
            return BadRequest(new
            {
                msg = "Não foi possível realizar essa operação.",
                status = HttpStatusCode.BadRequest
            });
        }
        return new
        {
            msg = $"Registro {id} atualizado com sucesso!",
            status = HttpStatusCode.OK
        };
    }

    [HttpDelete("{id}")]
    public ActionResult<Object> Delete([FromRoute] int id, [FromBody] Person person)
    {
        var result = _context.Persons.SingleOrDefault(e => e.Id == id);

        if (result is null) return BadRequest(new
        {
            msg = "Conteúdo inexistente. Solicitação inválida",
            status = HttpStatusCode.Forbidden
        });
        _context.Persons.Remove(result);
        _context.SaveChanges();
        return Ok(new
        {
            msg = "Registro deletado com sucesso!",
            status = HttpStatusCode.OK
        });
    }

}