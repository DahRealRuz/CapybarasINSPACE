using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Capybara : CharacterBody2D
{
	[ExportCategory("Capybara Stats")]
	[Export] public Resource CapybaraStats;
	public const float JumpVelocity = -400.0f;

	// Properties to hold stats
	public int Speed { set; get; }
	public int Health { set; get; }
	public int Defense { set; get; }


    public override void _Ready()
	{

		// Load stats from the CapybaraStats resource
		if (CapybaraStats != null)
		{
			GD.Print("Capybara Stats Loaded");
			Stats stats = (Stats)CapybaraStats;
			Health = stats.Health;
			Speed = stats.Speed;
			Defense = stats.Defense;
			GD.Print($"Health: {Health}, Speed: {Speed}, Defense: {Defense}");
		}
		else
		{
			GD.Print("No Capybara Stats Resource assigned.");
		}
	}   

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
