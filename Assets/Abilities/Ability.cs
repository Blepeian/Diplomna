using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
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
<<<<<<< Updated upstream
=======

    public abstract void LevelUp(int levelToGetTo);

    public virtual void GetData(AbilityItem item)
    {
        // item.gameObject.AddComponent(System.Type.GetType(scriptName));
        item.itemName = this.abilityName;
        item.description = this.description;
        item.gameObject.GetComponent<SpriteRenderer>().sprite = this.icon;
    }
>>>>>>> Stashed changes
}
