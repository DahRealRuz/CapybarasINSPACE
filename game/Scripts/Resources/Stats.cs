using Godot;
using System;

[GlobalClass]
public partial class Stats : Resource
{
    // This is where the stats for both player and enemies will be defined
    [Export] public int Health { get; set; }
    [Export] public int Speed { get; set; }
    [Export] public int Defense { get; set; }
    [Export] public string Name { get; set; }
}
