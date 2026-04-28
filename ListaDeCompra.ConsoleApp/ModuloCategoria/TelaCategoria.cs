using System;
using System.Collections;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ListaDeCompra.ConsoleApp.ModuloCategoria;

public class TelaCategoria : TelaBase
{

    private RepositorioBase repositorio;
    public TelaCategoria(RepositorioBase repositorio) : base("Categoria", repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de categoria");

        Console.WriteLine
        (
            "{0, -7} | {1, -20} | {2, -10}",
            "Id", "Nome", "Cor"


        );

        ArrayList categoria = repositorio.SelecionarTodos();

        foreach (Categoria c in categoria)
        {
            string corSelecionada = c.Cor;

            if (corSelecionada == "Vermelho")
                Console.ForegroundColor = ConsoleColor.Red;

            else if (corSelecionada == "Verde")
                Console.ForegroundColor = ConsoleColor.Green;

            else if (corSelecionada == "Azul")
                Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine
            (
                "{0, -7} | {1, -20} | {2, -10}",
                c.Id, c.Nome, c.Cor
            );

            Console.ReadLine();
        }
    }

    protected override EntidadeBase ObterDadosCadastrais()
    {
        Console.Write("Digite o nome da categoria: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite a cor da categoria: ");

        Console.WriteLine("=============================================");
        Console.WriteLine("1 - Vermelho");
        Console.WriteLine("2 - Azul");
        Console.WriteLine("3 - Verde");
        Console.WriteLine("4 - Branco");
        Console.WriteLine("=============================================");
        string Cor = Console.ReadLine() ?? string.Empty;

        string corPorExtenso;

        if (Cor != "1")
        {
            corPorExtenso = "Vermelho";
        }
        else if (Cor != "2")
        {
            corPorExtenso = "Azul";
        }
        else if (Cor != "3")
        {
            corPorExtenso = "Verde";
        }
        else
        {
            corPorExtenso = "Branco";
        }

        return new Categoria();
    }
}
