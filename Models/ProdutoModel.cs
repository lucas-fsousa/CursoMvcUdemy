using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Utilidades;

namespace CursoMvcUdemy.Models {
  public class ProdutoModel {

    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o Nome do Produto!")]
    [DataType(DataType.Text)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Designe a descrição do produto!")]
    [DataType(DataType.Text)]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "Informe o preço por unidade")]
    [DataType(DataType.Text)]
    [Range(0, 9999999999999999.99)]
    public decimal PrecoUnitario { get; set; }

    [Required(ErrorMessage = "Informe a quantidade em estoque")]
    public int QuantidadeEstoque { get; set; }

    [Required(ErrorMessage = "Informe a unidade de medida")]
    [DataType(DataType.Text)]
    public string UnidadeMedida { get; set; }

    [Required(ErrorMessage = "Informe o link da imagem")]
    [DataType(DataType.ImageUrl)]
    public string LinkFoto { get; set; }

    public static List<ProdutoModel> ListarTodos() {
      List<ProdutoModel> list = new List<ProdutoModel>();
      string sqlquery = @"SELECT * FROM produto";
      foreach(DataRow row in Database.RetornaInfoTable(sqlquery).Rows) {
        ProdutoModel produto = new ProdutoModel();
        produto.Id = Int32.Parse(row["id"].ToString());
        produto.Nome = row["nome"].ToString();
        produto.Descricao = row["descricao"].ToString();
        produto.PrecoUnitario = decimal.Parse(row["preco_unit"].ToString());
        produto.QuantidadeEstoque = Int32.Parse(row["quantidade_estoque"].ToString());
        produto.UnidadeMedida = row["unidade_medida"].ToString();
        produto.LinkFoto = row["link_foto"].ToString();
        list.Add(produto);
      }
      return list;
    }

    public static ProdutoModel ListaProduto(int id) {
      string sqlquery = @$"SELECT * FROM produto WHERE id = '{id}'";
      ProdutoModel produto = new ProdutoModel();
      foreach(DataRow row in Database.RetornaInfoTable(sqlquery).Rows) {
        produto.Id = Int32.Parse(row["id"].ToString());
        produto.Nome = row["nome"].ToString();
        produto.Descricao = row["descricao"].ToString();
        produto.PrecoUnitario = decimal.Parse(row["preco_unit"].ToString());
        produto.QuantidadeEstoque = Int32.Parse(row["quantidade_estoque"].ToString());
        produto.UnidadeMedida = row["unidade_medida"].ToString();
        produto.LinkFoto = row["link_foto"].ToString();
      }
      return produto;
    }

    public void InsertEdit() {
      //this.PrecoUnitario = decimal.Parse(this.PrecoUnitario.ToString().Replace(",", "."));
      string sqlquery = "";
      if(this.Id != 0) { // Update
        sqlquery = $@"UPDATE produto set nome = '{this.Nome}', descricao = '{this.Descricao}', preco_unit = '{this.PrecoUnitario}', quantidade_estoque = '{this.QuantidadeEstoque}', unidade_medida = '{this.UnidadeMedida}', link_foto = '{this.LinkFoto}' WHERE id = {this.Id}";
      } else { // Insert
        sqlquery = $@"INSERT INTO produto (nome, descricao, preco_unit, quantidade_estoque, unidade_medida, link_foto) values ('{this.Nome}', '{this.Descricao}', '{this.PrecoUnitario}', '{this.QuantidadeEstoque}', '{this.UnidadeMedida}', '{this.LinkFoto}')";
      }
      Database.ExecutarComando(sqlquery);
    }

    public static void Deletar(int id) {
      string sqlquery = $@"DELETE FROM produto WHERE id = '{id}'";
      Database.ExecutarComando(sqlquery);
    }


  }
}
