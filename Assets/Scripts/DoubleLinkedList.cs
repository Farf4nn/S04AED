using System;
using UnityEngine;

public class DoubleLinkedList<T>
{
    public Node<T> head = null;
    public Node<T> tail = null;
    public Node<T> pivot = null;
    public int Count;

    // O(1)
    public virtual void Add(T value)
    {
        Node<T> newNode = new(value);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
            pivot = newNode;
        }
        else
        {
            tail.SetNext(newNode);
            newNode.SetPrev(tail);
            tail = newNode;

            pivot = newNode;
        }

        Count++;
    }
    public void AddTurn(T value)
    {
        if (pivot != tail)
        {
            RemoveAfterPivot();
        }

        Add(value);
    }
    public void RemoveAfterPivot()
    {
        if (pivot == null) return;

        Node<T> current = pivot.Next;

        while (current != null)
        {
            Node<T> temp = current;
            current = current.Next;

            temp.SetNext(null);
            temp.SetPrev(null);

            Count--;
        }

        pivot.SetNext(null);
        tail = pivot;
    }
    public void MoveNext()
    {
        if (pivot != null && pivot.Next != null)
        {
            pivot = pivot.Next;
        }
    }
    public void MovePrev()
    {
        if (pivot != null && pivot.Prev != null)
        {
            pivot = pivot.Prev;
        }
    }
    public void TraverseInOrder(Action<Node<T>> action)
    {
        Node<T> evaluator = head;
        while (evaluator != null)
        {
            action(evaluator);
            evaluator = evaluator.Next;
        }
    }
}