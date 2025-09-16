using Godot;
using System;

public partial class MainMenu : Control
{
    // okay so for some reason I need to do 3 animation players for the 3 various sets so *fuck me then* lmao, this'll be funny
    // to whomever that decompiles this later, hi Cedric.
    [Export] private AnimationPlayer LettersDrifting; 
    [Export] private AnimationPlayer Starfield; 
    [Export] private AnimationPlayer Spaceship;


    public override void _Ready()
    {
        LettersDrifting.Play("letters_drifting");
        Starfield.Play("StarfieldDriftLoop");
        Spaceship.Play("spaceshipLoop");
        // Yes the names are inconsistent, bite me i was tired (this is in the event i forget to change them proper later lmao)
        //TO DO: make names consistent, maybe also try to find a way to get these 3 animations to play from 1 player for efficiency
    }
}
