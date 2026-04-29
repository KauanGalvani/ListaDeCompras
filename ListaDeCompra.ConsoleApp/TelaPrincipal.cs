using ListaDeCompra.ConsoleApp.Compartilhado;
using ListaDeCompra.ConsoleApp.ModuloCategoria;
using ListaDeCompra.ConsoleApp.ModuloProduto;
using ListaDeCompra.ConsoleApp.ModuloProdutos;

class TelaPrincipal
{
    private RepositorioCategoria repositorioCategoria = new RepositorioCategoria();
    private RepositorioProduto repositorioProduto = new RepositorioProduto();


    public TelaPrincipal()
    {
        Categoria categoria = new Categoria("Compras do mes", "Vermelho");
        repositorioCategoria.Cadastrar(categoria);

        Produto produto = new Produto("Detergente", "Litros", 10);
        repositorioProduto.Cadastrar(produto);
    }
    public ITelaOpcoes? ApresentarMenuOpcao()
    {
        //Console.Clear();
        Console.WriteLine("==================================");
        Console.WriteLine("Lista de Compras");
        Console.WriteLine("==================================");
        Console.WriteLine("1 - Gerenciar categorias");
        Console.WriteLine("2 - Gerenciar produtos");
        Console.WriteLine("3 - Gerenciar listas de compras");
        Console.WriteLine("4 - Gerenciar itens de listas de compras");
        Console.WriteLine("S - Sair");
        Console.WriteLine("==================================");
        Console.Write("> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
            return new TelaCategoria(repositorioCategoria);
        else if (opcaoMenuPrincipal == "2")
            return new TelaProduto(repositorioProduto);

        return null;
    }
}
