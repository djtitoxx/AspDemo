using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transporte;


namespace Datos
{
    public class DataContextDA
    {

        public bool UpdatePersona(long? Id_Persona, string Nombre, string Apellido)
        {

            using (PruebaCarlosEntities1 db = new PruebaCarlosEntities1())
            {
                bool inserto = false;
                try
                {
                    //Comentario en develop
                    //Comentario en developJose
                    db.Database.BeginTransaction();

                    var result = db.sp_UpdatePersona(Id_Persona, Nombre, Apellido);


                    db.Database.CurrentTransaction.Commit();
                    inserto = true;
                }
                catch (Exception ex)
                {

                    db.Database.CurrentTransaction.Rollback();
                }


                return inserto;
              
            }
        }


        public PersonaDTO GetPersona(long? Id_Persona)
        {
            using (PruebaCarlosEntities1 db = new PruebaCarlosEntities1())
            {
                
                try
                {
                   
                    sp_GetPersona_Result result = db.sp_GetPersona(Id_Persona).FirstOrDefault();

                    PersonaDTO personaDTO = new PersonaDTO();

                    personaDTO.Nombre = result.Nombre;

                    personaDTO.Apellido = result.Apellido;

                    personaDTO.Id = result.Id;

                    return personaDTO;
                }
                catch (Exception ex)
                {

                }


                return null;

            }
        }

        public PersonaDTO CreatePersona(PersonaDTO persona)
        {
            using (PruebaCarlosEntities1 db = new PruebaCarlosEntities1())
            {
                try
                {
                    db.Database.BeginTransaction();
                   
                    var ultimoID =  db.sp_CreatePersona(persona.Nombre, persona.Apellido).FirstOrDefault();
                    persona.Id = Convert.ToInt64(ultimoID);
                    db.Database.CurrentTransaction.Commit();

                    return persona;
                   

                }
                catch (Exception ex)
                {
                    return null;

                    db.Database.CurrentTransaction.Rollback();
                }


            }

        }

        public PersonaDTO EditPersona(PersonaDTO persona)
        {
            using (PruebaCarlosEntities1 db = new PruebaCarlosEntities1())
            {
                try
                {
                    db.Database.BeginTransaction();
                    var result = db.sp_UpdatePersona(persona.Id, persona.Nombre, persona.Apellido);
                    
                    db.Database.CurrentTransaction.Commit();
                   

                    if (result!=null)
                    {
                        return persona;
                    }
                    else
                    {
                        return null;
                    }

                   


                }
                catch (Exception ex)
                {
                    return null;

                    db.Database.CurrentTransaction.Rollback();
                }


            }

        }

        public List<PersonaDTO> GetListaPersona()
        {
            using (PruebaCarlosEntities1 db = new PruebaCarlosEntities1())
            {
                try
                {
                    List<PersonaDTO> personaDTOs = new List<PersonaDTO>();
                    var result = db.sp_GetListPersona().ToList();

                    foreach(var persona in result)
                    {
                        PersonaDTO personaDTO = new PersonaDTO();

                        personaDTO.Nombre = persona.Nombre;

                        personaDTO.Apellido = persona.Apellido;

                        personaDTO.Id = persona.Id;

                        personaDTOs.Add(personaDTO);    

                    }

                    return personaDTOs;
                }
                catch (Exception ex)
                {
                    return null;

                }
            }
        }


    }
}
