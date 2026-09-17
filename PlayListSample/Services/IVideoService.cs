using PlayListSample.Models;

namespace PlayListSample.Services;

/// <summary>
/// ממשק שירות הנתונים לניהול סרטונים.
/// כל הפעולות מוגדרות כא-סינכרוניות (Task) כדי לשמור על עקרונות ארכיטקטורה נכונה
/// ולאפשר החלפה חלקה בעתיד לשירות SQLite או מסד נתונים מרוחק, ללא שינוי בקוד ה-ViewModel!
/// </summary>
public interface IVideoService
{
    Task<List<VideoItem>> GetAllVideosAsync();

    Task<VideoItem?> GetVideoByIdAsync(int id);

    Task<bool> AddVideoAsync(VideoItem video);

    Task<bool> UpdateVideoAsync(VideoItem video);

    Task<bool> DeleteVideoAsync(int id);
}
