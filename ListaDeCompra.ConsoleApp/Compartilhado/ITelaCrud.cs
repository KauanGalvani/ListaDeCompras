using System;

namespace ListaDeCompra.ConsoleApp.Compartilhado;

public interface ITelaCrud
{
    void Cadastrar();
    void Editar();
    void Excluir();
    void VisualizarTodos(bool deveExibirCabecalho);
}
