using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Programa
{
    public partial class FormAjustador : Form
    {

        MySQLConnector connector = new MySQLConnector();

        public FormAjustador()
        {
            InitializeComponent();


            LlenarDataGridView();
            Dictionary<string, object>[] clientes = connector.Select("clientes");
            for (int i = 0; i < clientes.Length; i++)
            {
                comboBox1.Items.Add(clientes[i]["nombre"].ToString());
            }
        }
        private void LlenarDataGridView()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Obtener los datos del conector
            Dictionary<string, object>[] rows = connector.Select("siniestro");
            Dictionary<string, object>[] vehiculos = connector.Select("vehiculos");
            Dictionary<string, object>[] clientes = connector.Select("clientes");

            // Agregar las columnas al DataGridView
            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("fecha", "Fecha");
            dataGridView1.Columns.Add("cliente_afectado", "Nombre Cliente");
            dataGridView1.Columns.Add("vehiculo_afectado", "Nombre Vehículo");
            dataGridView1.Columns.Add("danio_id", "Daño");

            // Establecer el número de filas del DataGridView al número de registros obtenidos
            dataGridView1.RowCount = rows.Length;

            // Agregar los valores a cada celda del DataGridView
            for (int i = 0; i < rows.Length; i++)
            {
                dataGridView1.Rows[i].Cells["id"].Value = rows[i]["id"];
                DateTime fecha = (DateTime)rows[i]["fecha"];
                dataGridView1.Rows[i].Cells["fecha"].Value = fecha.ToString("dd/MM/yyyy");

                // Obtener el nombre del cliente a partir de su id
                int cliente_id = Convert.ToInt32(rows[i]["cliente_afectado_id"]);
                string cliente_nombre = clientes[cliente_id - 1]["nombre"].ToString();
                dataGridView1.Rows[i].Cells["cliente_afectado"].Value = cliente_nombre;

                // Obtener el nombre del vehículo a partir de su id
                int vehiculo_id = Convert.ToInt32(rows[i]["vehiculo_afectado_id"]);
                Dictionary<string, object> vehiculo = vehiculos.FirstOrDefault(v => v.ContainsKey("id") && Convert.ToInt32(v["id"]) == vehiculo_id);
                if (vehiculo != null)
                {
                    string vehiculo_nombre = vehiculo["nombre"].ToString();
                    dataGridView1.Rows[i].Cells["vehiculo_afectado"].Value = vehiculo_nombre;
                }
                else
                {
                    dataGridView1.Rows[i].Cells["vehiculo_afectado"].Value = "ID de vehículo no encontrado";
                }

                if (Convert.ToInt32(rows[i]["danio_id"]) == 1)
                {
                    dataGridView1.Rows[i].Cells["danio_id"].Value = "reparable";
                }
                else if (Convert.ToInt32(rows[i]["danio_id"]) == 2)
                {
                    dataGridView1.Rows[i].Cells["danio_id"].Value = "no reparable";
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreClienteSeleccionado = comboBox1.SelectedItem.ToString();

            Dictionary<string, object>[] vehiculos = connector.Select("vehiculos");
            Dictionary<string, object>[] clientes = connector.Select("clientes");

            int idClienteSeleccionado = Convert.ToInt32(clientes.First(c => c["nombre"].ToString() == nombreClienteSeleccionado)["id"]);


            comboBox2.Items.Clear(); // limpiar los items anteriores
            foreach (var vehiculo in vehiculos)
            {
                if (Convert.ToInt32(vehiculo["cliente_id"]) == idClienteSeleccionado)
                {
                    comboBox2.Items.Add(vehiculo["nombre"].ToString());
                }
            }


            comboBox2.Enabled = true;


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
                // Obtener el nombre del vehículo seleccionado
                string nombreVehiculoSeleccionado = comboBox2.SelectedItem.ToString();

                // Conectarse a la base de datos y crear el comando SQL para obtener el estado del vehículo seleccionado
                // ...
                // Ejecutar el comando SQL y obtener el estado del vehículo seleccionado
                // ...
                comboBox3.Items.Clear();
                // Habilitar el tercer ComboBox
                comboBox3.Enabled = true;

                // Cargar los valores "reparable" y "no reparable" en el tercer ComboBox
                comboBox3.Items.Add("reparable");
                comboBox3.Items.Add("no reparable");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener los valores seleccionados por el usuario
            string cliente = comboBox1.SelectedItem.ToString();
            string vehiculo = comboBox2.SelectedItem.ToString();
            string danio = comboBox3.SelectedItem.ToString();
            DateTime fecha = dateTimePicker1.Value;
            string fechaString = fecha.ToString("yyyy-MM-dd");


            Dictionary<string, object>[] vehiculos = connector.Select("vehiculos");
            Dictionary<string, object>[] clientes = connector.Select("clientes");

            int idClienteSeleccionado = Convert.ToInt32(clientes.First(c => c["nombre"].ToString() == cliente)["id"]);
            int idVehiculoSeleccionado = Convert.ToInt32(vehiculos.First(c => c["nombre"].ToString() == vehiculo)["id"]);
            int idDanio = 0;
            if(danio == "reparable")
            {
                 idDanio = 1;
            }
            else
            {
                 idDanio = 2;
            }
            // Crear un diccionario con los valores de la nueva fila
            Dictionary<string, object> values = new Dictionary<string, object>();
            values.Add("fecha", fechaString);
            values.Add("cliente_afectado_id", idClienteSeleccionado);
            values.Add("vehiculo_afectado_id", idVehiculoSeleccionado);
            values.Add("danio_id", idDanio);

            // Insertar la nueva fila en la tabla siniestros
            bool result = connector.Insert("siniestro", values);

            // Si la inserción fue exitosa, refrescar el DataGridView
            if (result)
            {
                LlenarDataGridView();
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox1.Text = "";
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Desactivar temporalmente el evento UserDeletingRow
            dataGridView1.UserDeletingRow -= dataGridView1_UserDeletingRow;

            try
            {
                // Obtener la fila seleccionada
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;

                    // Obtener el valor del ID de la fila seleccionada
                    int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["id"].Value);

                    // Ejecutar la consulta DELETE en la base de datos
                    string tableName = "siniestro";
                    string condition = $"id = {id}";
                    bool success = connector.Delete(tableName, condition);

                    if (success)
                    {
                        MessageBox.Show("La fila ha sido eliminada correctamente.");
                        LlenarDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error al eliminar la fila.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona la fila que deseas eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo siento, ha ocurrido un error inesperado: {ex.Message}");
            }
            finally
            {
                // Volver a activar el evento UserDeletingRow
                dataGridView1.UserDeletingRow += dataGridView1_UserDeletingRow;
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                // Obtener el valor del ID de la fila seleccionada
                int id = Convert.ToInt32(e.Row.Cells["id"].Value);

                // Ejecutar la consulta DELETE en la base de datos
                string tableName = "siniestro";
                string condition = $"id = {id}";
                bool success = connector.Delete(tableName, condition);

                if (success)
                {
                    MessageBox.Show("La fila ha sido eliminada correctamente.");
                    LlenarDataGridView();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al eliminar la fila.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo siento, ha ocurrido un error inesperado: {ex.Message}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                DataGridViewCell cell = dataGridView1.SelectedCells[0];

                // Obtener el valor de la celda seleccionada
                string columnName = cell.OwningColumn.Name;
                string value = cell.Value.ToString();

                // preparar consultas
                if (columnName == "id")
                {
                    // Mostrar el InputBox para ingresar el nuevo valor
                    string newValue = Interaction.InputBox($"Ingresa el nuevo valor para {columnName}:", "Actualizar valor", value);
                    // Verificar si el usuario ingresó un valor
                    if (!string.IsNullOrEmpty(newValue))
                    {
                        // Verificar si el valor ingresado es un número
                        if (!int.TryParse(newValue, out int newId))
                        {
                            MessageBox.Show("El valor ingresado no es un número válido. Por favor, ingresa un número entero.");
                            return;
                        }

                        // Verificar si el nuevo valor ya existe en el DataGridView
                        bool duplicateFound = false;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Index != dataGridView1.CurrentRow.Index && row.Cells["id"].Value.ToString() == newValue)
                            {
                                duplicateFound = true;
                                break;
                            }
                        }

                        if (duplicateFound)
                        {
                            MessageBox.Show($"El valor {newValue} ya existe en la tabla y no se puede usar como nuevo id.");
                            return;
                        }

                        // Actualizar el valor en la base de datos
                        string tableName = "siniestro";
                        int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
                        string condition = $"`id` = {id}";
                        Dictionary<string, object> values = new Dictionary<string, object>
                        {
                            { columnName, newValue }
                        };
                        bool success = connector.Update(tableName, values, condition);

                        if (success)
                        {
                            MessageBox.Show("El valor ha sido actualizado correctamente.");
                            LlenarDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error al actualizar el valor.");
                        }
                    }

                }
                else if (columnName == "fecha")
                {
                    // Validar el formato de la fecha
                    // Crear un nuevo control TimePicker y configurarlo
                    FrmTimePicker form = new FrmTimePicker();

                    // Especificar el formulario padre y establecer la propiedad StartPosition en CenterParent
                    form.Owner = this; // this hace referencia al formulario que llama a FrmTimePicker
                    form.StartPosition = FormStartPosition.CenterParent;

                    // Mostrar el formulario FrmTimePicker como un cuadro de diálogo modal
                    form.ShowDialog();
                    // Se ejecuta después de que se cierra el formulario secundario
                    if (form.DialogResult == DialogResult.OK)
                    {
                        DateTime fechaSeleccionada = form.FechaSeleccionada;
                        MessageBox.Show(fechaSeleccionada.ToString());
                        // Haz lo que necesites con la fecha seleccionada
                    }
                    //Regex regex = new Regex(@"^\d{4}-\d{2}-\d{2}$");
                    //if (!regex.IsMatch(value))
                    //{
                    //    MessageBox.Show("El formato de la fecha debe ser yyyy-MM-dd.");
                    //    return;
                    //}
                }
                else if(columnName == "cliente_afectado")
                {
                    
                }
                else if(columnName == "vehiculo_afectado")
                {
                    
                }
                else if(columnName == "danio")
                {
                    
                }
                else
                {
                    MessageBox.Show("No se puede actualizar esta columna.");
                    return;
                }

            }
            else
            {
                MessageBox.Show("Por favor, selecciona la celda que deseas actualizar.");
            }
        }
    }
}
