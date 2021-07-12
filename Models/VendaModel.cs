using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Utilidades;

namespace CursoMvcUdemy.Models {
  public class VendaModel {

    public int Id { get; set; }

    [Required(ErrorMessage = "Informe a data")]
    [DataType(DataType.Date)]
    public DateTime Data { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    [Range(0, 9999999999999999.99)]
    public decimal Total { get; set; }

    [Required]
    public int VendedorId { get; set; }

    [Required]
    public int ClienteId { get; set; }

    [Required]
    public int ProdutoId { get; set; }

    public string ListaProdJson { get; set; }

    public static List<ClienteModel> RetornaClientes() {
      return ClienteModel.ListarTodos();
    }

    public static List<VendedorModel> RetornaVendedores() {
      return VendedorModel.ListarTodos();
    }

    public static List<ProdutoModel> RetornaProdutos() {
      return ProdutoModel.ListarTodos();
    }

    public static List<Dictionary<string, string>> ListaVendasDetalhadas() {
      List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
      string sqlquery_select = @$"SELECT venda.Id, venda.Data, venda.Total, cliente.Name as 'NomeCliente', vendedor.Name as 'NomeVendedor' FROM venda INNER JOIN Cliente ON cliente.id = ClienteId INNER JOIN vendedor ON vendedor.Id = VendedorId";
      DataTable table = Database.RetornaInfoTable(sqlquery_select);
      foreach(DataRow row in table.Rows) {
        Dictionary<string, string> detalhe_venda = new Dictionary<string, string>();
        detalhe_venda.Add("IdVenda", row["id"].ToString());
        detalhe_venda.Add("NomeVendedor", row["NomeVendedor"].ToString());
        detalhe_venda.Add("NomeCliente", row["NomeCliente"].ToString());
        detalhe_venda.Add("TotalVenda", row["total"].ToString());
        detalhe_venda.Add("DataVenda", row["data"].ToString());
        list.Add(detalhe_venda);
      }
      return list;
    }


    public static List<VendaModel> ListaVendas() {
      List<VendaModel> list = new List<VendaModel>();      
      string sqlquery_select = @$"SELECT venda.Id, venda.ClienteId, venda.Data, venda.Total, venda.VendedorId, cliente.Name, vendedor.Name FROM venda INNER JOIN Cliente ON cliente.id = ClienteId INNER JOIN vendedor ON vendedor.Id = VendedorId";
      DataTable table = Database.RetornaInfoTable(sqlquery_select);
      foreach(DataRow row in table.Rows) {
        var venda = new VendaModel();
        venda.Id = Convert.ToInt32(row["id"]);
        venda.Data = Convert.ToDateTime(row["data"]);
        venda.Total = Convert.ToDecimal(row["total"]);
        venda.VendedorId = Convert.ToInt32(row["vendedorid"]);
        venda.ClienteId = Convert.ToInt32(row["clienteid"]);
        list.Add(venda);
      }
      return list;
    }

    public void Inserir() {
      this.Data = DateTime.Now;
      string nome_tabela = "venda";

      string sql_insert = @$"INSERT INTO {nome_tabela} VALUES ('{this.Data}', '{this.Total}', {this.VendedorId}, {this.ClienteId})";
      string sql_select = @$"SELECT * FROM {nome_tabela} WHERE id = SCOPE_IDENTITY()";
      var idvenda = Database.ExecutaComandoRetornaID(sql_insert, sql_select);
      if(idvenda != -1) {
        List<ItemVendaModel> itemvendamodel = JsonConvert.DeserializeObject<List<ItemVendaModel>>(ListaProdJson);
        foreach(var item in itemvendamodel) {
          string sqlquery = $@"INSERT INTO itemvenda VALUES ({idvenda}, {item.CodigoProduto}, {item.Quantidade}, {item.PrecoUnitario.Replace(",", ".")})";
          Database.ExecutarComando(sqlquery);
        }
      } 
      
    }
  }
}
