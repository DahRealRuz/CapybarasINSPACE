using Godot;
using System;

public interface IState
{
    [Signal] public delegate void StateTransitionEventHandler(); // Signal to notify when a state has changed
    void EnterState();
    void ExitState();
    void PhysicsUpdate(float delta);
    void Update(float delta);
}