using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float currHealth;
    public HealthBar healthBar = null;

    public bool isInvincible;
    public float totalIFrameTime;
    private float currIFrameTime;
    
    private SpriteRenderer rend;
    public int level;
    public int xp;
    private int xpToLevelUp = 100;
    public XpBar xpBar = null;

    private void Start()
    {
        level = 1;
        currIFrameTime = 0;
        isInvincible = false;
        rend = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(healthBar == null)
        {
            healthBar = (HealthBar)GameObject.FindWithTag("HealthBar").GetComponent<HealthBar>();
            MaxHealth();
        }

        if(xpBar == null)
        {
            xpBar = (XpBar)GameObject.FindWithTag("XpBar").GetComponent<XpBar>();
        }

        currIFrameTime -= Time.deltaTime;
        if(currIFrameTime >= 0)
        {       
            isInvincible = true;
        }
        else
        {
            rend.color = new Color(255f, 255f, 255f );
            isInvincible = false;
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
        if(!isInvincible)
        {
            rend.color = new Color(255f, 0f, 126f );
            currIFrameTime = totalIFrameTime;
            currHealth -= damage;
            healthBar.SetHealth(currHealth);
        }
        
        if (currHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("level1");
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
