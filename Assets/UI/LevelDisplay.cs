using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    public Text levelDisplay;
    public Text currencyDisplay;

    private void Start()
    {
        levelDisplay.text = "lvl." + GameObject.FindWithTag("Player").GetComponent<PlayerStats>().level;
        currencyDisplay.text = "Coins: " + GameObject.FindWithTag("Player").GetComponent<PlayerStats>().currency;
    }

    private void Update()
    {
        currencyDisplay.text = "Coins: " + GameObject.FindWithTag("Player").GetComponent<PlayerStats>().currency;
    }

    public void LevelUp(int level)
    {
        levelDisplay.text = "lvl." + level;
    }
}
