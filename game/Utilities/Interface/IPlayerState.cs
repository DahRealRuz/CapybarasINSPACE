using Godot;
using System;

public interface IPlayerState
{
    void EnterState();
    void ExitState();
    void HandleInput(float delta);
}