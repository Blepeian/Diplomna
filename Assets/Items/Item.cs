using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string itemName;
    public string description;
    public Sprite icon;

    public virtual void Equip()
    {
        
    }

    public virtual void Unequip()
    {
        
    }
}
