using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Becas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Becas.service
{
    public class AlumnoService
    {
       static List<Alumno> Alumnos {get;}

        static int nextId = 3;
          static AlumnoService ()
        {
            Alumnos = new List <Alumno> {
                new Alumno {Id = 1, Nombres = "Gamaliel ", ApellPat = "Garcia ", ApellMat = "Gomez ", Matricula = "2308986 ", Carrera = "T.S.U Tecnologias de la informacion ", Correo = "garciagomezgamaliel@gmail.com ", Telefono = "9821075495 ", Origen = "candelaria ", Estancia = "candelaria " },
                new Alumno {Id = 2, Nombres = " lazaro", ApellPat = "sanchez ", ApellMat = "Sanchez ", Matricula = "2396708 ", Carrera = "T.S.U Tecnologias de la informacion ", Correo = "lazaro235@gmail.com ", Telefono = " 9821456789", Origen = "San Manuel ", Estancia = "Candelaria " },
            };
        }

        public ActionResult<List<Alumno>> GetAll()
        {
            throw new NotImplementedException();
        }

        public static List<Alumno> Get()=> Alumnos;

    public  Alumno Get(int Id) => Alumnos.FirstOrDefault(p => p.Id == Id);


    public static void Add(Alumno alumno)
    {
        alumno.Id = nextId++;
        Alumnos.Add(alumno);

    }
    public async void Delete(int Id )
    {
        var alumno = Get(Id);
        if(alumno is null)
            return;

            Alumnos.Remove(alumno);
           
    }

    public async void Update(Alumno alumno)
    {
        var index = Alumnos.FindIndex(p => p.Id == alumno.Id);
        if (index == -1)
        return;

        Alumnos[index] = alumno;
    }


    }
}