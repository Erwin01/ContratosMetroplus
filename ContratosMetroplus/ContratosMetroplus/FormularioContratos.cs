/*Importo las librerias*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects.SqlClient;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContratosMetroplus
{
    /*Clase del Formulario*/
    public partial class FormularioContratos : Form
    {
        /*Declaro una clase FormularioContratos*/
        public FormularioContratos()
        {
   
            InitializeComponent();
            /*Centra el formulario al centro de pantalla*/
            this.CenterToScreen();
            /*Metodo cargar*/
            Cargar();
            /*Solo comboBox*/
            cbModalidadSeleccion.SelectedIndex = 0;
            cbProcedimiento.SelectedIndex = 0;
            cbClaseContrato.SelectedIndex = 0;
            cbTipoGasto.SelectedIndex = 0;
            cbSectoCorrespondienteGasto.SelectedIndex = 0;
            cbTipoPersona.SelectedIndex = 0;
            cbTipoVinculacion.SelectedIndex = 0;
            cbUnidadEjecucion.SelectedIndex = 0;
            cbAnticipoContrato.SelectedIndex = 0;
            cbPublicoSecop.SelectedIndex = 0;
            cbConstituyoFiducia.SelectedIndex = 0;
            textBox2.Enabled = false;
            txtId.Visible = false;
            /*Llama el metodo deshabilitar*/
            Deshabilitar();
        }

        /*Creo Metodo Deshabilitar*/
        private void Deshabilitar()
        {
            txtNumContrato.Enabled = false;
            cbModalidadSeleccion.Enabled = false;
            cbProcedimiento.Enabled = false;
            cbClaseContrato.Enabled = false;
            cbTipoGasto.Enabled = false;
            cbSectoCorrespondienteGasto.Enabled = false;
            txtObjetoContrato.Enabled = false;
            txtValorInicialContrato.Enabled = false;
            txtCedulaContratista.Enabled = false;
            txtNombreContratista.Enabled = false;
            cbTipoPersona.Enabled = false;
            dtFechaSuscripcionContrato.Enabled = false;
            txtCedulaInterventor.Enabled = false;
            txtNombreInterventor.Enabled = false;
            cbTipoVinculacion.Enabled = false;
            cbUnidadEjecucion.Enabled = false;
            txtNumeroUnidades.Enabled = false;
            cbAnticipoContrato.Enabled = false;
            txtValorAnticipos.Enabled = false;
            cbConstituyoFiducia.Enabled = false;
            dtFechaInicio.Enabled = false;
            dtFechaTerminacion.Enabled = false;
            cbPublicoSecop.Enabled = false;
            btnIngresar.Enabled = false;
            btnActualizar.Enabled = false;
        }

        /*Creo Metodo habilitar*/
        private void Habilitar()
        {
            txtNumContrato.Enabled = true;
            cbModalidadSeleccion.Enabled = true;
            cbProcedimiento.Enabled = true;
            cbClaseContrato.Enabled = true;
            cbTipoGasto.Enabled = true;
            cbSectoCorrespondienteGasto.Enabled = true;
            txtObjetoContrato.Enabled = true;
            txtValorInicialContrato.Enabled = true;
            txtCedulaContratista.Enabled = true;
            txtNombreContratista.Enabled = true;
            cbTipoPersona.Enabled = true;
            dtFechaSuscripcionContrato.Enabled = true;
            txtCedulaInterventor.Enabled = true;
            txtNombreInterventor.Enabled = true;
            cbTipoVinculacion.Enabled = true;
            cbUnidadEjecucion.Enabled = true;
            txtNumeroUnidades.Enabled = true;
            cbAnticipoContrato.Enabled = true;
            txtValorAnticipos.Enabled = true;
            cbConstituyoFiducia.Enabled = true;
            dtFechaInicio.Enabled = true;
            dtFechaTerminacion.Enabled = true;
            cbPublicoSecop.Enabled = true;
            btnIngresar.Enabled = true;
        }

        /*Creo el metodo de Limpiar*/
        private void Limpiar()
        {
            txtId.Text = String.Empty;
            cbModalidadSeleccion.SelectedIndex = 0;
            cbProcedimiento.SelectedIndex = 0;
            cbClaseContrato.SelectedIndex = 0;
            cbTipoGasto.SelectedIndex = 0;
            cbSectoCorrespondienteGasto.SelectedIndex = 0;
            txtObjetoContrato.Text = String.Empty;
            txtValorInicialContrato.Text = String.Empty;
            txtCedulaContratista.Text = String.Empty;
            txtNombreContratista.Text = String.Empty;
            cbTipoPersona.SelectedIndex = 0;
            dtFechaSuscripcionContrato.Value = DateTime.Now;
            txtCedulaInterventor.Text = String.Empty;
            txtNombreInterventor.Text = String.Empty;
            cbTipoVinculacion.SelectedIndex = 0;
            cbUnidadEjecucion.SelectedIndex = 0;
            txtNumeroUnidades.Text = String.Empty;
            cbAnticipoContrato.SelectedIndex = 0;
            txtValorAnticipos.Text = String.Empty;
            cbConstituyoFiducia.SelectedIndex = 0;
            dtFechaInicio.Value = DateTime.Now;
            dtFechaTerminacion.Value = DateTime.Now;
            cbPublicoSecop.SelectedIndex = 0;
        }

        /*Creo el metodo Cargar*/
        private void Cargar()
        {
            /*Creo una variable*/
            using (var context = new EntidadesContrato())
            {
                var sel = from abc in context.Personas select abc;
                dgDatos.DataSource = (from q in context.Personas select q).ToList();
                dgDatos.Refresh();
            }
        }

        /*Metodo Ingresar - Boton Ingresar*/
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            /*Creo la variable*/
            using (var contexto = new EntidadesContrato())
            {
                /*Valido los campos de las cajas de textos*/
                errorProvider.Clear();
                if (txtNumContrato.Text == string.Empty)
                {
                    /*Muestra Mensaje de Error*/
                    MessageBox.Show(this, "Debe ingresar el numero del contrato");
                }
                if (txtObjetoContrato.Text == String.Empty)
                {
                    MessageBox.Show(this, "Debe ingresar el objetivo del contrato");
                }
                else if (txtValorInicialContrato.Text == String.Empty)
                {
                    MessageBox.Show(this, "Debe ingresar el valor inicial");
                }
                else if (txtCedulaContratista.Text == String.Empty)
                {
                    MessageBox.Show(this, "Debe ingresar la cedula del contratista");
                }
                else if (txtNombreContratista.Text == string.Empty)
                {
                    MessageBox.Show(this, "Debe ingresar el nombre del contratista");
                }
                else if (txtCedulaInterventor.Text == String.Empty)
                {
                    MessageBox.Show(this, "Debe ingresar la cedula del interventor");
                }
                else if (txtNombreInterventor.Text == String.Empty)
                {
                    MessageBox.Show(this, "Debe ingresar el nombre del interventor");
                }
                else if (txtNumeroUnidades.Text == String.Empty)
                {
                    MessageBox.Show(this, "Debe ingresar el numero de unidades");
                }
                else if (txtValorAnticipos.Text == String.Empty)
                {
                    MessageBox.Show(this, "Debe ingresar el valor de los anticipos");
                }
                else if (cbConstituyoFiducia.Text == String.Empty)
                {
                    MessageBox.Show(this, "Debe ingresar la fiducia");
                }
                else
                {
                    /*Varible de Personas*/
                    var dato = new Personas()
                    {
                        NumContrato = txtNumContrato.Text,
                        ModalidadSeleccion = cbModalidadSeleccion.Text,
                        Procedimiento = cbProcedimiento.Text,
                        ClaseContrato = cbClaseContrato.Text,
                        TipoGasto = cbTipoGasto.Text,
                        SectorCorrespondiente = cbSectoCorrespondienteGasto.Text,
                        ObjetoContrato = txtObjetoContrato.Text,
                        ValorInicial = Convert.ToInt32(txtValorInicialContrato.Text),
                        CedulaContratista = Convert.ToInt32(txtCedulaContratista.Text),
                        NombreCompletoContratista = txtNombreContratista.Text,
                        TipoPersona = cbTipoPersona.Text,
                        FechaSuscripcion = Convert.ToDateTime(dtFechaSuscripcionContrato.Value),
                        CedulaInterventor = Convert.ToInt32(txtCedulaInterventor.Text),
                        NombreCompletoInterventor = txtNombreInterventor.Text,
                        TipoVinculacionInterventor = cbTipoVinculacion.Text,
                        UnidadEjecucion = cbUnidadEjecucion.Text,
                        NumeroUnidadesEjecucion = txtNumeroUnidades.Text,
                        PactoAnticipo = cbAnticipoContrato.Text,
                        ValorAnticipo = txtValorAnticipos.Text,
                        FiduciaMercantil = cbConstituyoFiducia.Text,
                        FechaInicioContrato = Convert.ToDateTime(dtFechaInicio.Value),
                        FechaTerminacionContrato = Convert.ToDateTime(dtFechaTerminacion.Value),
                        PublicacionSecop = cbPublicoSecop.Text
                    };
                    /*Excepcion de errores*/
                    try
                    {
                        /*Adiciona el dato con objetos de la clase Personas*/
                        contexto.Personas.Add(dato);
                        /*Guarda los cambios*/
                        contexto.SaveChanges();
                        /*Mensaje*/
                        MessageBox.Show("Guardado Correctamente!");
                        /*Metodo cargar*/
                        Cargar();
                    }
                    catch (Exception error)
                    {
                        /*Mensaje de Error*/
                        MessageBox.Show(error.Message);
                    }
                    Limpiar();
                    Deshabilitar();
                }
            }
        }

        /*Metodo Nuevo - Boton Nuevo*/
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            /*llama al metodo Habilitar*/
            Habilitar();
        }

        /*Creo el Metodo de la Tabla*/
        private void dgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*variable entera que son las filas*/
            int indice = e.RowIndex;
            /*Incializa en 0 y  Valido*/
            if (indice >= 0)
            {
                /*De la Clase Personas agregueme los datos de todos los campos del formulario*/
                Personas context = ((Personas) (dgDatos.Rows[indice].DataBoundItem));
                txtId.Text = context.IdContrato.ToString();
                txtNumContrato.Text = context.NumContrato;
                cbModalidadSeleccion.Text = context.ModalidadSeleccion;
                cbProcedimiento.Text = context.Procedimiento;
                cbClaseContrato.Text = context.ClaseContrato;
                cbTipoGasto.Text = context.TipoGasto;
                cbSectoCorrespondienteGasto.Text = context.SectorCorrespondiente;
                txtObjetoContrato.Text = context.ObjetoContrato;
                txtValorInicialContrato.Text = context.ValorInicial.ToString();
                txtCedulaContratista.Text = context.CedulaContratista.ToString();
                txtNombreContratista.Text = context.NombreCompletoContratista;
                cbTipoPersona.Text = context.TipoPersona;
                dtFechaSuscripcionContrato.Text = context.FechaSuscripcion.ToString();
                txtCedulaInterventor.Text = context.CedulaInterventor.ToString();
                txtNombreInterventor.Text = context.NombreCompletoInterventor;
                cbTipoVinculacion.Text = context.TipoVinculacionInterventor;
                cbUnidadEjecucion.Text = context.UnidadEjecucion;
                txtNumeroUnidades.Text = context.NumeroUnidadesEjecucion;
                cbAnticipoContrato.Text = context.PactoAnticipo;
                txtValorAnticipos.Text = context.ValorAnticipo;
                cbConstituyoFiducia.Text = context.FiduciaMercantil;
                dtFechaInicio.Text = context.FechaInicioContrato.ToString();
                dtFechaTerminacion.Text = context.FechaTerminacionContrato.ToString();
                cbPublicoSecop.Text = context.PublicacionSecop;
                InitActualizar();
            }
        }

        /*Metodo al Inicializar los datos*/
        private void InitActualizar()
        {
            cbModalidadSeleccion.Enabled = true;
            cbProcedimiento.Enabled = true;
            cbClaseContrato.Enabled = true;
            cbTipoGasto.Enabled = true;
            cbSectoCorrespondienteGasto.Enabled = true;
            txtObjetoContrato.Enabled = true;
            txtValorInicialContrato.Enabled = true;
            txtCedulaContratista.Enabled = true;
            txtNombreContratista.Enabled = true;
            cbTipoPersona.Enabled = true;
            dtFechaSuscripcionContrato.Enabled = true;
            txtCedulaInterventor.Enabled = true;
            txtNombreInterventor.Enabled = true;
            cbTipoVinculacion.Enabled = true;
            cbUnidadEjecucion.Enabled = true;
            txtNumeroUnidades.Enabled = true;
            cbAnticipoContrato.Enabled = true;
            txtValorAnticipos.Enabled = true;
            cbConstituyoFiducia.Enabled = true;
            dtFechaInicio.Enabled = true;
            dtFechaTerminacion.Enabled = true;
            cbPublicoSecop.Enabled = true;
            btnActualizar.Enabled = true;
        }

        /*Metodo Cancelar - Boton Cancelar*/
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            /*Variable para dar un mensaje*/
            DialogResult result = MessageBox.Show("¿Está Seguro de Cancelar la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            /*Valido el mensaje*/
            if (result == DialogResult.Yes)
            {
                /*Cierra la ventana*/
                this.Close();
            }
        }

        /*Metodo Actualizar - Boton Actualizar*/
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            /*Valido si esta vacio los campos de texto*/
            if (txtNumContrato.Text == String.Empty)
            {
                MessageBox.Show(this, "Debe ingresar el numero del contrato");
            }
            if (txtObjetoContrato.Text == String.Empty)
            {
                MessageBox.Show(this, "Debe ingresar el objetivo del contrato");
            }
            else if (txtValorInicialContrato.Text == String.Empty)
            {
                MessageBox.Show(this, "Debe ingresar el valor inicial");
            }
            else if (txtCedulaContratista.Text == String.Empty)
            {
                MessageBox.Show(this, "Debe ingresar la cedula del contratista");
            }
            else if (txtNombreContratista.Text == string.Empty)
            {
                MessageBox.Show(this, "Debe ingresar el nombre del contratista");
            }
            else if (txtCedulaInterventor.Text == String.Empty)
            {
                MessageBox.Show(this, "Debe ingresar la cedula del interventor");
            }
            else if (txtNombreInterventor.Text == String.Empty)
            {
                MessageBox.Show(this, "Debe ingresar el nombre del interventor");
            }
            else if (txtNumeroUnidades.Text == String.Empty)
            {
                MessageBox.Show(this, "Debe ingresar el numero de unidades");
            }
            else if (txtValorAnticipos.Text == String.Empty)
            {
                MessageBox.Show(this, "Debe ingresar el valor de los anticipos");
            }
            else if (cbConstituyoFiducia.Text == String.Empty)
            {
                MessageBox.Show(this, "Debe ingresar la fiducia");
            }
            else
            {
                /*Creo una varible de la clase EntidadesContrato*/
                using (var context = new EntidadesContrato())
                {

                    int valor = Convert.ToInt32(txtId.Text);
                    if (txtId.Text != String.Empty)
                    {
                        Personas oContrato = context.Personas.Single(C => C.IdContrato == valor);
                        oContrato.NumContrato = txtNumContrato.Text;
                        oContrato.ModalidadSeleccion = cbModalidadSeleccion.Text;
                        oContrato.Procedimiento = cbProcedimiento.Text;
                        oContrato.ClaseContrato = cbClaseContrato.Text;
                        oContrato.TipoGasto = cbTipoGasto.Text;
                        oContrato.SectorCorrespondiente = cbSectoCorrespondienteGasto.Text;
                        oContrato.ObjetoContrato = txtObjetoContrato.Text;
                        oContrato.ValorInicial = Convert.ToDecimal(txtValorInicialContrato.Text);
                        oContrato.CedulaContratista = Convert.ToInt32(txtCedulaContratista.Text);
                        oContrato.NombreCompletoContratista = txtNombreContratista.Text;
                        oContrato.TipoPersona = cbTipoPersona.Text;
                        oContrato.FechaSuscripcion = dtFechaSuscripcionContrato.Value;
                        oContrato.CedulaInterventor = Convert.ToInt32(txtCedulaInterventor.Text);
                        oContrato.NombreCompletoInterventor = txtNombreInterventor.Text;
                        oContrato.TipoVinculacionInterventor = cbTipoVinculacion.Text;
                        oContrato.UnidadEjecucion = cbUnidadEjecucion.Text;
                        oContrato.NumeroUnidadesEjecucion = txtNumeroUnidades.Text;
                        oContrato.PactoAnticipo = cbAnticipoContrato.Text;
                        oContrato.ValorAnticipo = txtValorAnticipos.Text;
                        oContrato.FiduciaMercantil = cbConstituyoFiducia.Text;
                        oContrato.FechaInicioContrato = dtFechaInicio.Value;
                        oContrato.FechaTerminacionContrato = dtFechaTerminacion.Value;
                        oContrato.PublicacionSecop = cbPublicoSecop.Text;

                        /*Excepcion*/
                        try
                        {
                            /*Guarda los cambios*/
                            context.SaveChanges();
                            /*Muestra mensaje*/
                            MessageBox.Show("Actualización realizada correctamente", "Registro actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            /*Carga el metodo cargar*/
                            Cargar();
                            /*llama al metodo Deshabilitar*/
                            Deshabilitar();
                            /*llama al metodo limpiar*/
                            Limpiar();
                        }
                        catch (Exception exc)
                        {
                            /*Muestra el error consola*/
                            Console.WriteLine("Error: " + exc.Message);
                        }
                    }
                }
            }
        }

        /*Metodo Ver Informe - Boton Ver Informe*/
        private void button1_Click(object sender, EventArgs e)
        {
            /*Variable reporte*/
            var reporte = new Reportes();
            /*Muestra el control*/
            reporte.Show();
        }

        /*Metodo Eliminar - Boton Eliminar*/
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            /*valido si esta vacio*/
            if (txtId.Text != string.Empty)
            {
                /*Creo una varieble para mostrar el mensaje*/
                DialogResult result = MessageBox.Show("¿Seguro de eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                /*valido el mensaje*/
                if (result == DialogResult.Yes)
                {
                    using (var context = new EntidadesContrato())
                    {
                        /*Valido si esta lleno que me convierta los datos a entero*/
                        int valor = Convert.ToInt32(txtId.Text);
                        if (txtId.Text != String.Empty)
                        {
                            Personas oContratos = context.Personas.Single(C => C.IdContrato == valor);
                            /*variable de la clase Personas para eliminar de la tabla*/
                            context.Personas.Remove(oContratos);
                            /*Guarda los cambios*/
                            context.SaveChanges();
                            /*Muestra un mensaje de error*/
                            MessageBox.Show("Eliminado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            /*Llama ak metodo limpiar*/
                            Limpiar();
                        }
                        /*llama al metodo cargar*/
                        Cargar();
                        /*llama al metodo deshabilitar*/
                        Deshabilitar();
                    }
                }
            }
            else
            {
                /*Muestra Mensaje*/
                MessageBox.Show("Debe seleccionar un registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /*Metodo Buscar - Boton Buscar*/
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            /*Creo una varibale de la clase EntidadesContrato*/
            using (var context = new EntidadesContrato())
            {
                /*Valido el texto Buscar, si esta vacio*/
                if (txtBuscar.Text == String.Empty)
                {
                    /*Llama al metodo Cargar*/
                    Cargar();
                }
                else
                {
                    /*Creo un objeto para Buscar el Dato ingresado en el campo de texto*/
                    var Datos = (from q in context.Personas
                        where  q.NombreCompletoContratista.Contains(txtBuscar.Text)
                              || q.NombreCompletoInterventor.Contains(txtBuscar.Text)
                        select q).ToList();
                    /*valido, si esta vacio o no coinciden*/
                    if (Datos != null && Datos.Count == 0)
                    {
                        /*Muestra Mensaje Error*/
                        MessageBox.Show("No se encontraron resultados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        /*Tabla, muestra los datos*/
                        dgDatos.DataSource = Datos;
                    }
                }
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
