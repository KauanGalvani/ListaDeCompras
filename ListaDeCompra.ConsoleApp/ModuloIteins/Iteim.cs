using System;
using ListaDeCompra.ConsoleApp.Compartilhado;
using ListaDeCompra.ConsoleApp.ModuloListaDeCompras;
using ListaDeCompra.ConsoleApp.ModuloProduto;

namespace ListaDeCompra.ConsoleApp.ModuloIteins;

public class Iteim : EntidadeBase
{
    public Produto Produto { get; set; }
    public ListaCompra ListaDeCompra { get; set; }
    public decimal QuantidadeDeProduto { get; set; }


    public Iteim(Produto produto, decimal quantidadeDeProduto, ListaCompra listaDeCompra)
    {
        Produto = produto;
        QuantidadeDeProduto = quantidadeDeProduto;
        ListaDeCompra = listaDeCompra;
    }


    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Iteim itenAtualizado = (Iteim)entidadeAtualizada;

        Produto = itenAtualizado.Produto;
        QuantidadeDeProduto = itenAtualizado.QuantidadeDeProduto;
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
