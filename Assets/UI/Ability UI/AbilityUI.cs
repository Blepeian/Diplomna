using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    public Image icon;
    public Text cooldownText;
    public Image overlay;
    public float cooldown;
    public bool onCooldown;

    private float remainingCooldown;

    private void Start()
    {
        overlay.fillAmount = 0f;
        cooldownText.gameObject.SetActive(false);
        remainingCooldown = 0f;
        onCooldown = false;
    }

    private void Update()
    {
        if(onCooldown)
        {
            if(remainingCooldown > 0f)
            {
                remainingCooldown -= Time.deltaTime;
                cooldownText.text = "" + System.Math.Round(remainingCooldown, 2); //unity cannot convert an int directly into a string, so i added an empty one to circumvent that issue
                overlay.fillAmount = remainingCooldown / cooldown;
            }

            if(remainingCooldown <= 0f)
            {
                remainingCooldown = cooldown;
                cooldownText.gameObject.SetActive(false);
                overlay.fillAmount = 0f;
                onCooldown = false;
            }
        }
    }

    public void StartCooldown()
    {
        cooldownText.gameObject.SetActive(true); 
        remainingCooldown = cooldown;
        onCooldown = true;
    }
}
