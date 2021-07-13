using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Utilidades;
namespace CursoMvcUdemy.Models {
  public class RelatorioModel {

    [Required]
    [DataType(DataType.Date)]
    public string DataInicio { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public string DataFim { get; set; }

    public List<Dictionary<string, string>> FiltroListaVendasDetalhadas() {
      List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
      this.DataInicio = UtilidadesGerais.SlicingStringDate(this.DataInicio);
      this.DataFim = UtilidadesGerais.SlicingStringDate(this.DataFim);
      if(!this.DataFim.Equals("") || !this.DataInicio.Equals("")) {
        string sqlquery_select = @$"SELECT venda.Id, venda.Data, venda.Total, cliente.Name as 'NomeCliente', vendedor.Name as 'NomeVendedor' FROM venda INNER JOIN Cliente ON cliente.id = ClienteId INNER JOIN vendedor ON vendedor.Id = VendedorId WHERE venda.data >= '{this.DataInicio}' AND venda.data <= '{this.DataFim}'";
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
      }
      return list;
    }
  }
}
