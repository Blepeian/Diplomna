using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityItem : Item
{
    public Ability ability = null;
    public AbilitySelectUI ui = null;
    public GameObject interact;

    private bool playerInFront;

    private void Awake()
    {
        PickAbility();
        interact.SetActive(false);
        playerInFront = false;

        LevelManager manager = (LevelManager)FindObjectOfType(typeof(LevelManager));
        ui = manager.abUI;
    }

    private void Update()
    {
        if(playerInFront)
        {
            if(Input.GetButtonDown("Interact"))
            {
                ui.GetAbility(this);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            interact.SetActive(true);
            playerInFront = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interact.SetActive(false);
        playerInFront = false;
    }

    private void PickAbility()
    {
        int abID = Random.Range(1, 5);

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
                EldritchBlast blast = (EldritchBlast)gameObject.AddComponent(System.Type.GetType("EldritchBlast"));
                blast.GetData(this);
                ability = (Ability)blast;
                break;
        }

        gameObject.GetComponent<SpriteRenderer>().size = gameObject.GetComponent<BoxCollider2D>().size;
    }
}
