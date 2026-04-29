using System;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ListaDeCompra.ConsoleApp.ModuloProduto;

public class Produto : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public string UnidadeDeMedida { get; set; } = string.Empty;
    public decimal PrecoProduto { get; set; }

    public Produto(string nome, string unidadeDeMedida, decimal precoProduto)
    {
        Nome = nome;
        UnidadeDeMedida = unidadeDeMedida;
        PrecoProduto = precoProduto;
    }



    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Produto produtoAtualizado = (Produto)entidadeAtualizada;

        Nome = produtoAtualizado.Nome;
        UnidadeDeMedida = produtoAtualizado.UnidadeDeMedida;
        PrecoProduto = produtoAtualizado.PrecoProduto;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (Nome.Length < 2 || Nome.Length > 200)
            erros += "O campo Nome deve possuir entre 2 a 200 caracteres;";

        else if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo Nome é obrigatorio;";

        else if (!Nome.All(char.IsLetter))
            erros += "O campo Nome Não pode conter numeros;";


        if (UnidadeDeMedida.Length < 2 || UnidadeDeMedida.Length > 20)
            erros += "O campo Unidade de medida deve conter entre 1 e 2 caracteres;";

        else if (string.IsNullOrWhiteSpace(UnidadeDeMedida))
            erros += "O campo Unidade de medida é obrigatorio;";

        else if (!UnidadeDeMedida.All(char.IsLetter))
            erros += "O campo Unidade Não pode conter numeros;";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }
}
