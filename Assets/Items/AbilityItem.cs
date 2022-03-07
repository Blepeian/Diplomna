using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityItem : Item
{
    public Ability ability = null;

    void Awake()
    {
        PickAbility();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerAbilities pAbilities = collision.gameObject.GetComponentInChildren(typeof(PlayerAbilities)) as PlayerAbilities;
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Picking Up " + ability.abilityName);
                Debug.Log("Choosing slot 1");
                pAbilities.SetAbility(1, ability);
            }
        }
    }

    private void PickAbility()
    {
        int abID = Random.Range(1, 4);

        switch(abID){
            case 1:
                BasicAttack basicAttack = (BasicAttack)gameObject.AddComponent(System.Type.GetType("BasicAttack"));
                basicAttack.GetData(this);
                ability = (Ability)basicAttack;
                break;
            case 2:
                LaserAttack laserAttack = (LaserAttack)gameObject.AddComponent(System.Type.GetType("LaserAttack"));
                laserAttack.GetData(this);
                ability = (Ability)laserAttack;
                break;
            case 3:
                GroundSlam grSlamAttack = (GroundSlam)gameObject.AddComponent(System.Type.GetType("GroundSlam"));
                grSlamAttack.GetData(this);
                ability = (Ability)grSlamAttack;
                break;
            case 4:
                break;
        }

        gameObject.GetComponent<SpriteRenderer>().size = gameObject.GetComponent<BoxCollider2D>().size;
    }
}
