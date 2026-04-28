using System;
using System.Collections; //biblioteca que contem classes de coleções que utilizam herança

namespace ListaDeCompra.ConsoleApp.Compartilhado;

public abstract class RepositorioBase
{
    //protected EntidadeBase?[] registros = new EntidadeBase[100];
    protected ArrayList registros = new ArrayList();


    public void Cadastrar(EntidadeBase entidade)
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

    public bool Editar(string idSelecionado, EntidadeBase entidade)
    {
        EntidadeBase? entidadeSelecionada = SelecionarPorId(idSelecionado);

        if (entidadeSelecionada == null)
            return false;

        entidadeSelecionada.AtualizarDados(entidade);

        return true;
    }

    public bool Excluir(string idSelecionado)
    {
        EntidadeBase? registroSelecionado = SelecionarPorId(idSelecionado);

        if (registroSelecionado == null)
            return false;
        registros.Remove(registroSelecionado);

        // for (int i = 0; i < registros.Length; i++)
        // {
        //     EntidadeBase? c = registros[i];

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

    public EntidadeBase? SelecionarPorId(string idSelecionado)
    {
        //versao 1 foeach
        foreach (EntidadeBase registro in registros)
        {
            if (registro.Id == idSelecionado)
                return registro;
        }

        return null;

        //versao 2 com for
        // for (int i = 0; i < registros.Count; i++)
        // {
        //     EntidadeBase? c = (EntidadeBase?)registros[i];

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

    public ArrayList SelecionarTodos()
    {
        return registros;
    }
}
