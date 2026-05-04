using System;
using ListaDeCompra.ConsoleApp.Compartilhado;
using ListaDeCompra.ConsoleApp.ModuloListaDeCompras;
using ListaDeCompra.ConsoleApp.ModuloProduto;

namespace ListaDeCompra.ConsoleApp.ModuloIteins;

public class Item : EntidadeBase
{
    public Produto Produto { get; set; }
    public ListaCompra ListaDeCompra { get; set; }
    public double QuantidadeDeProduto { get; set; }
    public double ValorTotal
    {
        get
        {
            return Produto.PrecoProduto * QuantidadeDeProduto;
        }
    }

    public Item(Produto produto, double quantidadeDeProduto, ListaCompra listaDeCompra)
    {
        Produto = produto;
        QuantidadeDeProduto = quantidadeDeProduto;
        ListaDeCompra = listaDeCompra;
    }


    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Item itemAtualizado = (Item)entidadeAtualizada;

        Produto = itemAtualizado.Produto;
        ListaDeCompra = itemAtualizado.ListaDeCompra;
        QuantidadeDeProduto = itemAtualizado.QuantidadeDeProduto;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (Produto == null)
            erros += "O produto precisa ser escolhido;";
        if (ListaDeCompra == null)
            erros += "A lista deve ser escolhida;";
        if (QuantidadeDeProduto < 1)
            erros += "Informe uma quantidade valida de produto;";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }
}
