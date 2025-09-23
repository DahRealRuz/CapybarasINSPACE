using Godot;
using System;

public partial class DialoguePanel : Control
{
	[Signal] public delegate void DialogueFinishedEventHandler(); // Signal for next dialogue

	[Export] private Label dialogueLabe; // Label for dialogue text

	public override void _Ready()
	{
		Visible = false; // Hide the dialogue panel initially
	}
	public void SetDialogueText(string text) // Set the dialogue text
	{
		Visible = true; // Show the dialogue panel
		dialogueLabe.Text = text;
	}

	public void OnNextDialogueButtonPressed()
	{
		if (Input.IsActionJustPressed("ui_accept") && dialogueLabe.Text != "") // Check for input and if text is not empty
		{
			ClearDialogueText(); // Clear the dialogue text
			EmitSignal(nameof(DialogueFinished)); // Emit signal when dialogue is finished
			Visible = false;
		}
	}

	public void ClearDialogueText() // Clear the dialogue text
	{
		dialogueLabe.Text = "";
	}
}
