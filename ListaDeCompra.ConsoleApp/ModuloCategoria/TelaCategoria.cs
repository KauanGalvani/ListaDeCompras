using System;
using System.Collections;
using System.Collections.Generic;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ListaDeCompra.ConsoleApp.ModuloCategoria;

public class TelaCategoria : TelaBase<Categoria>, ITelaOpcoes, ITelaCrud
{
    public TelaCategoria(RepositorioBase<Categoria> repositorio) : base("Categoria", repositorio)
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

        List<Categoria> categoria = repositorio.SelecionarTodos();

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

            Console.ResetColor();
        }
    }

    protected override Categoria ObterDadosCadastrais()
    {
        Console.Write("Digite o nome da categoria: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Digite a cor da categoria: ");

        Console.WriteLine("=============================================");
        Console.WriteLine("1 - Vermelho");
        Console.WriteLine("2 - Azul");
        Console.WriteLine("3 - Verde");
        Console.WriteLine("4 - Branco");
        Console.WriteLine("=============================================");
        string Cor = Console.ReadLine() ?? string.Empty;

        string corPorExtenso;

        if (Cor == "1")
        {
            corPorExtenso = "Vermelho";
        }
        else if (Cor == "2")
        {
            corPorExtenso = "Azul";
        }
        else if (Cor == "3")
        {
            corPorExtenso = "Verde";
        }
        else
        {
            corPorExtenso = "Branco";
        }

        return new Categoria(nome, corPorExtenso);
    }

    protected override List<string> ValidarRegistroDuplucado(Categoria novaEntidade, string? idIgnorado = null)
    {
        List<string> erros = new List<string>();

        List<Categoria> categorias = repositorio.SelecionarTodos();

        foreach (Categoria c in categorias)
        {
            if (c.Id != idIgnorado && c.Nome == novaEntidade.Nome)
            {
                erros.Add("Já existe uma categoria com este nome");
                break;
            }
        }

        return erros;
    }
}
