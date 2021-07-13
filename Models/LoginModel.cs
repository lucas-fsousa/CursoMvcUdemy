using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using ConnectionConfig;
using Utilidades;


namespace CursoMvcUdemy.Models {
  public class LoginModel {

    [MaxLength(10)]
    [StringLength(10)]
    [Required(ErrorMessage = "Campo de login necessário")]
    [DataType(DataType.Text)]
    public string Login { get; set; }

    [MaxLength(10)]
    [StringLength(10)]
    [Required(ErrorMessage = "Campo de senha necessário")]
    [DataType(DataType.Password)]
    public string Senha { get; set; }

    public int Id { get; set; }
    public string Nome { get; set; }

    public bool BuscarUsuario() {
      bool ok = false;
      SqlCommand cmd = new SqlCommand();
      cmd.CommandText = @"SELECT * FROM cadastro where login = @login and senha = @senha";
      cmd.Parameters.AddWithValue("@login", this.Login);
      cmd.Parameters.AddWithValue("@senha", this.Senha);

      DataTable table = Database.RetornaInfoTable(cmd);
      if(table.Rows.Count == 1) {
        this.Id = Int32.Parse(table.Rows[0]["id"].ToString());
        this.Nome = table.Rows[0]["nome"].ToString();
        ok = true;
      }
      return ok;
    }



  }
}

