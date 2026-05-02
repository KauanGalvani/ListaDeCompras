using System;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ListaDeCompra.ConsoleApp.ModuloListaDeCompras;

public class ListaCompra : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public DateTime DataDeCriacao { get; set; }
    public Status StatusDaLista { get; set; } // status

    public ListaCompra(string nome, DateTime dataDeCriacao, Status statusDaLista)
    {
        Nome = nome;
        DataDeCriacao = dataDeCriacao;
        StatusDaLista = statusDaLista;
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        ListaCompra listaAtualizada = (ListaCompra)entidadeAtualizada;

        Nome = listaAtualizada.Nome;
        DataDeCriacao = listaAtualizada.DataDeCriacao;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo Nome precisa ser preenchido";
        else if (Nome.Length < 3 || Nome.Length > 100)
            erros += "O campo Nome deve obter de 3 a 100 caracteres";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }
}
