using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public int level;
    public int abilityNumber;
    public Ability Ability1 = null;
    public Ability Ability2 = null;
    public Ability Ability3 = null;
    public PlayerStats playerStats;

    private AbilityUI ui1 = null;
    private AbilityUI ui2 = null;
    private AbilityUI ui3 = null;

    private void Awake()
    {
        level = GameObject.FindWithTag("Player").GetComponent<PlayerStats>().level;
        abilityNumber = 1;
        System.Type newAbility = System.Type.GetType("BasicAttack");
        Ability1 = (Ability)gameObject.AddComponent(newAbility);
        Ability1.castPoint = gameObject.transform;
        Ability1.level = level;
        playerStats = (PlayerStats)GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
    }

    void Update()
    {
        if(ui1 == null || ui2 == null || ui3 == null)
        {
            SetUI();
        }
        GetInput();
        if(playerStats.level > level)
        {
            LevelUp();
        }
    }

    public void SetAbility(int slot, Ability ability)
    {
        string newAbilityName = ability.scriptName;
        System.Type newAbility = System.Type.GetType(newAbilityName);

        switch(slot)
        {
            case 1:
                Destroy(Ability1);
                Ability1 = (Ability)gameObject.AddComponent(newAbility);
                Ability1.castPoint = gameObject.transform;
                Ability1.LevelUp(level);
                Ability1.GetDataForUI(ui1);
                break;
            case 2:
                Destroy(Ability2);
                Ability2 = (Ability)gameObject.AddComponent(newAbility);
                Ability2.castPoint = gameObject.transform;
                Ability2.LevelUp(level);
                Ability2.GetDataForUI(ui2);
                break;
            case 3:
                Destroy(Ability3);
                Ability3 = (Ability)gameObject.AddComponent(newAbility);
                Ability3.castPoint = gameObject.transform;
                Ability3.LevelUp(level);
                Ability3.GetDataForUI(ui3);
                break;
        }
    }

    private void GetInput()
    {
        if(Input.GetButtonDown("Ability1") && Ability1 != null)
        {
            Cast(Ability1, ui1);
        }

        if(Input.GetButtonDown("Ability2") && Ability2 != null)
        {
            Cast(Ability2, ui2);
        }

        if(Input.GetButtonDown("Ability3") && Ability3 != null)
        {
            Cast(Ability3, ui3);
        }
    }

    private void Cast(Ability abToCast, AbilityUI abUI)
    {
        if(!CheckCasting())
        {
            abToCast.Cast();
            if(!abUI.onCooldown)
            {
                abUI.StartCooldown();
            }
        }
    }

    private bool CheckCasting()
    {
        if(Ability1.isCasting)
        {
            return true;
        }
        if(Ability2 != null)
        {
            if(Ability2.isCasting)
            {
                return true;
            }
        }
        if(Ability3 != null)
        {
            if(Ability3.isCasting)
            {
                return true;
            }
        }

        return false;
    }

    private void LevelUp()
    {
        level++;
        Ability1.LevelUp(level);
        if(Ability2 != null)
        {
            Ability2.LevelUp(level);
        }
        if(Ability3 != null)
        {
            Ability3.LevelUp(level);
        }
    }

    private void SetUI()
    {
        ui1 = (AbilityUI)GameObject.FindWithTag("AbilityUI1").GetComponent<AbilityUI>();
        ui2 = (AbilityUI)GameObject.FindWithTag("AbilityUI2").GetComponent<AbilityUI>();
        ui3 = (AbilityUI)GameObject.FindWithTag("AbilityUI3").GetComponent<AbilityUI>();

        Ability1.GetDataForUI(ui1);

        if(Ability2 != null)
        {
            Ability2.GetDataForUI(ui2);
        }

        if(Ability3 != null)
        {
            Ability3.GetDataForUI(ui3);
        }
    }
}
