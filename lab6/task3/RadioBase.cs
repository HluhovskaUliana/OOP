using System;
using System.Collections.Generic;

public class InvalidSongException : Exception
{
    public InvalidSongException(string message = "Invalid song.") 
        : base(message) { }
}

public class InvalidArtistNameException : InvalidSongException
{
    public InvalidArtistNameException() 
        : base("Artist name should be between 3 and 20 symbols.") { }
}

public class InvalidSongNameException : InvalidSongException
{
    public InvalidSongNameException() 
        : base("Song name should be between 3 and 30 symbols.") { }
}

public class InvalidSongLengthException : InvalidSongException
{
    public InvalidSongLengthException(string message =  "Invalid song length.") 
        : base(message) { }
}

public class InvalidSongMinutesException : InvalidSongLengthException
{
    public InvalidSongMinutesException() 
        : base("Song minutes should be between 0 and 14.") { }
}

public class InvalidSongSecondsException : InvalidSongLengthException
{
    public InvalidSongSecondsException() 
        : base("Song seconds should be between 0 and 59.") { }
}

public class Song
{
    public string ArtistName { get; }
    public string SongName { get; }
    public int Minutes { get; }
    public int Seconds { get; }

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        if (artistName.Length < 3 || artistName.Length > 20 )
            throw new InvalidArtistNameException();
        if (songName.Length < 3 || songName.Length > 30)
            throw new InvalidSongNameException();
        if (minutes < 0 || minutes > 14)
            throw new InvalidSongMinutesException();
        if (seconds < 0 || seconds > 59)
            throw new InvalidSongSecondsException();
        
        ArtistName = artistName;
        SongName = songName;
        Minutes = minutes;
        Seconds = seconds;
    }
    
    public int DurationInSeconds => Minutes * 60 + Seconds;
}

class Program
{
    static void Main()
    {
        int numberOfSongs = int.Parse(Console.ReadLine());
        var songs = new List<Song>();
        int totalSeconds = 0;

        for (int i = 0; i < numberOfSongs; i++)
        {
            string input = Console.ReadLine();
            try
            {
                var parts = input.Split(';');
                if (parts.Length != 3)
                    throw new InvalidSongLengthException();

                string artist = parts[0];
                string title = parts[1];
                var timeParts = parts[2].Split(':');

                if (timeParts.Length != 2 ||
                    !int.TryParse(timeParts[0], out int minutes) ||
                    !int.TryParse(timeParts[1], out int seconds))
                {
                    throw new InvalidSongLengthException();
                }

                var song = new Song(artist, title, minutes, seconds);
                songs.Add(song);
                totalSeconds += song.DurationInSeconds;
                Console.WriteLine("Song added.");
            }
            catch (InvalidSongException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        Console.WriteLine($"Songs added: {songs.Count}");
        Console.WriteLine($"Playlist length: {totalSeconds / 3600}h {totalSeconds % 3600 / 60}m {totalSeconds % 60}s");

        Console.ReadKey();
    }
}