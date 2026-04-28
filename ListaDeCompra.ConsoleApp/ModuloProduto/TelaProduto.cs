using System;
using ListaDeCompra.ConsoleApp.Compartilhado;
using ListaDeCompra.ConsoleApp.ModuloProduto;

namespace ListaDeCompra.ConsoleApp.ModuloProdutos;

public class TelaProduto : TelaBase
{
    public TelaProduto(RepositorioBase repositorio) : base("produto", repositorio)
    {

    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        throw new NotImplementedException();
    }

    protected override EntidadeBase ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do Produto");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite a unidade de medida do Produto");
        string unidadeDeMedida = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o preço do Produto");
        decimal precoProduto = Convert.ToDecimal(Console.ReadLine());

        return new Produto(nome, unidadeDeMedida, precoProduto);
    }
}
