using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtletaApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtletaApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AtletaController : ControllerBase
{
    // GET: api/Atleta
    [HttpGet]
    public ActionResult<IEnumerable<Atleta>> Get()
    {
        if (db.Atletas == null)
            return NotFound();

        return db.Atletas;
    }

    // GET: api/Atleta/5
    [HttpGet("{id}")]
    public ActionResult<Atleta> GetId(string id)
    {
        var obj = db.Atletas.FirstOrDefault(x => x.Id == id);

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

        db.Atletas.Add(obj);
        db.SaveChanges();

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
        
        db.Atletas.Update(obj);
        db.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Atleta/5
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        if (db.Atletas == null)
            return NotFound();

        var obj = db.Atletas.FirstOrDefault(x => x.Id == id);

        if (obj == null)
            return NotFound();

        db.Atletas.Remove(obj);
        db.SaveChanges();

        return NoContent();
    }

    private readonly ModelContext db = new();
}
