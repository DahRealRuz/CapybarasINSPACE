using Godot;
using System;
using System.Threading.Tasks;

public partial class MainMenu : Control
{
    // okay so for some reason I need to do 3 animation players for the 3 various sets so *fuck me then* lmao, this'll be funny
    // to whomever that decompiles this later, hi Cedric.
    [Export] private AnimationPlayer LettersDrifting;
    [Export] private AnimationPlayer Starfield;
    [Export] private AnimationPlayer Spaceship;
    [Export] private AnimationPlayer CameraAnimations;


    public override void _Ready()
    {
        Transition.Instance.TransitionAnimation.Play("FadeIn");
        LettersDrifting.Play("letters_drifting");
        Starfield.Play("StarfieldDriftLoop");
        Spaceship.Play("spaceshipLoop");
        // Yes the names are inconsistent, bite me i was tired (this is in the event i forget to change them proper later lmao)
        //TO DO: make names consistent, maybe also try to find a way to get these 3 animations to play from 1 player for efficiency
    }

    private void _on_play_pressed()
    {
        CameraAnimations.Play("MoonTransition");
    }

    private async void _on_camera_animations_animation_finished(string anim_name)
    {
        if (anim_name == "MoonTransition")
        {
            Transition.Instance.StartTransition();
            await ToSignal(Transition.Instance, "TransitionFinished");
            GetTree().ChangeSceneToFile("res://Scenes/Levels/europa.tscn");
        }
    }
}
