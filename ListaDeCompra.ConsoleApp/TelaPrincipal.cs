using ListaDeCompra.ConsoleApp.Compartilhado;
using ListaDeCompra.ConsoleApp.ModuloCategoria;
using ListaDeCompra.ConsoleApp.ModuloIteins;
using ListaDeCompra.ConsoleApp.ModuloListaDeCompras;
using ListaDeCompra.ConsoleApp.ModuloProduto;
using ListaDeCompra.ConsoleApp.ModuloProdutos;

class TelaPrincipal
{
    private RepositorioCategoria repositorioCategoria = new RepositorioCategoria();
    private RepositorioProduto repositorioProduto = new RepositorioProduto();
    private RepositorioListaDeCompra repositorioListaDeCompra = new RepositorioListaDeCompra();
    private RepositorioItem repositorioItem = new RepositorioItem();

    public TelaPrincipal()
    {
        Categoria categoria = new Categoria("Compras do mes", "Vermelho");
        repositorioCategoria.Cadastrar(categoria);

        Produto produto = new Produto("Detergente", "Litros", 10, categoria);
        repositorioProduto.Cadastrar(produto);

        ListaCompra listaDeCompra = new ListaCompra("Limpeza", DateTime.Now, Status.aberto);
        repositorioListaDeCompra.Cadastrar(listaDeCompra);

        Iteim item = new Iteim(produto, 2, listaDeCompra);
        repositorioItem.Cadastrar(item);

        //testes
        ListaCompra listaDeCompra2 = new ListaCompra("Area de serviço", DateTime.Now, Status.aberto);
        repositorioListaDeCompra.Cadastrar(listaDeCompra2);

        Iteim item2 = new Iteim(produto, 100, listaDeCompra2);
        repositorioItem.Cadastrar(item2);
    }
    public ITelaOpcoes? ApresentarMenuOpcao()
    {
        //Console.Clear();
        Console.WriteLine("==================================");
        Console.WriteLine("Lista de Compras");
        Console.WriteLine("==================================");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("1 - Gerenciar categorias");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("2 - Gerenciar produtos");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("3 - Gerenciar listas de compras");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("4 - Gerenciar itens de listas de compras");
        Console.ResetColor();

        Console.WriteLine("S - Sair");
        Console.WriteLine("==================================");
        Console.Write(">> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
            return new TelaCategoria(repositorioCategoria);
        else if (opcaoMenuPrincipal == "2")
            return new TelaProduto(repositorioProduto, repositorioCategoria);
        else if (opcaoMenuPrincipal == "3")
            return new TelaListaDeCompra(repositorioListaDeCompra);
        else if (opcaoMenuPrincipal == "4")
            return new TelaItem(repositorioItem, repositorioListaDeCompra, repositorioProduto);
        return null;
    }
}
