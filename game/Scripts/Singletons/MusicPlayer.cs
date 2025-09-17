using Godot;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

public partial class MusicPlayer : AudioStreamPlayer2D
{
    [ExportCategory("Music")] // This is where I'll put the music for this music player to use woo
    [Export(PropertyHint.File, "*.ogg,*.wav,*.mp3")] public string MenuMusic { get; set; }

    private string currentMusic = ""; // This will hold what the  song to play
    public static MusicPlayer Instance { get; private set; } // Singleton instance

    public override void _Ready()
    {
        Instance = this; 
    }

    public void PlayMusic(string songName)
    {
        if (songName == currentMusic) return; // If the song is already playing, don't do anything

        currentMusic = songName; // Set the current music to the new song

        switch (songName) 
        {
            case "Menu":
                Stream = GD.Load<AudioStream>(MenuMusic);
                Play();
                GD.Print("MusicPlayer: Playing Menu Music");
                break;

            default:
                GD.PrintErr($"MusicPlayer: Unknown song name '{songName}'");
                return;
        }

    }

    public void StopMusic()
    {
        Stop();
        currentMusic = ""; // Reset current music, so I can play a new song later in a different scene.
    }

}
