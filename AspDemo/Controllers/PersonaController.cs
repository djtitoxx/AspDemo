using AspDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transporte;
using Negocio;
namespace AspDemo.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        [HttpGet]
       public ActionResult create()
       {
            return View();
       }
        [HttpPost]
        public ActionResult create(PersonaViewModel persona)
        {
           
            if (ModelState.IsValid == true )
            {
                PersonaDTO personaDTO = new PersonaDTO();
                personaDTO.Nombre = persona.Nombre;

                personaDTO.Apellido = persona.Apellido;

                var respuesta = DataContextNE.CreatePersona(personaDTO);

                if(respuesta != null)
                {
                    return RedirectToAction("detail", "Persona", new {Id = respuesta.Id});
                }

            }

           return View(persona);
        }


        // GET: Persona
        [HttpGet]
        public ActionResult edit(long Id)
        {

            var respuesta = DataContextNE.GetPersona(Id);

            PersonaViewModel VMpersonas = new PersonaViewModel();


            PersonaViewModel VMpersona = new PersonaViewModel();
            VMpersona.Nombre = respuesta.Nombre;
            VMpersona.Apellido = respuesta.Apellido;
            VMpersona.Id = respuesta.Id;

            return View(VMpersona);
        }

        [HttpPost]
        public ActionResult edit(PersonaViewModel persona)
        {

            if (ModelState.IsValid == true)
            {
                PersonaDTO personaDTO = new PersonaDTO();
                personaDTO.Nombre = persona.Nombre;
                personaDTO.Apellido = persona.Apellido;
                personaDTO.Id = persona.Id;

                var respuesta = DataContextNE.EditPersona(personaDTO);

                if (respuesta != null)
                {
                    return RedirectToAction("edit", "Persona", new { Id = respuesta.Id });
                }

            }

            return View(persona);
        }
        //Llamar a la capa de negocio



        // GET: Persona
        [HttpGet]
        public ActionResult detail(long Id)
        {             
                var respuesta = DataContextNE.GetPersona(Id);

            PersonaViewModel VMpersonas = new PersonaViewModel();

            
                PersonaViewModel VMpersona = new PersonaViewModel();
                VMpersona.Nombre = respuesta.Nombre;
                VMpersona.Apellido = respuesta.Apellido;
                VMpersona.Id = respuesta.Id;
            
            return View(VMpersona);

        }

        [HttpGet]
        public ActionResult index()
        {
            var respuesta = DataContextNE.GetListaPersona();
            List<PersonaViewModel> VMpersonas = new List<PersonaViewModel>();

            foreach(var persona in respuesta)
            {
                PersonaViewModel VMpersona = new PersonaViewModel();
                VMpersona.Nombre = persona.Nombre;
                VMpersona.Apellido = persona.Apellido;
                VMpersona.Id = persona.Id;
                VMpersonas.Add(VMpersona);
            }
            return View(VMpersonas);
        }
    }
}