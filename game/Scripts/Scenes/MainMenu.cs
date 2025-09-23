using Godot;
using System;
using System.Threading.Tasks;

public partial class MainMenu : Control
{
    /* 
    okay so for some reason I need to do 3 animation players for the 3 various sets so *fuck me then* lmao, this'll be funny
    to whomever that decompiles this later, hi Cedric.
    */ 
    [ExportCategory("Animation Players")]
    [Export] private AnimationPlayer LettersDrifting;
    [Export] private AnimationPlayer Starfield;
    [Export] private AnimationPlayer Spaceship;
    [Export] private AnimationPlayer CameraAnimations;
    [ExportCategory("Sprites")]
    [Export] private Sprite2D Moon_spr;
    [Export] private Sprite2D Spaceship_spr;



    public override void _Ready()
    {
        MusicPlayer.Instance.PlayMusic("Menu");
        Transition.Instance.TransitionAnimation.Play("FadeIn");
        LettersDrifting.Play("letters_drifting");
        Starfield.Play("StarfieldDriftLoop");
        Spaceship.Play("spaceshipLoop");
        /* 
        Yes the names are inconsistent, bite me i was tired (this is in the event i forget to change them proper later lmao)
        I will need to make names consistent, maybe also try to find a way to get these 3 animations to play from 1 player for efficiency
        */
    }

    private void _on_play_pressed()
    {
        CameraAnimations.Play("MoonTransition");
        // We'll be making a tween for the moon so it can smoothly transition in place
        Tween tween = GetTree().CreateTween();
        tween.TweenProperty(Moon_spr, "position:y", 536.0, 0.75f); // Move the moon to y=536 over 0.5 seconds, which is it's original point
    }

    private void _on_tutorial_pressed()
    {
        CameraAnimations.Play("ShipTransition");
        Tween tween = GetTree().CreateTween();
        tween.TweenProperty(Spaceship_spr, "position:y", 521.0, 0.75f);
        tween.TweenProperty(Spaceship_spr, "rotation", 0.0, 0.75f);
    }

    private void _on_quit_pressed()
    {
        GetTree().Quit();
    }

    private async void _on_camera_animations_animation_finished(string anim_name)
    {
        if (anim_name == "MoonTransition")
        {
            Transition.Instance.StartTransition();
            await ToSignal(Transition.Instance, "TransitionFinished");
            MusicPlayer.Instance.StopMusic();
            GetTree().ChangeSceneToFile("res://Scenes/Levels/europa.tscn");
        } 

        else if (anim_name == "ShipTransition")
        {
            Transition.Instance.StartTransition();
            await ToSignal(Transition.Instance, "TransitionFinished");
            MusicPlayer.Instance.StopMusic();
            GetTree().ChangeSceneToFile("res://Scenes/Levels/europa.tscn");
        }
    }
}
