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

	// This will set the text for the panel
	public void SetDialogueText(string text) 
	{
		dialogueLabel.Text = text;
	}

	// This will be called when the player wants to see the next line of dialogue
	public void OnNextDialogue()
	{
		ClearDialogueText();
		EmitSignal(nameof(NextDialogue));
	}

	// This will be called when the dialogue is finished
	public void OnDialogueFinished()
	{
		EmitSignal(nameof(DialogueFinished)); 
		ClearDialogueText();
		DialoguePopDown();
	}

	// This will clear the dialogue text
	public void ClearDialogueText() 
	{
		dialogueLabel.Text = "";
	}

	// Animation Methods
	public void DialoguePopIn()
	{
		animPlayer.Play("popIn");
		EmitSignal(nameof(DialogueStarted)); // Emit signal when dialogue starts
	}

	public void DialoguePopDown()
	{
		animPlayer.Play("popDown");
	}
}
