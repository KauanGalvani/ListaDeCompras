using System;
using System.Collections;
using System.Collections.Generic;
using ListaDeCompra.ConsoleApp.Compartilhado;
using ListaDeCompra.ConsoleApp.ModuloCategoria;
using ListaDeCompra.ConsoleApp.ModuloProduto;

namespace ListaDeCompra.ConsoleApp.ModuloProdutos;

public class TelaProduto : TelaBase<Produto>, ITelaOpcoes, ITelaCrud
{
    private RepositorioBase<Categoria> repositorioCategoria;

    public TelaProduto(RepositorioBase<Produto> repositorio, RepositorioBase<Categoria> repositorioCategoria) : base("produto", repositorio)
    {
        this.repositorioCategoria = repositorioCategoria;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Produto");

        Console.WriteLine
        (
            "{0, -7} | {1, -10} | {2, -20} | {3, -20} | {4, -20}",
            "Id", "Nome", "unidade de medida", "Preço do produto", "Categoria"
        );

        //

        List<Produto> produtos = repositorio.SelecionarTodos();

        foreach (Produto p in produtos)
        {
            Categoria c = p.Categoria;

            Console.WriteLine
            (
                "{0, -7} | {1, -10} | {2, -20} | {3, -20} | {4, -20}",
                p.Id, p.Nome, p.UnidadeDeMedida, p.PrecoProduto.ToString("C2"), c.Nome
            );

            Console.ResetColor();
        }
    }

    protected override Produto ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do Produto: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite a unidade de medida do Produto: ");
        string unidadeDeMedida = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o preço do Produto: ");
        double precoProduto = Convert.ToDouble(Console.ReadLine());

        string idSelecionado = SelecionarCategoria(); //erro nesta linha

        Categoria? categoriaSelecionada = (Categoria?)repositorioCategoria.SelecionarPorId(idSelecionado);

        if (categoriaSelecionada == null)
            throw new NullReferenceException("Não foi possivel selecinar esta categoria..");

        return new Produto(nome, unidadeDeMedida, precoProduto, categoriaSelecionada);
    }

    private string SelecionarCategoria()
    {
        Console.WriteLine
        (
            "{0, -7} | {1, -20} | {2, -10}",
            "Id", "Nome", "Cor"


        );

        List<Categoria> categorias = repositorioCategoria.SelecionarTodos();

        foreach (Categoria c in categorias)
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

            Console.WriteLine("================================");
        }

        string? idSelecionado;
        do
        {
            Console.Write("Digite o ID da categoria em que deseja guardar o produto: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);



        return idSelecionado;
    }

    protected override List<string> ValidarRegistroDuplicado(Produto? novaEntidade, string? idIgnorado = null)
    {
        List<string> erros = new List<string>();

        List<Produto> produtos = repositorio.SelecionarTodos();

        foreach (Produto p in produtos)
        {
            if (p.Id != idIgnorado && p.Nome == novaEntidade?.Nome)
            {
                erros.Add("Ja existe o produto com este Nome");
            }
        }

        return erros;
    }
}
