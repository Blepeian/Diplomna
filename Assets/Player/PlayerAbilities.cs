using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public int abilityNumber;
    public Ability Ability1 = null;
    public Ability Ability2 = null;
    public Ability Ability3 = null;

    private void Awake()
    {
        abilityNumber = 1;
        string newAbilityName = "BasicAttack";
        System.Type newAbility = System.Type.GetType(newAbilityName);
        Ability1 = (Ability)gameObject.AddComponent(newAbility);
        Ability1.castPoint = gameObject.transform;
    }

    void Update()
    {
        GetInput();
    }

    public void SetAbility(int slot, Ability ability)
    {
        string newAbilityName = ability.scriptName;
        System.Type newAbility = System.Type.GetType(newAbilityName);

        if(abilityNumber < 3)
        {
            switch(abilityNumber)
            {
                case 1:
                    Ability2 = (Ability)gameObject.AddComponent(newAbility);
                    Ability2.castPoint = gameObject.transform;
                    break;
                case 2:
                    Ability3 = (Ability)gameObject.AddComponent(newAbility);
                    Ability3.castPoint = gameObject.transform;
                    break;
            }

            abilityNumber++;
        }
        else
        {
            switch(slot)
            {
                case 1:
                    Destroy(Ability1);
                    Ability1 = (Ability)gameObject.AddComponent(newAbility);
                    Ability1.castPoint = gameObject.transform;
                    break;
                case 2:
                    Destroy(Ability2);
                    Ability2 = (Ability)gameObject.AddComponent(newAbility);
                    Ability2.castPoint = gameObject.transform;
                    break;
                case 3:
                    Destroy(Ability3);
                    Ability3 = (Ability)gameObject.AddComponent(newAbility);
                    Ability3.castPoint = gameObject.transform;
                    break;
            }
        }
    }

    private void GetInput()
    {
        if(Input.GetButtonDown("Ability1") && Ability1 != null)
        {
            if(!CheckCasting())
            {
                Ability1.Cast();
            }
        }

        if(Input.GetButtonDown("Ability2") && Ability2 != null)
        {
            if(!CheckCasting())
            {
                Ability2.Cast();
            }
        }

        if(Input.GetButtonDown("Ability3") && Ability3 != null)
        {
            if(!CheckCasting())
            {
                Ability3.Cast();
            }
        }
    }

    private bool CheckCasting()
    {
        if(Ability1.isCasting)
        {
            return true;
        }
        else if(Ability2 != null)
        {
            if(Ability2.isCasting)
            {
                return true;
            }
            goto Next;
        }
        Next:
            if(Ability3 != null)
            {
                if(Ability3.isCasting)
                {
                    return true;
                }
                goto Final;
            }
        Final: return false;
    }
}
