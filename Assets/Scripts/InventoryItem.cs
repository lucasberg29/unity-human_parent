using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public ItemType InventoryType { get; set; }

    public string Name => Enum.GetName(typeof(ItemType), InventoryType);

    public InventoryItem(ItemType itemType)
    {
        InventoryType = itemType;
    }


}

public enum ItemType
{
    Food
}