using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public int level = 1;
    public string scriptName;
    public Transform castPoint;
    public string abilityName;
    public string description;
    public float cooldown;
    public float remainingCooldown;
    public Sprite icon;
    public bool isCasting;

    [SerializeField] public LayerMask enemyLayer;

    public abstract void Cast();
    
    public abstract void LevelUp(int levelToGetTo);

    public virtual void GetData(AbilityItem item)
    {
        item.itemName = this.abilityName;
        item.description = this.description;
        item.gameObject.GetComponent<SpriteRenderer>().sprite = this.icon;
    }

    public virtual void GetDataForUI(AbilityUI ui)
    {
        ui.cooldown = this.cooldown;
        ui.icon.sprite = this.icon;
    }
}