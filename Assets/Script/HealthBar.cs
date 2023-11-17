using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Image healthBar;

    public virtual void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        this.healthBar.fillAmount = currentHealth/maxHealth;
    }
}
