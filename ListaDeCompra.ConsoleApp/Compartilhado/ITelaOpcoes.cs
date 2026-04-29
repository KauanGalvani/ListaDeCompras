using System;

namespace ListaDeCompra.ConsoleApp.Compartilhado;

public interface ITelaOpcoes
{
    string? ObterOpcaoMenu(); // toda classe que implementa essa interface precisa implementar esse método
}
