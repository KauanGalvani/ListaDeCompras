using System;
using System.Drawing;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ListaDeCompra.ConsoleApp.ModuloListaDeCompras;

public class TelaListaDeCompra : TelaBase<ListaCompra>, ITelaOpcoes, ITelaCrud
{
    public TelaListaDeCompra(RepositorioBase<ListaCompra> repositorio) : base("Lista de compra", repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Lista de  compra");

        Console.WriteLine
        (
            "{0, -7} | {1, -15} | {2, -21} | {3, -10}",
            "Id", "Nome", "Data", "Status"


        );

        List<ListaCompra> lista = repositorio.SelecionarTodos();

        foreach (ListaCompra l in lista)
        {

            Console.Write
            (
                "{0, -7} | {1, -15} | {2, -21} |",
                l.Id, l.Nome, l.DataDeCriacao
            );

            string statusAtual = string.Empty;

            if (l.StatusDaLista == Status.aberto)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                statusAtual = " Aberto";
            }
            else if (l.StatusDaLista == Status.concluido)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                statusAtual = " Concluido";
            }

            Console.WriteLine("{0, -10}", statusAtual);
            Console.ResetColor();
        }
    }

    protected override ListaCompra ObterDadosCadastrais()
    {
        DateTime dataCriacao = DateTime.Now;

        Console.Write("Digite o nome da lista que deseja cadastrar: ");
        string? nome = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("===============================");
        Console.WriteLine("qual o status da lista?");
        Console.WriteLine("===============================");
        Console.WriteLine("1 - Aberto");
        Console.WriteLine("2 - Concluido");
        Console.WriteLine("===============================");
        string? opcaoStatus = Console.ReadLine();

        if (opcaoStatus == "1")
            return new ListaCompra(nome, dataCriacao, Status.aberto);
        else if (opcaoStatus == "2")
            return new ListaCompra(nome, dataCriacao, Status.concluido);
        return new ListaCompra(nome, dataCriacao, Status.indefinido);



    }

    protected override List<string> ValidarRegistroDuplucado(ListaCompra novaEntidade, string? idIgnorado = null)
    {
        List<string> erros = new List<string>();

        List<ListaCompra> lista = repositorio.SelecionarTodos();

        foreach (ListaCompra l in lista)
        {
            if (l.Id != idIgnorado && l.Nome == novaEntidade.Nome)
            {
                erros.Add("Este nome já existe em uma outra lista similar");
            }
        }
        return erros;
    }
}
