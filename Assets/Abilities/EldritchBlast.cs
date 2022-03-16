using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EldritchBlast : Ability
{
    public bool lookingRight;
    public float damage;
    
    private GameObject blastPrefab;
    

    void Awake()
    {
        cooldown = 2f;
        remainingCooldown = 0;
        abilityName = "Eldritch Blast";
        description = "Channel the powers given to you by your slumbering ancient masters and let loose a bolt of eldritch energy at your enemy.";
        damage = 20f;
        scriptName = "EldritchBlast";
        isCasting = false;
        icon = Resources.Load<Sprite>("eldritch_blast_icon");
        blastPrefab = Resources.Load<GameObject>("Prefabs/EldritchBlastProjectile");
    }

    void Update()
    {
        if(remainingCooldown > 0)
        {
            remainingCooldown -= Time.deltaTime;
        }
    }

    public override void Cast()
    {
        if(remainingCooldown <= 0)
        {
            GameObject  blastObj = Instantiate(blastPrefab, castPoint.position, Quaternion.identity);

            lookingRight = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().lookingRight;
            if(lookingRight)
            {
                blastObj.GetComponent<Projectile>().spriteDirection = SpriteDirection.Right;
            }
            else
            {
                blastObj.GetComponent<Projectile>().spriteDirection = SpriteDirection.Left;
            }

            blastObj.GetComponent<Projectile>().damage = damage;
            blastObj.GetComponent<Projectile>().CheckDirection();
            blastObj.GetComponent<Projectile>().MoveProjectile();

            remainingCooldown = cooldown;
        }
    }

    public override void LevelUp(int levelToGetTo)
    {
        while(level < levelToGetTo)
        {
            damage = 1.15f*damage;
            level++;
        }
    }
}
