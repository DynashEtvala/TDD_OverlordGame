using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    [SerializeField]private int maxHealth = 100;
    [SerializeField]private int currentHealth;

    private void Reset()
    {
        SetCurrentHealth(maxHealth);
        HealthManager.AddToTable(this, transform);
    }

    private void OnDestroy()
    {
        HealthManager.RemoveFromTable(transform);
    }

    /// <summary>
    /// Returns the maximum value for this Health object.
    /// </summary>
    /// <returns>The maximum value for this Health object.</returns>
    public int GetMaxHealth()
    {
        return maxHealth;
    }

    /// <summary>
    /// Sets the maximum value for this Health object.
    /// </summary>
    /// <param name="HealthValue">The maximum value to be set for this Health object.</param>
    public void SetMaxHealth(int HealthValue)
    {
        maxHealth = Mathf.Max(HealthValue, 1);
    }

    /// <summary>
    /// Returns the current value for this Health object.
    /// </summary>
    /// <returns>The current value for this Health object.</returns>
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    /// <summary>
    /// Sets the current value for this Health object.
    /// </summary>
    /// <param name="HealthValue">The current value to be set for this Health object.</param>
    public void SetCurrentHealth(int HealthValue)
    {
        currentHealth = Mathf.Clamp(HealthValue, 0, maxHealth);
    }

    /// <summary>
    /// Returns the current value for this Health object as a percentage.
    /// </summary>
    /// <returns>The current value for this Health object as a percentage.</returns>
    public float GetHealthPercent()
    {
        return (float)currentHealth / maxHealth;
    }
}
