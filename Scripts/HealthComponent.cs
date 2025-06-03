using Godot;
using System;

public partial class HealthComponent : Node2D
{
    // Exported proprerties to set in the editor
    [Export] public float MaxHealth { get; set; }

    // Signals for damage and health changes
    [Signal] public delegate void DamageTakenEventHandler(float damage);

    // Private Properties
    private float _currentHealth;
    private bool _isAlive = true;

    public override void _Ready()
    {
        // Initialize current health to max health
        _currentHealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        
    }
    

}
