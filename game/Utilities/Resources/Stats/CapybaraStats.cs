using Godot;
using System;

[GlobalClass]
public partial class CapybaraStats : Resource
{
    [Export]
    public Node Health;
    [Export]
    public float Speed;
    [Export]
    public float JumpForce;
    [Export]
    public Node SpecialAbility;

}
