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

    [SerializeField] public LayerMask enemyLayer;

    public abstract void Cast();
}
