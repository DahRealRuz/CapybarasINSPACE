using Godot;
using System;

public partial class PlatformMovement : Node, IPlayerMovement
{
    public void HandleMovement(float delta)
    {
        GD.Print("Player platform movement initialized");
    }
}