using Godot;
using System;

public partial class DialogueManager : Node
{
    // Dialogue Lines and UI
    [Export] public Dialogue Tutorial1;
    [Export] public Control Panel;

    private int currentLine = 0; // Track the current line of dialogue

    public override void _Ready()
    {
        // Conectingg the signals from the Dialogue Panel to the Methods
        Panel.NextDialogue += OnNextDialogue;
        Panel.DialogueFinished += OnDialogueFinished;
        Panel.DialogueStarted += OnDialogueStarted;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        currentLine = 0;
        Panel.DialoguePopIn();
        ShowCurrentLine();
    }

    private void OnNextDialogue()
    {
        currentLine++;
        if (currentLine < Tutorial1.Lines.Count)
        {
            ShowCurrentLine();
        }
        else
        {
            Panel.OnDialogueFinished();
        }
    }

    private void ShowCurrentLine()
    {
        Panel.SetDialogueText(Tutorial1.Lines[currentLine]);
    }

    private void OnDialogueFinished()
    {
        GD.Print("Dialogue Finished");
        // Additional logic when dialogue finishes can be added here
    }

    private void OnDialogueStarted()
    {
        GD.Print("Dialogue Started");
        // Additional logic when dialogue starts can be added here
    }   
}