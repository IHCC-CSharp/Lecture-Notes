namespace StudyGuide.Models;

public class Playlist(string name)
{
    private readonly List<string> songs = [];

    public string Name { get; } = name;
    public int SongCount => songs.Count;

    public void AddSong(string song)
    {
        songs.Add(song);
    }
}
