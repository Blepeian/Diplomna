using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth;
    public int currHealth;
    public HealthBar healthBar;

    public bool isInvinsible;
    public float totalIFrameTime;
    private float currIFrameTime;

    private void Awake()
    {
        MaxHealth();
        healthBar.SetMaxHealth(maxHealth);
        currIFrameTime = 0;
        isInvinsible = false;
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
    }

    private void MaxHealth()
    {
        currHealth = maxHealth;
    }

    public void TakeDamage(int damage)
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
}