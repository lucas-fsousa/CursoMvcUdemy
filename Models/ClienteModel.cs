using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ConnectionConfig;
using Utilidades;

namespace CursoMvcUdemy.Models {
  public class ClienteModel {
    public int Id { get; set; }

    [Required(ErrorMessage= "Informe o Nome do Cliente!")]
    [DataType(DataType.Text)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Informe o Cpf do Cliente!")]
    [DataType(DataType.Text)]
    public string Cpf { get; set; }

    public static List<ClienteModel> ListarTodos() {
      List<ClienteModel> list = new List<ClienteModel>();
      string sqlquery = @"SELECT * FROM cliente";
      foreach(DataRow row in Database.RetornaInfoTable(sqlquery).Rows) {
        ClienteModel cliente = new ClienteModel();
        cliente.Id = Int32.Parse(row["id"].ToString());
        cliente.Nome = row["name"].ToString();
        cliente.Cpf = row["cpf"].ToString();
        list.Add(cliente);
      }
      return list;
    }

    public static ClienteModel ListaCliente(int id) {
      string sqlquery = @$"SELECT * FROM cliente WHERE id = '{id}'";
      ClienteModel cliente = new ClienteModel();
      foreach(DataRow row in Database.RetornaInfoTable(sqlquery).Rows) {
        cliente.Id = Int32.Parse(row["id"].ToString());
        cliente.Nome = row["name"].ToString();
        cliente.Cpf = row["cpf"].ToString();
      }
      return cliente;
    }

    public void InsertEdit() {
      string sqlquery = "";
      if(this.Id != 0) {
        sqlquery = $@"UPDATE cliente set name = '{this.Nome}', cpf = '{this.Cpf}' WHERE id = {this.Id}";
      } else {
        sqlquery = $@"INSERT INTO Cliente (name, cpf) values ('{this.Nome}', '{this.Cpf}')";
      }
      
      Database.ExecutarComando(sqlquery);
    }

    public static void Deletar(int id) {
      string sqlquery = $@"DELETE FROM cliente WHERE id = '{id}'";
      Database.ExecutarComando(sqlquery);
    }

  }
}
