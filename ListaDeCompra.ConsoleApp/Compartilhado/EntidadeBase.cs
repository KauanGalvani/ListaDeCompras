using System;
using System.Security.Cryptography;


namespace ListaDeCompra.ConsoleApp.Compartilhado;

public abstract class EntidadeBase : Object // Toda classe no C# herda da object
{
    public string Id { get; set; } = string.Empty;
    public EntidadeBase()
    {
        Id = Convert
                .ToHexString(RandomNumberGenerator.GetBytes(20))
                .ToLower()
                .Substring(0, 7);
    }

    public abstract string[] Validar();
    public abstract void AtualizarDados(EntidadeBase entidadeAtualizada);
}
