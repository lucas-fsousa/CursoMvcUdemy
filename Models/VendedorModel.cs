using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Utilidades;

namespace CursoMvcUdemy.Models {
  public class VendedorModel {
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o Nome do Vendedor!")]
    [DataType(DataType.Text)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Informe o nome da empresa do vendedor!")]
    [DataType(DataType.Text)]
    public string NomeEpsRepresentante { get; set; }

    public static List<VendedorModel> ListarTodos() {
      List<VendedorModel> list = new List<VendedorModel>();
      string sqlquery = @"SELECT * FROM vendedor";
      foreach(DataRow row in Database.RetornaInfoTable(sqlquery).Rows) {
        VendedorModel vendedor = new VendedorModel();
        vendedor.Id = Int32.Parse(row["id"].ToString());
        vendedor.Nome = row["name"].ToString();
        vendedor.NomeEpsRepresentante = row["nomeepsrepresentante"].ToString();
        list.Add(vendedor);
      }
      return list;
    }

    public static VendedorModel ListaVendedor(int id) {
      string sqlquery = @$"SELECT * FROM vendedor WHERE id = '{id}'";
      VendedorModel vendedor = new VendedorModel();
      foreach(DataRow row in Database.RetornaInfoTable(sqlquery).Rows) {
        vendedor.Id = Int32.Parse(row["id"].ToString());
        vendedor.Nome = row["name"].ToString();
        vendedor.NomeEpsRepresentante = row["nomeepsrepresentante"].ToString();
      }
      return vendedor;
    }

    public bool InsertEdit() {
      string sqlquery = "";
      if(this.Id != 0) {
        sqlquery = $@"UPDATE vendedor set name = '{this.Nome}', nomeepsrepresentante = '{this.NomeEpsRepresentante}' WHERE id = {this.Id}";
      } else {
        sqlquery = $@"INSERT INTO vendedor (name, nomeepsrepresentante) values ('{this.Nome}', '{this.NomeEpsRepresentante}')";
      }

      return Database.ExecutarComando(sqlquery);
    }

    public static bool Deletar(int id) {
      string sqlquery = $@"DELETE FROM vendedor WHERE id = '{id}'";
      return Database.ExecutarComando(sqlquery);
    }


  }
}
