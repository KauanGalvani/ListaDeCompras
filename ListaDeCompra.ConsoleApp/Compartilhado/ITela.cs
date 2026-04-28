using System;

namespace ListaDeCompra.ConsoleApp.Compartilhado;

public interface ITela
{
    string? ObterOpcaoMenu(); // toda classe que implementa essa interface precisa implementar esse método
}
