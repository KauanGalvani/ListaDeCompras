using System;
using ListaDeCompra.ConsoleApp.Compartilhado;
using ListaDeCompra.ConsoleApp.ModuloCategoria;
using ListaDeCompra.ConsoleApp.ModuloListaDeCompras;
using ListaDeCompra.ConsoleApp.ModuloProduto;
using ListaDeCompra.ConsoleApp.ModuloProdutos;

namespace ListaDeCompra.ConsoleApp.ModuloIteins;

public class TelaItem : TelaBase<Iteim>, ITelaOpcoes, ITelaCrud
{
    private RepositorioListaDeCompra repositorioListaDeCompra = new RepositorioListaDeCompra();
    private RepositorioProduto repositorioProduto = new RepositorioProduto();
    public TelaItem(RepositorioBase<Iteim> repositorio, RepositorioListaDeCompra repositorioListaDeCompra, RepositorioProduto repositorioProduto) : base("Item", repositorio)
    {
        this.repositorioListaDeCompra = repositorioListaDeCompra;
        this.repositorioProduto = repositorioProduto;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Itens");

        Console.WriteLine
        (
            "{0, -7} | {1, -15} | {2, -21} | {3, -10}",
            "Id", "Produto", "Quantidade", "Lista de compra"


        );

        List<Iteim> itens = repositorio.SelecionarTodos();

        foreach (Iteim i in itens)
        {
            Produto p = i.Produto;
            ListaCompra l = i.ListaDeCompra;

            Console.WriteLine
            (
                "{0, -7} | {1, -15} | {2, -21} | {3, -10}",
                i.Id, p.Nome, i.QuantidadeDeProduto, l.Nome
            );


            // string statusAtual = string.Empty;

            // if (i.StatusDaLista == Status.aberto)
            // {
            //     Console.ForegroundColor = ConsoleColor.DarkYellow;
            //     statusAtual = " Aberto";
            // }
            // else if (i.StatusDaLista == Status.concluido)
            // {
            //     Console.ForegroundColor = ConsoleColor.DarkGreen;
            //     statusAtual = " Concluido";
            // }

            // Console.WriteLine("{0, -10}", statusAtual);
            // Console.ResetColor();
        }

        Console.WriteLine("Pressione ENTER para continuar...");
        Console.ReadLine();
    }

    protected override Iteim ObterDadosCadastrais()
    {
        Console.WriteLine("================================");
        Console.WriteLine("Selecione qual item deseja.");
        Console.WriteLine("================================");

        string? idSelecionadoProduto = SelecionarItem();

        Produto? produtoSelecionado = (Produto?)repositorioProduto.SelecionarPorId(idSelecionadoProduto);

        if (produtoSelecionado == null)
            throw new NullReferenceException("Não foi possivel selecinar este produto..");


        Console.Write("Digite a quantidade de produtos que deseja adicionar: ");
        decimal quantidade = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("================================");
        Console.WriteLine("Selecione qual lista deseja guardar este item.");
        Console.WriteLine("================================");

        string? idSelecionadoLista = SelecionarLista();

        ListaCompra? listaSelecionada = (ListaCompra?)repositorioListaDeCompra.SelecionarPorId(idSelecionadoLista);

        if (listaSelecionada == null)
            throw new NullReferenceException("Não foi possivel selecinar esta lista..");

        return new Iteim(produtoSelecionado, quantidade, listaSelecionada);

    }

    private string SelecionarItem()
    {
        Console.WriteLine
        (
            "{0, -7} | {1, -10} | {2, -20} | {3, -10} | {4, -20}",
            "Id", "Nome", "unidade de medida", "Preço", "Categoria"


        );

        List<Produto> produtos = repositorioProduto.SelecionarTodos();

        foreach (Produto p in produtos)
        {
            Categoria c = p.Categoria;

            Console.WriteLine
            (
                "{0, -7} | {1, -10} | {2, -20} | {3, -10} | {4, -20}",
                p.Id, p.Nome, p.UnidadeDeMedida, p.PrecoProduto.ToString("C2"), c.Nome
            );
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

    private string SelecionarLista()
    {
        Console.WriteLine
       (
            "{0, -7} | {1, -15} | {2, -21} | {3, -10}",
            "Id", "Nome", "Data", "Status"


       );

        List<ListaCompra> lista = repositorioListaDeCompra.SelecionarTodos();

        foreach (ListaCompra l in lista)
        {

            Console.Write
            (
                "{0, -7} | {1, -15} | {2, -21}",
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

    // protected override List<string> ValidarRegistroDuplicado(Iteim? novaEntidade = null, string? idIgnorado = null)
    // {
    //     List<string> erros = new List<string>();

    //     List<Iteim> itens = repositorio.SelecionarTodos();

    //     foreach (Iteim i in itens)
    //     {
    //         if (i.Id != idIgnorado)
    //         {
    //             erros.Add("Este produto ja foi adicionado a lista");
    //         }
    //     }

    //     return erros;
    // }
}
