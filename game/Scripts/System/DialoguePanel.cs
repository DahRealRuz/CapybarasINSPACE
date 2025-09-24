using Godot;
using System;

public partial class DialoguePanel : Control
{

	// Signals for dialogue events
	[Signal] public delegate void NextDialogueEventHandler(); 
	[Signal] public delegate void DialogueFinishedEventHandler(); 
	[Signal] public delegate void DialogueStartedEventHandler(); 

	// UI and Animation
	[Export] private Label dialogueLabel; 
	[Export] private AnimationPlayer animPlayer;

	public void SetDialogueText(string text) // Set the dialogue text
	{
		dialogueLabel.Text = text;
	}

	public void OnNextDialogue()
	{
		ClearDialogueText(); // Clear current text
		EmitSignal(nameof(NextDialogue)); // Emit signal for next dialogue
	}

	public void OnDialogueFinished()
	{
		EmitSignal(nameof(DialogueFinished)); // Emit signal when theres nothing more to be said
		ClearDialogueText();
		DialoguePopDown();
	}

	public void ClearDialogueText() // Clear the dialogue text
	{
		dialogueLabel.Text = "";
	}

	public void DialoguePopIn()
	{
		GD.Print($"Panel pos before popIn: {Position}");
		animPlayer.Play("popIn");
		EmitSignal(nameof(DialogueStarted)); // Emit signal when dialogue starts
		GD.Print("Im popping in!");
	}

	public void DialoguePopDown()
	{
		GD.Print($"Panel pos before popDown: {Position}");
		animPlayer.Play("popDown");
	}
}
