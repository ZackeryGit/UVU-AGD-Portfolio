using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Coder: Zackery E.
public class Healthbar : MonoBehaviour
{
    public IntData health; // Swap to whatever data type you need

    public Slider slider; // UI Slider Object
    public UnityEvent onDamage, onHeal, onDepleted;

    public int maxHealth;
    public int currentBarHealth;

    public void Awake()
    {
        Debug.Log("Healthbar Awake");
        currentBarHealth = health.value;
        UpdateSlider();
    }

    public void UpdateHealthBar()
    {
        if (currentBarHealth < 0) { currentBarHealth = 0; }

        RunHealthEvents();
        currentBarHealth = health.value;
        UpdateSlider();
    }

    private void RunHealthEvents()
    {
        if (health.value <= 0) { onDepleted.Invoke(); } // If health is depleted
        else if (currentBarHealth < health.value) { onHeal.Invoke(); } // If health increased
        else if (currentBarHealth > health.value) { onDamage.Invoke(); } // If health is decreased
        else { return; }// No change
    }

    private void UpdateSlider()
    {
        slider.maxValue = maxHealth;
        slider.value = (currentBarHealth <= maxHealth) ? currentBarHealth : maxHealth;
    }
}
