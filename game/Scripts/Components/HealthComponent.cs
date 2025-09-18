using Godot;
using System;


public partial class HealthComponent : Node
{

    [Signal] public delegate void DeathEventHandler();
    private int maxHealth;
    private int currentHealth;

}
