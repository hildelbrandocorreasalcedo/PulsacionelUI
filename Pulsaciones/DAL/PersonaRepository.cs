using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAL
{
    public class PersonaRepository
    {

        public List<Persona> Personas = new List<Persona>();

        public void Guardar(Persona persona) {
            Personas.Add(persona);
        }

        public void Eliminar(Persona persona)
        {
            Personas.Remove(persona);
        }

        public List<Persona> Consultar()
        {
            return Personas;
        }

        public void Modificar(Persona persona)
        {
            Personas.Add(persona);
        }

        public Persona Buscar(Persona persona)
        {
            foreach (var item in Personas)
            {
                if (item.Equals(persona))
                {
                    return item;
                }
            }
            return null;
        }

        public Persona Buscar(string identificacion)
        {
            foreach (var item in Personas)
            {
                if (item.Identificacion.Equals(identificacion))
                {
                    return item;
                }
            }
            return null;
        }
    }
}
