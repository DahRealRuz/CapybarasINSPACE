using Godot;
using System;

public interface IPlayerState
{
    void EnterState();
    void ExitState();
    void PhysicsUpdate(float delta);
}