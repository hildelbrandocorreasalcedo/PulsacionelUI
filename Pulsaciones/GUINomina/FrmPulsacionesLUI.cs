using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;

namespace PulsacioneslUI
{
    public partial class FrmClientes : Form
    {
        PersonaService servicio = new PersonaService();

        public FrmClientes()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
           try{
                Persona persona = new Persona(TxtIdentificacion.Text, TxtNombre.Text, Convert.ToInt16(TxtEdad.Text), TxtSexo.Text);

                var Mensaje = servicio.Guardar(persona);
                MessageBox.Show(Mensaje, "Confirmacion De Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            } catch (Exception){

                MessageBox.Show("Error!!,Ingrese TODA La informacion Debidamente", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }

           Limpiar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            var identificacion = TxtIdentificacion.Text;
            if (identificacion != ""){
                Persona personabuscada = servicio.Buscar(identificacion);
                if (personabuscada != null)
                {
                    TxtIdentificacion.Text = personabuscada.Identificacion;
                    TxtNombre.Text = personabuscada.Nombre;
                    TxtEdad.Text = Convert.ToString(personabuscada.Edad);
                    TxtSexo.Text = personabuscada.Sexo;
                    personabuscada.CalcularPulsaciones();
                    TxtPulsaciones.Text = Convert.ToString(personabuscada.Pulsaciones);
                }
                else
                {
                    MessageBox.Show("No Existe Esa Persona", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }else{ 
                MessageBox.Show("Dijite Una Identificacion A Buscar", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void Limpiar()
        {
            TxtIdentificacion.Text = "";
            TxtNombre.Text = "";
            TxtEdad.Text = "";
            TxtSexo.Text = "";
            TxtPulsaciones.Text = "";
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            var identificacion = TxtIdentificacion.Text;
            if (identificacion != "")
            {
                Persona personabuscada = servicio.Buscar(identificacion);
                if (personabuscada != null)
                {
                    var Mensaje = servicio.Eliminar(servicio.Buscar(TxtIdentificacion.Text));
                    MessageBox.Show(Mensaje, "Confirmacion De Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No Existe Esa Persona", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Dijite Una Identificacion A Buscar", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Limpiar();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Persona persona;
            var identificacion = TxtIdentificacion.Text;
            if (identificacion != "")
            {
                Persona personabuscada = servicio.Buscar(identificacion);
                if (personabuscada != null)
                {
                    servicio.Eliminar(servicio.Buscar(TxtIdentificacion.Text));

                    try
                    {
                        persona = new Persona(identificacion, TxtNombre.Text, Convert.ToInt16(TxtEdad.Text), TxtSexo.Text);

                        servicio.Guardar(persona);
                        MessageBox.Show("Se Actualizaron los Datos", "Confirmacion De Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Error!!,Ingrese TODA La informacion Debidamente", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                   
                }
                else
                {
                    MessageBox.Show("No Existe Esa Persona Registrada Con esta identificacion", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Dijite Una Identificacion A Modificar", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Limpiar();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
