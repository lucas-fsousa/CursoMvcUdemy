using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using ConnectionConfig;
using Utilidades;


namespace CursoMvcUdemy.Models {
  public class LoginModel {

    [Required(ErrorMessage = "Campo de login necessário")]
    [DataType(DataType.Text)]
    public string Login { get; set; }

    [Required(ErrorMessage = "Campo de senha necessário")]
    [DataType(DataType.Password)]
    public string Senha { get; set; }

    public int Id { get; set; }
    public string Nome { get; set; }

    public bool BuscarUsuario() {
      bool ok = false;
      string sqlquery = @$"SELECT * FROM cadastro where login = '{this.Login}' and senha = '{this.Senha}'";

      DataTable table = Database.RetornaInfoTable(sqlquery);
      if(table.Rows.Count == 1) {
        this.Id = Int32.Parse(table.Rows[0]["id"].ToString());
        this.Nome = table.Rows[0]["nome"].ToString();
        ok = true;
      }
      return ok;
    }



  }
}

