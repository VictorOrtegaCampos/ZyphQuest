using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryBehaviour : MonoBehaviour
{
    Item[] items;

    public Item GetItem(int index)
    {
        if(index < 0 || index >= items.Length)
        {
            return null;
        }
        else
        {
            return items[index];
        }
        
    }
    public Item GetItem(string name)
    {
        for (int i = 0; i < items.Length; i++)
        {
            Item it = items[i];
            if(it != null)
            {
                if (it.GetName() == name)
                {
                    return it;
                }
            }
            
        }
        return null;
    }
    public bool AddItem(Item newItem)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = newItem;
                return true;
            }
        }
        return false;
    }

    public void RemoveItem(int index)
    {
        if (index >= 0 || index < items.Length)
        {
            items[index] = null;
        }
            
    }
    public void RemoveItem(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            Item it = items[i];
            if (it != null)
            {
                if (it.GetName() == item.GetName())
                {
                    items[i] = null;
                    return;
                }
            }
        }
    }

    public string PrintAllItems()
    {
        string returnedString = "";
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                returnedString += "Hueco" + " ";
            }
            else
            {
               returnedString += items[i].GetName() + " ";
            }
        }
        return returnedString;
    }
    public void UseItem(int index)
    {
        
    }

    public void HasItem(Item item)
    {

    }
}
