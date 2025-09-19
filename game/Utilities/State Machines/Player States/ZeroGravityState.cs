using Godot;
using System;

public partial class ZGravityMovement : Node, IPlayerState
{
    public void EnterState()
    {
        GD.Print("Entered zero gravity state");
    }

    public void ExitState()
    {
        GD.Print("Exited zero gravity state");
    }

    public void HandleInput(float delta)
    {
        GD.Print("Handling input in zero gravity state");
        HandleMovement(delta);
    }

    // Additional method specific to zero gravity movement
    public void HandleMovement(float delta)
    {
        GD.Print("Player zero-g movement initialized");
    }
}