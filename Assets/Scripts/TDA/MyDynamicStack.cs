using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDynamicStack<T>
{
    private Node<T> Root;       // Nodo Raiz (Cada nodo tiene un valor y referencia a su siguiente)
    public void DynamicPushStack(T element)
{
    if (Root == null)           // Si no tiene raiz, le crea una raiz con el valor dado
    {
        Node<T> tempHeadNode = new Node<T>();
        tempHeadNode.value = element;
        Root = tempHeadNode;
        return;
    }

    Node<T> auxNode = Root;     //Si ya tiene raiz, crea un nodo auxiliar para buscar el ultimo nodo

    while (auxNode.next != null) // Si el siguiente no es null, es porque el aux aún no esta en el ultimo
    {
        auxNode = auxNode.next; // Mientras sea asi, hace que el siguiente sea el actual (se mueve uno)
    }

    Node<T> newNode = new Node<T>();    // Una vez encontrado el ultimo, le crea un siguiente y le asigna el valor dado
    newNode.value = element;
    auxNode.next = newNode;
    Console.WriteLine($"Agregaste el nodo de valor: {newNode.value}");
}

public T DynamicPopStack()
{
    if (Root != null)       //Si no tiene raiz, el stack esta vacio, por lo que no tiene nada que quitar
    {
        if (Root.next != null)   //Si hay raiz y tiene un siguiente, debe busca el ultimo
        {
            Node<T> auxNode = Root; //Crea un auxiliar para buscar el ultimo

            while (auxNode.next.next != null)   //Pregunta por el siguiente del siguiente, hasta que sea null
            {
                auxNode = auxNode.next;         //Se movera de a uno, hasta que el siguiente sea el ultimo
            }
            Node<T> poppedNode = auxNode.next;
            auxNode.next = null;                // Posicionado en el anteultimo, borra la referencia de su siguiente (que era el ultimo)
            return poppedNode.value;
        }
        Node<T> poppedRootNode = Root;
        Root = null;                            //En caso de SOLO tener raiz, simplementa la borra, dejando el stack vacio
        return poppedRootNode.value;
    }
        return default;
}

public int Count()
{
  int countIndex = 0;           //Crea un contador en 0

  if (Root == null)
  {
    return countIndex;          //Si no tiene raiz, el stack esta vacio, asi que devuelve el contador en 0
  }

  countIndex = 1;               //Si tiene raiz, como minimo devolvera el contador en 1
  Node<T> auxNode = Root;       //Crea el auxiliar para recorrer el stack

   while (auxNode.next != null) //Mientras el siguiente del auxiliar no sea nulo (Es decir, el auxiliar no este sobre el ultimo)
   {
      countIndex++;             //Le suma uno al contador
      auxNode = auxNode.next;   //Y se mueve al siguiente
   }

   return countIndex;           //Devuelve el contador
}

}