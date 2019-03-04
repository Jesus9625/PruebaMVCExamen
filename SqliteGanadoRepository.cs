using Dapper;
using Microsoft.Data.Sqlite;
using s102parcial1ingweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejemplo{

    public class SqliteGanadoRepository{
        private string constrc;

        public SqliteGanadoRepository(string v)
        {
            this.constrc = v;
        }

        public static void InitDatabase(string stringconnection){

            string stringConsulta = "CREATE TABLE IF NOT EXISTS GANADOS " +
                "( Id INTEGER KEY AUTOINCREMENT, " +
                "TipoAnimal TEXT NOT NULL, " +
                "Nombre TEXT NOT NULL, " +
                "Peso INTEGER NOT NULL, " +
                "Color TEXT NOT NULL);";

            var con = new SqliteConnection(stringconnection);
            var cmd = new SqliteCommand(stringConsulta);
                cmd.Connection = con;
                
                try{
                    con.Open();
                    cmd.ExecuteNonQuery();

                }
                catch(Exception ex){
                    Console.WriteLine(ex.Message);


                }

        }

        internal GanadoModel LeerPorId(int id)
        {
            var sql = "SELECT Id, TipoAnimal, Nombre, Peso, Color FROM GANADOS WHERE Id = @Id";

            using(var conn = new SqliteConnection(constrc)){

                var ganado = conn.QueryFirstOrDefault<GanadoModel>(sql, new {Id = id});
                return ganado;
            }
        }

        internal List<GanadoModel> LeerTodos()
        {
            var sql = "SELECT Id, TipoAnimal, Nombre, Peso, Color FROM GANADOS";

            using(var conn = new SqliteConnection(constrc)){

                var ganados = conn.Query<GanadoModel>(sql).ToList();
                return ganados;
            }
        }

        internal void Crear(GanadoModel model)
        {
            string sql = "INSERT INTO GANADOS (Id, TipoAnimal, Nombre, Peso, Color) VALUES (@Id, @TipoAnimal, @Nombre, @Peso, @Color)";
            using(var conn = new SqliteConnection(constrc)){

                conn.Execute(sql, model);
            }
        }

        internal void Actualizar(GanadoModel model)
        {
            string sql = "UPDATE GANADOS SET Id = @Id,  TipoAnimal = @TipoAnimal, Nombre = @Nombre, Peso = @Peso , Color = @Color WHERE Id = @Id;";
            using(var conn = new SqliteConnection(constrc)){

                conn.Execute(sql, model);
            }
        }

        internal void Borrar(int id)
        {
            string sql = "DELETE FROM GANADOS WHERE Id = @Id";
            using(var conn = new SqliteConnection(constrc)){

                conn.Execute(sql, new {Id = id});
            }
        }
    }





}