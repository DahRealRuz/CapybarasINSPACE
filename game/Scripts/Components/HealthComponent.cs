using Godot;
using System;


public partial class HealthComponent : Node
{

    [Signal] public delegate void DeathEventHandler(); // Death signal 
    [Signal] public delegate void DamagedEventHandler(int currentHealth, int maxHealth); // Damaged signal
    private int maxHealth;
    private int currentHealth;

    public void Damage(int damage)
    {
        currentHealth -= damage;
        EmitSignal(nameof(Damaged)); // Emit damaged signal

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            EmitSignal(nameof(Death)); // Emit death signal
        }
    }

    private void Heal(int amount) // Heal function, this is only for the player.
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

}
