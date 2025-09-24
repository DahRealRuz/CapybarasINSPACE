using Godot;
using System;

public partial class DialoguePanel : Control
{
	[Signal] public delegate void NextDialogueEventHandler(); // Signal for next dialogue
	[Signal] public delegate void DialogueFinishedEventHandler(); // Signal for when the dialogue is done

	[Export] private Label dialogueLabel; // Label for dialogue text
	[Export] private AnimationPlayer animPlayer;

	public static DialoguePanel Instance { get; private set; } // Singleton instance

    public override void _Ready()
    {
		Instance = this;
    }


	public void SetDialogueText(string text) // Set the dialogue text
	{
		dialogueLabel.Text = text;
	}

	public void OnNextDialogue()
	{
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
		animPlayer.Play("popIn");
	}

	public void DialoguePopDown()
	{
		animPlayer.Play("popDown");
	}
}
