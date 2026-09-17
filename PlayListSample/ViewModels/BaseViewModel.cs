using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PlayListSample.ViewModels;

/// <summary>
/// מחלקת בסיס המממשת את ממשק INotifyPropertyChanged.
/// מאפשרת ל-ViewModel להודיע ל-View (למסך ב-XAML) כאשר ערך של מאפיין כלשהו השתנה,
/// כך שהמסך יתעדכן אוטומטית (Data Binding).
/// </summary>
public abstract class BaseViewModel : INotifyPropertyChanged
{
    private bool _isLoading;
    private string _title = string.Empty;

    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// האם מתבצעת פעולת טעינה ברקע (עבור ActivityIndicator)
    /// </summary>
    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            if (_isLoading != value)
            {
                _isLoading = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsNotLoading));
            }
        }
    }

    public bool IsNotLoading => !IsLoading;

    public string Title
    {
        get => _title;
        set
        {
            if (_title != value)
            {
                _title = value;
                OnPropertyChanged();
            }
        }
    }

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
