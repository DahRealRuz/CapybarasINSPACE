using Godot;
using System;

public partial class Tutorial : Node2D
{

	[Export] DialogueManager dialogueManager;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		dialogueManager.StartDialogue(dialogueManager.Tutorial1);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
