using Godot;
using System;

public partial class ZGravityMovement : Node, IPlayerMovement
{
    public void HandleMovement(float delta)
    {
        GD.Print("Player zero-g movement initialized");
    }
}