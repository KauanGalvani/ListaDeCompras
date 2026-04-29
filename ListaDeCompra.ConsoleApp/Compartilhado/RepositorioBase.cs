using System;
using System.Collections; //biblioteca que contem classes de coleções que utilizam herança
using System.Collections.Generic; //biblioteca que contem classes de coleções que utilizam herança

namespace ListaDeCompra.ConsoleApp.Compartilhado;

public abstract class RepositorioBase<T> where T : EntidadeBase // constraint /restrição
{
    //protected T?[] registros = new T[100];
    protected List<T> registros = new List<T>();


    public void Cadastrar(T entidade)
    {
        registros.Add(entidade); // quem fica responsavel por tudo agr é o Add.

        // for (int i = 0; i < registros.Count; i++) // count atualiza de acordo com os espaços oculados na memoria, nao conta espaços null
        // {
        //     if (registros[i] == null)
        //     {
        //         registros[i] = entidade;
        //         break;
        //     }
        // }
    }

    public bool Editar(string idSelecionado, T entidade)
    {
        T? entidadeSelecionada = SelecionarPorId(idSelecionado);

        if (entidadeSelecionada == null)
            return false;

        entidadeSelecionada.AtualizarDados(entidade);

        return true;
    }

    public bool Excluir(string idSelecionado)
    {
        T? registroSelecionado = SelecionarPorId(idSelecionado);

        if (registroSelecionado == null)
            return false;
        registros.Remove(registroSelecionado);

        // for (int i = 0; i < registros.Length; i++)
        // {
        //     T? c = registros[i];

        //     if (c == null)
        //         continue;

        //     if (c.Id == idSelecionado)
        //     {
        //         registros[i] = null;
        //         return true;
        //     }
        // }

        return true;
    }

    public T? SelecionarPorId(string idSelecionado)
    {
        //versao 1 foeach
        foreach (T registro in registros)
        {
            if (registro.Id == idSelecionado)
                return registro;
        }

        return null;

        //versao 2 com for
        // for (int i = 0; i < registros.Count; i++)
        // {
        //     T? c = (T?)registros[i];

        //     if (c == null)
        //         continue;

        //     if (c.Id == idSelecionado)
        //     {
        //         entidadeSelecionada = c;
        //         break;
        //     }
        // }

        //return entidadeSelecionada;
    }

    public List<T> SelecionarTodos()
    {
        return registros;
    }
}
