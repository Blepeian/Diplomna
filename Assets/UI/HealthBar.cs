using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Text healthValueText;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetHealth(float health, float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = health;

        healthValueText.text = (int)health + "/" + (int)maxHealth;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetHealthSliderOnly(float health, float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = health;
    }
}
