// ================= VIEW REGISTRAR VENDA ===================//
var itens = new Object();
itens.Produtos = new Array();
function ListarItensVenda() {

    var listaprod = document.getElementById('listaprodutos');
    var quantidade = document.getElementById('quantidade');
    var produtoid = document.getElementById('produtoid');
    var recebetotal = document.getElementById('recebetotal');
    var guardaJsonProduto = document.getElementById('guardaJsonProduto');
    var input_total_text = document.getElementById('input-total-text');

    var nome_preco = produtoid.options[produtoid.selectedIndex].text;
    nome_preco = nome_preco.split('|');
    var total = (nome_preco[1].replace(",", ".") * quantidade.value);
    total = Math.round(total * 100) / 100;

    itens.Produtos.push({
        "CodigoProduto": produtoid.value,
        "Descricao": nome_preco[0],
        "Quantidade": quantidade.value,
        "PrecoUnitario": nome_preco[1],
        "Total": total
    });

    guardaJsonProduto.innerHTML = JSON.stringify(itens.Produtos);

    var produto = `<tr>
    <td>${produtoid.value}</td>
    <td>${nome_preco[0]}</td>
    <td>${quantidade.value}</td>
    <td>R$${nome_preco[1]}</td>
    <td>R$${total}</td>
    </tr>`
    listaprod.innerHTML += produto;
    var total_geral = Math.round((recebetotal.innerText * 1 + total) * 100) / 100;
    recebetotal.innerHTML = total_geral;
    input_total_text.value = total_geral;
}

function clearTextArea() {
    guardaJsonProduto.innerHTML = '';
}


