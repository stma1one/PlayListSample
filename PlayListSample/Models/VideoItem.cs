namespace PlayListSample.Models;

/// <summary>
/// מודל נתונים המייצג סרטון בודד ברשימת ההשמעה.
/// בשלב זה המודל הוא POCO פשוט (Plain Old CLR Object),
/// אך המבנה והשדות שלו (כולל מזהה Id) מתוכננים כך שיתאימו ישירות ל-SQLite בהמשך הדרך.
/// </summary>
public class VideoItem
{
    public int Id { get; set; }
    
    public string Title { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public string ChannelName { get; set; } = string.Empty;

    public int DurationMinutes { get; set; }

    public bool IsWatched { get; set; }

    public string FormattedDuration => DurationMinutes > 0 ? $"{DurationMinutes} דק'" : "לא צוין";

    public string WatchedStatusText => IsWatched ? "נצפה ✓" : "טרם נצפה ⏳";
}
