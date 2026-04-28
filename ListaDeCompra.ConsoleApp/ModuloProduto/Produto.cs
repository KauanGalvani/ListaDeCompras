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
        throw new NotImplementedException();
    }

    public override string[] Validar()
    {
        throw new NotImplementedException();
    }
}
