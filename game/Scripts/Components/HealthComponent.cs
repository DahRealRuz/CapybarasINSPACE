using Godot;
using System;


public partial class HealthComponent : Node
{

    [Signal] public delegate void DeathEventHandler(); // Death signal 
    [Signal] public delegate void DamagedEventHandler(int currentHealth, int maxHealth); // Damaged signal
    private int maxHealth;
    private int currentHealth;

    /*
    Health Initialize function is here because I'm making the stats as a custom resource and it'll all be set in the main code for both
    player and enemy, so I just left it here for easy access woop woop.
    */
    public void HealthInitialize(int health)
    {
        maxHealth = health;
        currentHealth = maxHealth;
    }

    /*
    Damage function, this is for both players and enemies. Signals are in place because I want both actors to do something
    when damaged and when they *DIE* RAAAA
    */
    public void Damage(int damage)
    {
        currentHealth -= damage;
        EmitSignal(nameof(Damaged)); // Emit damaged signal

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            EmitSignal(nameof(Death), currentHealth, maxHealth); // Emit death signal
        }
    }

    /* 
    Heal function, this is only for the player. 
    MAYBE i'll do something for the enemies but as of rn and where I am I dont have any plans for the enemies to heal.
    */
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

}
