using Godot;
using System;


public partial class Transition : CanvasLayer
{
    [Signal] public delegate void TransitionFinishedEventHandler(); // Signal to notify when transition is done
    public AnimationPlayer TransitionAnimation;
    public ColorRect FadeRect;

    public static Transition Instance { get; private set; } // Singleton instance


    public override void _Ready()
    {
        Instance = this;

        TransitionAnimation = GetNode<AnimationPlayer>("TransitionAnimation");
        FadeRect = GetNode<ColorRect>("FadeRect");

        TransitionAnimation.Connect("animation_finished", new Callable(this, nameof(OnTransitionAnimationFinished)));
    }

    public void OnTransitionAnimationFinished(string anim_name)
    {
        if (anim_name == "FadeOut")
        {
            EmitSignal(nameof(TransitionFinished)); // Notify that the transition is done
            TransitionAnimation.Play("FadeIn");
        }

        else if (anim_name == "FadeIn")
        {
            FadeRect.Visible = false;
        }
    }
    public void StartTransition()
    {
        FadeRect.Visible = true; // Makes it visible to start the transition
        TransitionAnimation.Play("FadeOut");
    }


}
