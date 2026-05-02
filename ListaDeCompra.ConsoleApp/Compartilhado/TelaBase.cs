using System;
using System.Collections.Generic;
using ListaDeCompra.ConsoleApp.ModuloCategoria;

namespace ListaDeCompra.ConsoleApp.Compartilhado;

public abstract class TelaBase<T> where T : EntidadeBase
{
    public string nomeEntidade = string.Empty;
    protected RepositorioBase<T> repositorio;

    protected TelaBase(string nomeEntidade, RepositorioBase<T> repositorio)
    {
        this.nomeEntidade = nomeEntidade;
        this.repositorio = repositorio;
    }

    public string? ObterOpcaoMenu()
    {
        string nomeMinusculo = nomeEntidade.ToLower();

        Console.Clear();

        if (nomeEntidade == "Categoria")
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        else if (nomeEntidade == "Produto")
            Console.ForegroundColor = ConsoleColor.Gray;
        else if (nomeEntidade == "Lista de compra")
            Console.ForegroundColor = ConsoleColor.Magenta;

        Console.WriteLine("==============================================");
        Console.WriteLine($"Gestão de {nomeEntidade}");
        Console.WriteLine("==============================================");
        Console.WriteLine($"1 - Cadastrar {nomeMinusculo}");
        Console.WriteLine($"2 - Editar {nomeMinusculo}");
        Console.WriteLine($"3 - Excluir {nomeMinusculo}");
        Console.WriteLine($"4 - Visualizar {nomeMinusculo}s");
        Console.WriteLine("S - Voltar para o início");
        Console.WriteLine("==============================================");
        Console.Write(">> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();
        Console.ResetColor();

        return opcaoMenu;
    }

    protected virtual List<string> ValidarRegistroDuplucado(T novaEntidade, string? idIgnorado = null)
    {
        return new List<string>();
    }

    public void Cadastrar()
    {
        ExibirCabecalho($"Cadastro de {nomeEntidade}");

        T novaEntidade = ObterDadosCadastrais();

        string[] erros = novaEntidade.Validar();

        if (erros.Length > 0)
        {
            // adicionar uma classe statica para mostrar os erros
            Console.WriteLine("==============================================");

            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < erros.Length; i++)
            {
                string erro = erros[i];

                Console.WriteLine(erro);
            }

            Console.ResetColor();
            Console.WriteLine("==============================================");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();

            Cadastrar();
            return;
        }

        List<string> errosDuplicacao = ValidarRegistroDuplucado(novaEntidade);

        if (errosDuplicacao.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("===============================");
            Console.WriteLine("Erro nome duplicado");
            Console.ResetColor();
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();

            Cadastrar();
        }

        repositorio.Cadastrar(novaEntidade);

        ExibirMensagem($"O registro \"{novaEntidade.Id}\" foi cadastrado com sucesso!");
    }

    public void Editar()
    {
        ExibirCabecalho($"Edição de {nomeEntidade}");

        VisualizarTodos(deveExibirCabecalho: false);

        Console.WriteLine("==============================================");

        string? idSelecionado;

        do
        {
            Console.Write("Digite o ID do registro que deseja editar: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        Console.WriteLine("==============================================");

        T novaEntidade = ObterDadosCadastrais();

        string[] erros = novaEntidade.Validar();

        if (erros.Length > 0)
        {
            Console.WriteLine("==============================================");

            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < erros.Length; i++)
            {
                string erro = erros[i];

                Console.WriteLine(erro);
            }

            Console.ResetColor();
            Console.WriteLine("==============================================");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();

            Editar();
            return;
        }

        List<string> errosDuplicacao = ValidarRegistroDuplucado(novaEntidade, idSelecionado);

        if (errosDuplicacao.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("===============================");
            Console.WriteLine("Erro nome duplicado");
            Console.ResetColor();
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();

            Cadastrar();
        }

        bool conseguiuEditar = repositorio.Editar(idSelecionado, novaEntidade);

        if (!conseguiuEditar)
        {
            ExibirMensagem("Não foi possível encontrar o registro requisitado.");
            return;
        }

        ExibirMensagem($"O registro \"{idSelecionado}\" foi editado com sucesso.");
    }

    public void Excluir()
    {
        ExibirCabecalho("Exclusão de Caixa");

        VisualizarTodos(deveExibirCabecalho: false);

        Console.WriteLine("==============================================");

        string? idSelecionado;

        do
        {
            Console.Write("Digite o ID do registro que deseja excluir: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        bool conseguiuExcluir = repositorio.Excluir(idSelecionado);

        if (!conseguiuExcluir)
        {
            ExibirMensagem("Não foi possível encontrar o registro requisitado.");
            return;
        }

        ExibirMensagem($"O registro \"{idSelecionado}\" foi excluído com sucesso.");
    }

    public abstract void VisualizarTodos(bool deveExibirCabecalho);

    protected void ExibirCabecalho(string titulo)
    {
        //Console.Clear();
        Console.WriteLine("==============================================");
        Console.WriteLine($"Gestão de {nomeEntidade}");
        Console.WriteLine("==============================================");
        Console.WriteLine(titulo);
        Console.WriteLine("==============================================");
    }

    protected void ExibirMensagem(string mensagem)
    {
        Console.WriteLine("==============================================");
        Console.WriteLine(mensagem);
        Console.WriteLine("==============================================");
        Console.Write("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    protected abstract T ObterDadosCadastrais();
}