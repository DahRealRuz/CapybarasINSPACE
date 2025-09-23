using Godot;
using System;

public partial class Stats : Resource
{
    // This is where the stats for both player and enemies will be defined
    [Export] public int Health;
    [Export] public int Speed;
    [Export] public int Defense;
}
