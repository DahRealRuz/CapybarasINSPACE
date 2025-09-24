using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class Dialogue : Resource
{
    [Export] public string DialogueName { get; set; } = "";
    [Export] public Godot.Collections.Array<string> DialogueLines { get; set; } = new Godot.Collections.Array<string>();
}