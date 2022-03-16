using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : MonoBehaviour
{
    public float maxHealth;
    public float currHealth;
    public int currencyToGive;
    public int level;
    public Ability attack1;
    public Ability attack2;
    public PlayerStats playerStats = null;
    public HealthBar bossHealthBar;

    private SpriteRenderer rend;
    private float hitColorTime;
    private bool started = false;

    private void Awake()
    {
        level = 1;
        currHealth = maxHealth;
        rend = gameObject.GetComponent<SpriteRenderer>();
        bossHealthBar.SetHealthSliderOnly(currHealth);
        bossHealthBar.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(playerStats == null)
        {
            playerStats = (PlayerStats)GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        }
        if(playerStats.level > level)
        {
            LevelUp();
        }

        hitColorTime -= Time.deltaTime;
        if(hitColorTime <= 0)
        {
            rend.color = new Color(255f, 255f, 255f );
        }
    }

    public void TakeDamage(float damage)
    {
        if(started)
        {
            bossHealthBar.SetHealthSliderOnly(currHealth);
        }
        currHealth -= damage;
        rend.color = new Color(255f, 0f, 126f );
        hitColorTime = 0.5f;       
        if (currHealth <= 0)
        {
            Destroy(gameObject);
            playerStats.AddCurrency(currencyToGive);
        }
    }

    private void LevelUp()
    {
        maxHealth = 1.1f*maxHealth;
        level = playerStats.level;
        this.attack1.LevelUp(level);
        this.attack2.LevelUp(level);
    }

    public void StartBattle()
    {
        bossHealthBar.gameObject.SetActive(true);
        started = true;
    }
}
