using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node<T> 
{
  public T value;
  public Node<T> next = null;

    public Node()
    {
        value = default(T);
    }
    public Node(T value)
    { 
        this.value = value; 
    }

    public Node(T value, Node<T> nextNode)
    {
        this.value = value;
        this.next = nextNode;
    }
}
