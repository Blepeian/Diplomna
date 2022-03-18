using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float currHealth;
    public HealthBar healthBar = null;
    public LevelDisplay lvlDisplay = null;

    public bool isInvincible;
    public float totalIFrameTime;
    private float currIFrameTime;

    public Item equippedItem = null;
    public float coinBuff = 1;
    public ItemUI itemUI;
    
    private SpriteRenderer rend;
    public int level;
    public int currency;
    private int currencyToLevelUp = 100;

    private void Start()
    {
        level = 1;
        currIFrameTime = 0;
        isInvincible = false;
        rend = gameObject.GetComponent<SpriteRenderer>();
        itemUI = GameObject.FindWithTag("ItemUI").GetComponent<ItemUI>();
    }

    void Update()
    {
        if(healthBar == null)
        {
            healthBar = (HealthBar)GameObject.FindWithTag("HealthBar").GetComponent<HealthBar>();
            MaxHealth();
        }

        if(lvlDisplay == null)
        {
            lvlDisplay = (LevelDisplay)GameObject.FindWithTag("LevelDisplay").GetComponent<LevelDisplay>();
            lvlDisplay.levelDisplay.text = "lvl." + level;
        }

        currIFrameTime -= Time.deltaTime;
        if(currIFrameTime >= 0)
        {       
            isInvincible = true;
        }
        else
        {
            rend.color = new Color(255f, 255f, 255f);
            isInvincible = false;
        }
    }

    private void MaxHealth()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void UpdateHealthBar()
    {
        healthBar.SetHealth(currHealth);
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

    public void AddCurrency(int currencyToAdd)
    {
        currency += (int)(coinBuff * currencyToAdd);
    }

    public void LevelUp()
    {
        while(currency >= currencyToLevelUp)
        {
            level++;
            lvlDisplay.LevelUp(level);
            maxHealth = 1.2f*maxHealth;
            currHealth += maxHealth/2;
            UpdateHealthBar();
            currency -= currencyToLevelUp;
        }
    }

    public void EquipItem(Item newItem)
    {
        if(equippedItem != null)
        {
            equippedItem.Unequip();
            Destroy(equippedItem); 
        }

        newItem.Equip();
        itemUI.icon.sprite = newItem.icon;
    }
}
