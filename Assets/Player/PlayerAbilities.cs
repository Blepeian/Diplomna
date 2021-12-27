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
    }

    void Update()
    {
        GetInput();
    }

    public void setAbility(int slot, Ability newAbility)
    {
        switch(slot)
        {
            case 1:
                Ability1 = newAbility;
                break;
            case 2:
                Ability2 = newAbility;
                break;
            case 3:
                Ability3 = newAbility;
                break;
        }

        if(abilityNumber < 3)
        {
            abilityNumber++;
        }
    }

    private void GetInput()
    {
        if(Input.GetButtonDown("Ability1"))
        {
            Ability1.Cast();
        }

        if(Input.GetButtonDown("Ability2"))
        {
            Ability2.Cast();
        }

        if(Input.GetButtonDown("Ability3"))
        {
            Ability3.Cast();
        }
    }
}
