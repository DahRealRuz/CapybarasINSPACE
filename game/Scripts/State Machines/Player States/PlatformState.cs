using Godot;
using System;
using System.ComponentModel;

public class PlatformState : IState
{
    public void EnterState()
    {
        GD.Print("Entered platform state");
    }

    public void ExitState()
    {
        GD.Print("Exited platform state");
    }
    public void PhysicsUpdate(float delta)
    {
    }

    public void Update(float delta)
    {
    }
}