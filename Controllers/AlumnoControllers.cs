using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Becas.service;
using Becas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Becas.Controllers
{
    
    [Route("[controller]")]
     [ApiController]
    public class AlumnoController: Controller
     {
        private readonly ApplicationDbContext context;
        public AlumnoController(ApplicationDbContext context)
        {
            this.context = context;
        }

 [HttpGet]
        public ActionResult<List<Alumno>> GetAll() => AlumnoService.GetAll();

        [HttpGet("{Id}")]
        public ActionResult<Alumno> Get (int id)
        {
            var Alumno = AlumnoService.Get(id);
            if(Alumno == null)
            
                return NotFound();

                return Alumno;   
        }

        [HttpPost]
        public async Task<ActionResult> Post(Alumno alumno){
            context.Add(alumno);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var alumnoExiste = await AlumnoExiste(Id);
            if (!alumnoExiste)
            {
             return NotFound();
            }
             context.Remove(new Alumno() { Id = Id});
             await context.SaveChangesAsync();
             return NotFound();
        }
        private async Task<bool> AlumnoExiste(int Id)
        {
            return await context.Alumnos.AnyAsync(p => p.Id ==Id);
        }
     

        [HttpPut("Id")]
        public async Task<ActionResult> put (int Id, Alumno alumno)
        {
            var alumnoExiste = await AlumnoExiste(Id);
            if (!alumnoExiste)
            {

                return NotFound();
            }
            context.Update(alumno);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
       