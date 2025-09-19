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
    public void PhysicsUpdate(float delta)
    {
        GD.Print("Physics updating zero gravity state");
    }
}