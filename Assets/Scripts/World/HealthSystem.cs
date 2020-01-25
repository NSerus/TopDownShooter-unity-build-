

public class HealthSystem 
{
    private int health;
    private int maxHealth;

    public HealthSystem(int maxHealth)
    {
        this.maxHealth = maxHealth;
        health = maxHealth;
        
    }

    public float GetHealthPercent()
    {
        return (float)health / maxHealth;
    }
    public int GetHealth()
    {
        return health;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        if (health < 0) ;
    }

    public void Heal (int healAmount)
    {
        health += healAmount;
        if (health > maxHealth) health = maxHealth;
    }

}
