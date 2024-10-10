using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyDynamicQueue<T>
{
    // primer elemento de la cola
    private Node<T> first;
    // ultimo elemento agregado
    private Node<T> last;

    public void InitializeQueue()
    {
        first = null;
        last = null;
    }

    public void Enqueue(T x)
    {
        // creo el nuevo nodo a agregar
        Node<T> nuevo = new Node<T>();
        nuevo.value = x;
        nuevo.next = null;

        //Si la cola no esta vacıa
        if (last != null)
        {
            // al nodo "ultimo" le asigno como siguiente el nodo "nuevo"
            last.next = nuevo;
        }
        // el "ultimo" debe referenciar al "nuevo" que entro
        last = nuevo;

        // Si la cola estaba vacıa
        if (first == null)
        {
            // si hay un solo nodo, "primero" y "ultimo" hacen referencia al mismo nodo
            first = last;
        }
    }

    public T Dequeue()
    {
        // quitar el primer valor es hacer que el primero sea el siguiente
        T val = first.value;
        first = first.next;
        // Si la cola queda vacıa (si primero.siguiente era null)
        if (first == null)
        {
            last = null;
        }
        return val;
    }

    public void Clear()
    {
        first = null;
        last = null;
    }
    public int Count()
    {
        int n = 0;
        Node<T> tracker = first;
        if (tracker == null)
        {
            return n;
        }
        for (int i = 0; tracker != null; i++)//pasa por los nodos hasta llegar a q el tracker sea null
        {
            tracker = tracker.next;
            n++;
            i++;
        }
        return n;
    }

    public bool CheckIfQueueIsEmpty()
    {
        return (last == null);
    }

    public T First()
    {
        //devuelvo los datos del primer valor
        return first.value;
    }
    public T Last()
    {
        //devuelvo los datos del último valor
        return last.value;
    }
}
