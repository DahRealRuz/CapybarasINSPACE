using Godot;
using System;

public class PlatformState : IPlayerState
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
        GD.Print("Physics updating platform state");
    }
}