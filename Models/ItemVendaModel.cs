using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMvcUdemy.Models {
  public class ItemVendaModel {
    public string CodigoProduto { get; set; }
    public string Descricao { get; set; }
    public string Quantidade { get; set; }
    public string PrecoUnitario { get; set; }
    public string Total { get; set; }
  }
}
