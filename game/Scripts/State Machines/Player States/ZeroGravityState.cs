using Godot;
using System;

public partial class ZGravityMovement : Node, IState
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

    public void Update(float delta)
    {
        GD.Print("Updating zero gravity state");
    }
}