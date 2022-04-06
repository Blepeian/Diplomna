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
    public ItemUI itemUI = null;
    public int level;
    public int currency;
    
    private SpriteRenderer rend;
    private int currencyToLevelUp = 100;
    private float lvlUpHealthBuff = 1.2f;
    private float lvlUpCostIncrease = 0.2f;

    private void Start()
    {
        level = 1;
        currIFrameTime = 0;
        isInvincible = false;
        rend = gameObject.GetComponent<SpriteRenderer>();
        currHealth = maxHealth;
    }

    void Update()
    {
        if(healthBar == null)
        {
            healthBar = (HealthBar)GameObject.FindWithTag("HealthBar").GetComponent<HealthBar>();
            UpdateHealthBar();
        }

        if(lvlDisplay == null)
        {
            lvlDisplay = (LevelDisplay)GameObject.FindWithTag("LevelDisplay").GetComponent<LevelDisplay>();
            lvlDisplay.levelDisplay.text = "lvl." + level;
        }

        if(itemUI == null)
        {
            itemUI = GameObject.FindWithTag("ItemUI").GetComponent<ItemUI>();
            if(equippedItem != null)
            {
                itemUI.icon.sprite = equippedItem.icon;
            }
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
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        healthBar.SetHealth(currHealth, maxHealth);
    }

    public void TakeDamage(float damage)
    {
        if(!isInvincible)
        {
            rend.color = new Color(255f, 0f, 126f );
            currIFrameTime = totalIFrameTime;
            currHealth -= damage;
            healthBar.SetHealth(currHealth, maxHealth);
        }
        
        if (currHealth <= 0)
        {
            Destroy(gameObject);
            Destroy(GameObject.Find("LevelManager"));
            SceneManager.LoadScene("level1");
        }
    }

    public void AddCurrency(int currencyToAdd)
    {
        currency += (int)(coinBuff * currencyToAdd);
    }

    public void LevelUp()
    {
        bool atMax = false;

        if(currHealth == maxHealth)
        {
            atMax = true;
        }

        while(currency >= currencyToLevelUp)
        {
            level++;
            lvlDisplay.LevelUp(level);
            maxHealth = lvlUpHealthBuff*maxHealth;
            if((currHealth + maxHealth/10) < maxHealth)
            {
                if(!atMax)
                {
                    currHealth += maxHealth/10;
                }
            }
            else
            {
                atMax = true;
            }
            currency -= currencyToLevelUp;
            currencyToLevelUp += (int)(lvlUpCostIncrease * currencyToLevelUp);
        }

        if(atMax)
        {
            currHealth = maxHealth;
        }

        UpdateHealthBar();
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
