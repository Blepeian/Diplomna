using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Text healthValueText;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        healthValueText.text = health + "/" + health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;

        string[] temp = healthValueText.text.Split('/');
        healthValueText.text = health + "/" + temp[1];

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    
}
