using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Text levelDisplay;

    private void Start()
    {
        levelDisplay.text = "lvl." + GameObject.Find("Player").GetComponent<PlayerStats>().level;
    }

    public void AddXpToBar(int xpToAdd)
    {
        slider.value += xpToAdd;
    }

    public void LevelUp(int level)
    {
        slider.value = 0;
        levelDisplay.text = "lvl." + level;
    }
}
