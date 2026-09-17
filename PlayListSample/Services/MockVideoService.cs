using PlayListSample.Models;

namespace PlayListSample.Services;

/// <summary>
/// מימוש ראשוני של שירות הנתונים באמצעות רשימת נתונים סטטית בזיכרון (Mockup).
/// השירות מדמה השהייה קלה (Delay) כדי להרגיל את התלמידים לעבודה א-סינכרונית עם Task ו-async/await.
/// </summary>
public class MockVideoService : IVideoService
{
    private static readonly List<VideoItem> _videos = new()
    {
        new VideoItem
        {
            Id = 1,
            Title = "מבוא ל-MVVM ב-.NET MAUI",
            ChannelName = "קוד ישראלי",
            Url = "https://www.youtube.com/watch?v=intro_mvvm",
            DurationMinutes = 15,
            IsWatched = true
        },
        new VideoItem
        {
            Id = 2,
            Title = "עבודה עם Data Binding ופקודות",
            ChannelName = "מדריכי תוכנה",
            Url = "https://www.youtube.com/watch?v=bindings_commands",
            DurationMinutes = 22,
            IsWatched = false
        },
        new VideoItem
        {
            Id = 3,
            Title = "מהו INotifyPropertyChanged ומתי נשתמש בו",
            ChannelName = "אקדמיית דוטנט",
            Url = "https://www.youtube.com/watch?v=inpc_explained",
            DurationMinutes = 18,
            IsWatched = false
        },
        new VideoItem
        {
            Id = 4,
            Title = "הפרדת שכבות: Model, View, ViewModel, Service",
            ChannelName = "ארכיטקטורת תוכנה לבגרות",
            Url = "https://www.youtube.com/watch?v=clean_layers",
            DurationMinutes = 30,
            IsWatched = false
        }
    };

    private static int _nextId = 5;

    public async Task<List<VideoItem>> GetAllVideosAsync()
    {
        await Task.Delay(6100);
        return _videos.ToList();
    }

    public async Task<VideoItem?> GetVideoByIdAsync(int id)
    {
        await Task.Delay(50);
        return _videos.FirstOrDefault(v => v.Id == id);
    }

    public async Task<bool> AddVideoAsync(VideoItem video)
    {
        await Task.Delay(100);
        video.Id = _nextId++;
        _videos.Add(video);
        return true;
    }

    public async Task<bool> UpdateVideoAsync(VideoItem video)
    {
        await Task.Delay(3000);
        var existing = _videos.FirstOrDefault(v => v.Id == video.Id);
        if (existing == null) return false;

        existing.Title = video.Title;
        existing.Url = video.Url;
        existing.ChannelName = video.ChannelName;
        existing.DurationMinutes = video.DurationMinutes;
        existing.IsWatched = video.IsWatched;
        return true;
    }

    public async Task<bool> DeleteVideoAsync(int id)
    {
        await Task.Delay(100);
        var existing = _videos.FirstOrDefault(v => v.Id == id);
        if (existing == null) return false;

        return _videos.Remove(existing);
    }
}
