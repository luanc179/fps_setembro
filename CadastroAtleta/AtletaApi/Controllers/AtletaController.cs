using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtletaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AtletaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AtletaController : ControllerBase
{
    // GET: api/Atleta
    [HttpGet]
    public ActionResult<IEnumerable<Atleta>> Get()
    {
        if (objetos == null)
            return NotFound();
        return objetos;
    }

    // GET: api/Atleta/5
    [HttpGet("{id}")]
    public ActionResult<Atleta> GetId(string id)
    {
        var obj = objetos?.FirstOrDefault(x => x.Id == id);
        if (obj == null)
            return NotFound();
        return obj;
    }

    // POST: api/Atleta
    [HttpPost]
    public ActionResult<Atleta> Post(Atleta obj)
    {
        if (obj.Id == null)
            obj.Id = Guid.NewGuid().ToString();
        objetos.Add(obj);
        return CreatedAtAction(
        nameof(GetId),
        new { id = obj.Id },
        obj
        );
    }

     // PUT: api/Atleta/5
    [HttpPut("{id}")]
    public IActionResult Put(string id, Atleta obj)
    {
        if (id != obj.Id)
            return BadRequest();
        var objOrig = objetos.FirstOrDefault(x => x.Id == id);
        if (objOrig == null)
            return NotFound();
        objOrig.Altura = obj.Altura;
        objOrig.Nome = obj.Nome;
        objOrig.Peso = obj.Peso;
        return NoContent();
    }

    // DELETE: api/Atleta/5
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        if (objetos == null)
            return NotFound();
        var obj = objetos.FirstOrDefault(x => x.Id == id);
        if (obj == null)
            return NotFound();
        objetos.Remove(obj);
        return NoContent();
    }

    static AtletaController()
    {
        objetos = new List<Atleta>(){
            new() { Id = "X1", Nome = "Ana", Altura = 1.7, Peso = 65 },
            new() { Id = "X2", Nome = "Bruno", Altura = 2, Peso = 90 }
        };
    }

    private static readonly List<Atleta> objetos;
}
