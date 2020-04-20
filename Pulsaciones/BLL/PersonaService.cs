using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class PersonaService
    {
        PersonaRepository PersonaRespositorio = new PersonaRepository();
        public string Guardar(Persona persona)
        {
            if (PersonaRespositorio.Buscar(persona.Identificacion)==null)
            {
                PersonaRespositorio.Guardar(persona);
                return $"Se registro la persona {persona.Identificacion} Satisfactoriamente";
            }
            else
            {
                return $"La persona Ya se encuentra registrada";
            }
        }

        public string Eliminar(Persona persona)
        {
            if (PersonaRespositorio.Buscar(persona) == null)
            {
                return $"La persona con identificacion no se encuentra registrada";    
            }
            else
            {
                PersonaRespositorio.Eliminar(persona);
                return $"La persona {persona.Identificacion} fue eliminada";
            }
        }

        public List<Persona> Consultar()
        {
            return PersonaRespositorio.Consultar();
        }

        public string Modificar(Persona persona)
        {
            if (PersonaRespositorio.Buscar(persona.Identificacion) == null)
            {
                PersonaRespositorio.Guardar(persona);
                return $"Se registro la persona {persona.Identificacion} Satisfactoriamente";
            }
            else
            {
                return $"La persona Ya se encuentra registrada";
            }
        }

        public Persona Buscar(string identificacion)
        {   
            return PersonaRespositorio.Buscar(identificacion);
        }
    }
}
