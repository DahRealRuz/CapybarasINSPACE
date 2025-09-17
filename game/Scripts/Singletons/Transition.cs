using Godot;
using System;


public partial class Transition : CanvasLayer
{
    [Signal] public delegate void TransitionFinishedEventHandler(); // Signal to notify when transition is done
    [Export] private AnimationPlayer TransitionAnimation;
    [Export] private ColorRect FadeRect;


    public override void _Ready()
    {
        FadeRect.Visible = false; // Ensure the fade rect is initially invisible, so it wont block view and u can click whats on the scene
        TransitionAnimation.AnimationFinished += OnTransitionAnimationFinished; // Connect the signal
    }

    public void OnTransitionAnimationFinished(string anim_name)
    {
        if (anim_name == "FadeOut")
        {
            OnTransitionFinished.Emit(); // Emit the signal to notify that transition is done
            TransitionAnimation.Play("FadeIn");
        }

        else if (anim_name == "FadeIn")
        {
            FadeRect.Visible = false;
        }
    }
    public void Transition()
    {
        FadeRect.Visible = true; // Makes it visible to start the transition
        TransitionAnimation.play("FadeOut");
    }


}
