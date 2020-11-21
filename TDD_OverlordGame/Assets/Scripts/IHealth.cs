public interface IHealth
{
    int GetCurrentHealth();
    float GetHealthPercent();
    int GetMaxHealth();
    void SetCurrentHealth(int HealthValue);
    void SetMaxHealth(int HealthValue);
}