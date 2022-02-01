using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Referenciar la capa de transporte y Datos 
using Datos;
using Transporte;
namespace Negocio
{
    public static class DataContextNE
    {
      


        static public PersonaDTO GetPersona(long Id)
        {

            Datos.DataContextDA data = new Datos.DataContextDA();

            return data.GetPersona(Id);
        }

        static public PersonaDTO CreatePersona(PersonaDTO persona)
        {

            Datos.DataContextDA data = new Datos.DataContextDA();

            return data.CreatePersona(persona);
        }

        static public PersonaDTO EditPersona(PersonaDTO persona)
        {

            DataContextDA data = new DataContextDA();

            return data.EditPersona(persona);
        }


        static public List<PersonaDTO> GetListaPersona()
        {

            DataContextDA data = new DataContextDA();

            return data.GetListaPersona();
        }


    }
}
