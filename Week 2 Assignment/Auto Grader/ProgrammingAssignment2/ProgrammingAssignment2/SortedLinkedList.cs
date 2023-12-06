using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A sorted linked list
/// </summary>
public class SortedLinkedList<T> : LinkedList<T> where T : IComparable
{
    #region Constructor

    public SortedLinkedList() : base() {
    }

    #endregion

    #region Methods

    /// <summary>
    /// Adds the given item to the list
    /// </summary>
    /// <param name="item">item to add to list</param>
    public void Add(T item) {
        if (Count == 0)
        {
            AddFirst(item);
            return;
        }

        if (First.Value.CompareTo(item) >= 0)
        {
            AddFirst(item);
            return;
        }

        LinkedListNode<T> previousItem = null;
        LinkedListNode<T> currentItem = First;

        while (currentItem != null && currentItem.Value.CompareTo(item) < 0)
        {
            previousItem = currentItem;
            currentItem = currentItem.Next;
        }

        AddAfter(previousItem, item);
    }

    /// <summary>
    /// Repositions the given item in the list by moving it
    /// forward in the list until it's in the correct
    /// position. This is necessary to keep the list sorted
    /// when the value of the item changes
    /// </summary>
    public void Reposition(T item) {
        LinkedListNode<T> currentItem = Find(item);

        if (currentItem == null)
            return;

        while (currentItem.Previous != null && currentItem.Value.CompareTo(currentItem.Previous.Value) < 0)
        {
            currentItem.Value = currentItem.Previous.Value;
            currentItem.Previous.Value = item;
            currentItem = currentItem.Previous;
        }
    }

    #endregion
}