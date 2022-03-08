using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float currHealth;
    public HealthBar healthBar = null;

    public bool isInvinsible;
    public float totalIFrameTime;
    private float currIFrameTime;

    public int level;
    public int xp;
    private int xpToLevelUp = 100;
    public XpBar xpBar;

    private void Awake()
    {
        MaxHealth();
        currIFrameTime = 0;
        isInvinsible = false;
        healthBar = (HealthBar)GameObject.Find("HealthBar").GetComponent<HealthBar>();
    }

    void Update()
    {
        currIFrameTime -= Time.deltaTime;
        if(currIFrameTime >= 0)
        {       
            isInvinsible = true;
        }
        else
        {
            isInvinsible = false;
        }

        if(xp >= xpToLevelUp)
        {
            LevelUp();
        }
    }

    private void MaxHealth()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        if(!isInvinsible)
        {
            currIFrameTime = totalIFrameTime;
            currHealth -= damage;
            healthBar.SetHealth(currHealth);
        }
        
        if (currHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddXp(int xpToAdd)
    {
        xp += xpToAdd;
        xpBar.AddXpToBar(xp);
    }

    private void LevelUp()
    {
        level++;
        xpBar.LevelUp(level);
        xp -= xpToLevelUp;
        xpBar.AddXpToBar(xp);
        maxHealth = 1.2f*maxHealth;
        MaxHealth();
    }
}
