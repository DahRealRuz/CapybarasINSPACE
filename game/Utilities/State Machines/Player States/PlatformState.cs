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

    public void HandleInput(float delta)
    {
        GD.Print("Handling input in platform state");
    }
}