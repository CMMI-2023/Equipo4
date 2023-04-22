using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using MySql.Data.MySqlClient;

public class MySQLConnector
{
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    // Constructor
    public MySQLConnector()
    {
        Initialize();
    }

    // Inicialización de parámetros de conexión
    private void Initialize()
    {
        server = "localhost";  // Cambia este valor por la dirección de tu servidor MySQL
        database = "sistema_seguros"; // Cambia este valor por el nombre de tu base de datos
        uid = "root"; // Cambia este valor por el nombre de usuario de tu base de datos
        password = "123"; // Cambia este valor por la contraseña de tu usuario
        string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

        connection = new MySqlConnection(connectionString);
    }

    // Abre la conexión a la base de datos
    private bool OpenConnection()
    {
        try
        {
            connection.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            // Maneja los errores de conexión
            switch (ex.Number)
            {
                case 0:
                    Console.WriteLine("No se puede conectar al servidor de la base de datos.");
                    break;

                case 1045:
                    Console.WriteLine("Nombre de usuario o contraseña incorrectos.");
                    break;
            }
            return false;
        }
    }

    // Cierra la conexión a la base de datos
    private bool CloseConnection()
    {
        try
        {
            connection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    // Ejecuta una consulta SELECT en la base de datos
    public Dictionary<string, object>[] Select(string tableName)
    {
        string query = $"SELECT * FROM {tableName}";
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                // Crea un diccionario con los valores de cada fila
                Dictionary<string, object> row = new Dictionary<string, object>();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    row.Add(dataReader.GetName(i), dataReader.GetValue(i));
                }
                rows.Add(row);
            }

            dataReader.Close();
            this.CloseConnection();
        }

        return rows.ToArray();
    }

    // Ejecuta una consulta INSERT en la base de datos
    public bool Insert(string tableName, Dictionary<string, object> values)
    {
        string query = $"INSERT INTO {tableName} ({String.Join(", ", values.Keys)}) VALUES ({String.Join(", ", values.Keys.Select(k => $"@{k}"))})";

        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            foreach (var kvp in values)
            {
                cmd.Parameters.AddWithValue($"@{kvp.Key}", kvp.Value);
            }
            int rowsAffected = cmd.ExecuteNonQuery();
            this.CloseConnection();
            return rowsAffected > 0;
        }

        return false;
    }

    // Ejecuta una consulta DELETE en la base de datos
    public bool Delete(string tableName, string condition)
    {
        string query = $"DELETE FROM {tableName} WHERE {condition}";

        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            int rowsAffected = cmd.ExecuteNonQuery();
            this.CloseConnection();
            return rowsAffected > 0;
        }
    return false;
    }

    // Ejecuta una consulta UPDATE en la base de datos
    public bool Update(string tableName, Dictionary<string, object> values, string condition)
    {
        string setValues = String.Join(", ", values.Select(pair => $"{pair.Key}={pair.Value}"));
        string query = $"UPDATE {tableName} SET {setValues} WHERE {condition}";

        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            int rowsAffected = cmd.ExecuteNonQuery();
            this.CloseConnection();
            return rowsAffected > 0;
        }

        return false;
    }
}
