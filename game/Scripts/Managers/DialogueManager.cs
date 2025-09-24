using Godot;
using System;
using System.Threading.Tasks;

public partial class DialogueManager : Node
{
    // Dialogue Lines and UI
    [Export] public Dialogue Tutorial1;
    //[Export] public Dialogue Tutorial2;
    [Export] public DialoguePanel Panel;

    private int currentLine = 0; // Track the current line of dialogue
    private Dialogue currentDialogue = null;
    private bool dialogActive = false; 
    public override void _Ready()
    {
        // Connecting the signals from the Dialogue Panel to the Methods
        Panel.NextDialogue += OnNextDialogue;
        Panel.DialogueFinished += OnDialogueFinished;
        Panel.DialogueStarted += OnDialogueStarted;
    }

    public override void _Process(double delta) {
        if (dialogActive && Input.IsActionJustPressed("ui_accept")) {
            Panel.OnNextDialogue();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (dialogue == null || dialogue.Lines.Count == 0)
        {
            GD.PrintErr("Dialogue is null or has no lines.");
            return;
        }
        currentDialogue = dialogue;
        currentLine = 0;
        dialogActive = true;

        Panel.DialoguePopIn();
        ShowCurrentLine();
    }

    private void OnNextDialogue()
    {
        currentLine++;
        if (currentLine < currentDialogue.Lines.Count)
        {
            ShowCurrentLine();
        }
        else
        {
            Panel.OnDialogueFinished(); // End the dialogue if there are no more lines
            dialogActive = false;
        }
    }

    private void ShowCurrentLine()
    {
        if (currentDialogue == null) return;
        GD.Print($"Showing line {currentLine}: {currentDialogue.Lines[currentLine]}");
        Panel.SetDialogueText(currentDialogue.Lines[currentLine]);
    }

    private void OnDialogueFinished()
    {
        Engine.TimeScale = 1.0f; // Resume the game when dialogue finishes
        dialogActive = false;
    }

    private async void OnDialogueStarted()
    {
        await ToSignal(GetTree().CreateTimer(0.75f), "timeout");
        Engine.TimeScale = 0.0f; // Pause the game when dialogue starts
    }   
}