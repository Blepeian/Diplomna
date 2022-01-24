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
        string newAbilityName;
        System.Type newAbility;

        switch(abID){
            case 1:
                newAbilityName = "BasicAttack";
                newAbility = System.Type.GetType(newAbilityName);
                gameObject.AddComponent(newAbility);
                ability = (Ability)gameObject.GetComponent(newAbility);
                itemName = BasicAttack.abilityName;
                description = BasicAttack.description;
                gameObject.GetComponent<SpriteRenderer>().sprite = BasicAttack.icon;
                gameObject.GetComponent<SpriteRenderer>().size = gameObject.GetComponent<BoxCollider2D>().size;
                break;
            case 2:
                newAbilityName = "LaserAttack";
                newAbility = System.Type.GetType(newAbilityName);
                gameObject.AddComponent(newAbility);
                ability = (Ability)gameObject.GetComponent(newAbility);
                itemName = LaserAttack.abilityName;
                description = LaserAttack.description;
                gameObject.GetComponent<SpriteRenderer>().sprite = LaserAttack.icon;
                gameObject.GetComponent<SpriteRenderer>().size = gameObject.GetComponent<BoxCollider2D>().size;
                break;
            case 3:
                newAbilityName = "GroundSlam";
                newAbility = System.Type.GetType(newAbilityName);
                gameObject.AddComponent(newAbility);
                ability = (Ability)gameObject.GetComponent(newAbility);
                itemName = GroundSlam.abilityName;
                description = GroundSlam.description;
                gameObject.GetComponent<SpriteRenderer>().sprite = GroundSlam.icon;
                gameObject.GetComponent<SpriteRenderer>().size = gameObject.GetComponent<BoxCollider2D>().size;
                break;
            case 4:
                break;
        }
    }
}
