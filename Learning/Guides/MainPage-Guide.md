# מדריך פיתוח מסך ראשי: MainPage — ניהול פלייליסט ודפדוף ב-MVVM

> שיטת הבלוקים המודולרית (The Block Strategy) לבניית ממשק משתמש ב-.NET MAUI

---

## 🎯 1. מבוא והשראה עיצובית: בונים מסך ניהול תוכן ממוקד ואינטראקטיבי

אי פעם שאלתם את עצמכם איך אפליקציות מציגות פריט בודד בצורה ממוקדת וברורה — כמו נגן שירים שמאפשר לדפדף בין רצועות, או כרטיסיית למידה שבה מתמקדים בכל פעם במושג אחד בלבד?
לצד רשימות ארוכות, **תצוגת פריט בודד עם דפדוף (Single-Item Pagination)** היא אחד מדפוסי הממשק החשובים ביותר בפיתוח אפליקציות מובייל: היא מונעת עומס קוגניטיבי ומאפשרת למשתמש להתרכז בתוכן הנוכחי.

במדריך זה נבנה צעד-אחר-צעד את מסך ה-`MainPage` של פרויקט **PlayListSample**. נלמד כיצד לשלב במסך אחד שני צרכים מרכזיים:
1. **דפדוף חלק בסרטונים** עם כפתורי קדימה/אחורה המוגנים בלוגיקת `CanExecute`.
2. **טופס הזנה עשיר** המעדכן את הנתונים בזמן אמת בטכניקת **Two-Way Data Binding**.

### 📱 מפת הבלוקים של המסך (Visual Block Architecture)
להלן מפת היעד החזותית של המסך, כפי שחולקה לבלוקים פונקציונליים ברורים:

![מפת הבלוקים של מסך MainPage](../Images/MainPage-overview.png)

---

## 🧭 2. איך המדריך הזה בנוי? (The Meta-Frame)

כדי שתוכלו להבין כל שורת קוד ולשלוט בממשק ב-100%, נפעל לפי 3 עקרונות פדגוגיים מנחים:

- ➖ **דיאגרמה חזותית מפורקת (Visual Diagram):** חילקנו את המסך לשני בלוקים צבעוניים עיקריים בנוסף לבאנר הראשי. בכל שלב נתמקד בבלוק אחד בלבד.
- ➖ **קוד מודולרי עם נקודות עוגן (Modular Code with Placeholders):** נתחיל עם שלד הגריד והערות מקום (`<!-- כאן יבוא הבלוק הבא -->`), ונרכיב כל רכיב בנפרד.
- ➖ **התקדמות הדרגתית מלווה בצילומי מסך ממוקדים:** לכל בלוק מוצגת תמונת תוצאה מתוך ההדמיה, לצד פינות העמקה (*Deep-Dive Callouts*) על טכניקות מפתח.

---

## 🔧 3. הכנת סביבת העבודה ומרחבי שמות (Namespaces)

לפני שמתחילים בעיצוב ה-XAML, נוודא שראש הקובץ `MainPage.xaml` כולל את מרחבי השמות הדרושים לקישור ה-ViewModel והמודלים, וכן את הגדרת כיוון המסך מימין-לשמאל:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:vm="clr-namespace:PlayListSample.ViewModels"
             x:Class="PlayListSample.Views.MainPage"
             x:DataType="vm:MainViewModel"
             Title="{Binding Title}"
             FlowDirection="RightToLeft">

    <!-- כאן יבוא שלד הגריד הראשי -->

</ContentPage>
```

> [!TIP]
> ### 💡 מדוע הגדרנו `x:DataType="vm:MainViewModel"`?
> זהו מנגנון **Compiled Bindings** של .NET MAUI. הוא מאפשר לקומפיילר לבדוק בזמן הידור שכל שדה ופקודה קיימים באמת ב-ViewModel, מונע שגיאות כתיב חבויות, ומשפר את ביצועי האפליקציה בריצה!

---

## 📐 4. אסטרטגיית הבלוקים (The Block Strategy)

> [!IMPORTANT]
> **הנחיית כתיבת קוד (XAML Line-Breaking Standard):**
> בספרי תכנות מקצועיים לעולם אין לכתוב תגיות XAML ארוכות העולות על 65-70 תווים בשורה אחת. בכל תגית המכילה 2 תכונות ומעלה — יש לרדת שורה עבור כל תכונה (*Attribute-per-line indent*). זה מונע חיתוך טקסט ב-PDF ומבטיח קוד קריא ונקי!

### שלב 4.0: שלד הגריד הראשי ומחוון הטעינה (Layout Backbone & Loading)

עמוד השדרה של המסך עטוף ב-`ScrollView` המאפשר גלילה חלקה בכל גודל מסך:

```xml
<ScrollView>
    <VerticalStackLayout Padding="20"
                         Spacing="16">

        <!-- כותרת ראשית ומחוון טעינה -->
        <Label Text="{Binding Title}"
               FontSize="22"
               FontAttributes="Bold"
               HorizontalOptions="Center" />

        <ActivityIndicator IsRunning="{Binding IsLoading}"
                           IsVisible="{Binding IsLoading}"
                           HorizontalOptions="Center" />

        <!-- בלוק 1: דפדוף ותצוגת סרטון בודד -->
        <!-- בלוק 2: טופס הוספת סרטון חדש -->

    </VerticalStackLayout>
</ScrollView>
```

---

### שלב 4.1: כותרת עליונה ובאנר ראשי (Hero Banner)

![באנר ראשי](../Images/MainPage-hero.png)

כרטיס כותרת מעוצב בגווני כחול המעניק חוויית פתיחה מקצועית:

```xml
<Border StrokeShape="RoundRectangle 12"
        BackgroundColor="#2563EB"
        Padding="16"
        StrokeThickness="0">
    <VerticalStackLayout Spacing="4">
        <Label Text="🎬 ניהול פלייליסט - חזרה על MVVM"
               FontSize="19"
               FontAttributes="Bold"
               TextColor="White"
               HorizontalOptions="Center" />
        <Label Text="דפדוף, פקודות CanExecute וטופס הזנה Two-Way"
               FontSize="12"
               TextColor="#DBEAFE"
               HorizontalOptions="Center" />
    </VerticalStackLayout>
</Border>
```

---

### שלב 4.2: בלוק 1 — דפדוף ותצוגת סרטון בודד (Item Viewer & Pagination)

![בלוק 1: דפדוף בסרטונים](../Images/MainPage-block1-browser.png)

בלוק זה מציג סרטון אחד בכל רגע נתון מתוך הרשימה, ומאפשר לנווט בין סרטונים בעזרת כפתורי "הקודם" ו"הבא" לצד שינוי סטטוס הצפייה:

```xml
<!-- חלק 1: דפדוף ותצוגת פריט בודד מתוך השירות -->
<Border StrokeShape="RoundRectangle 8"
        Padding="14"
        BackgroundColor="White"
        Stroke="#E2E8F0">
    <VerticalStackLayout Spacing="10">

        <Label Text="📺 דפדוף בסרטונים (תצוגת פריט בודד)"
               FontSize="16"
               FontAttributes="Bold"
               TextColor="#0F172A" />

        <!-- סרגל דפדוף (Next / Previous) -->
        <Grid ColumnDefinitions="Auto, *, Auto">
            <Button Grid.Column="0"
                    Text="⬅ הקודם"
                    Command="{Binding PreviousCommand}"
                    BackgroundColor="#2563EB"
                    TextColor="White" />

            <Label Grid.Column="1"
                   Text="{Binding CurrentPositionText}"
                   FontAttributes="Bold"
                   FontSize="12"
                   HorizontalOptions="Center"
                   VerticalOptions="Center" />

            <Button Grid.Column="2"
                    Text="הבא ➡"
                    Command="{Binding NextCommand}"
                    BackgroundColor="#2563EB"
                    TextColor="White" />
        </Grid>

        <BoxView HeightRequest="1"
                 Color="#E2E8F0"
                 Margin="0,4" />

        <!-- פרטי הפריט הנוכחי המוצג על המסך -->
        <Label Text="{Binding CurrentVideo.Title, StringFormat='כותרת: {0}'}"
               FontSize="15"
               FontAttributes="Bold" />

        <Label Text="{Binding CurrentVideo.ChannelName, StringFormat='ערוץ: {0}'}"
               FontSize="13"
               TextColor="#475569" />

        <Label Text="{Binding CurrentVideo.FormattedDuration, StringFormat='משך: {0}'}"
               FontSize="13"
               TextColor="#475569" />

        <Label Text="{Binding CurrentVideo.Url, StringFormat='כתובת אינטרנט: {0}'}"
               FontSize="12"
               TextColor="#1D4ED8"
               LineBreakMode="TailTruncation" />

        <Label Text="{Binding CurrentVideo.WatchedStatusText, StringFormat='סטטוס: {0}'}"
               FontSize="13"
               FontAttributes="Bold" />

        <Button Text="🔄 שנה סטטוס צפייה"
                Command="{Binding ToggleWatchedCommand}"
                BackgroundColor="#F8FAFC"
                TextColor="#1E293B"
                BorderColor="#CBD5E1"
                BorderWidth="1"
                Margin="0,6,0,0" />

    </VerticalStackLayout>
</Border>
```

---

### שלב 4.3: בלוק 2 — טופס הוספת סרטון חדש (Two-Way Form Input)

![בלוק 2: טופס הוספת סרטון](../Images/MainPage-block2-form.png)

בלוק זה מאפשר למשתמש להקליד נתוני סרטון חדש. הקישור הדו-כיווני (`Mode=TwoWay`) מעדכן מיידית את שדות ה-ViewModel, וכפתור השמירה מוסיף את הסרטון ועובר אליו אוטומטית:

```xml
<!-- חלק 2: טופס הזנה של פריט בודד -->
<Border StrokeShape="RoundRectangle 8"
        Padding="14"
        BackgroundColor="White"
        Stroke="#E2E8F0">
    <VerticalStackLayout Spacing="8">

        <Label Text="➕ הוספת סרטון חדש (טופס קלט)"
               FontSize="16"
               FontAttributes="Bold"
               TextColor="#0F172A" />

        <Label Text="כותרת הסרטון:"
               FontSize="12"
               TextColor="#475569" />
        <Entry Placeholder="הזן כותרת..."
               Text="{Binding InputTitle, Mode=TwoWay}" />

        <Label Text="שם הערוץ:"
               FontSize="12"
               TextColor="#475569" />
        <Entry Placeholder="הזן ערוץ..."
               Text="{Binding InputChannelName, Mode=TwoWay}" />

        <Label Text="משך בדקות:"
               FontSize="12"
               TextColor="#475569" />
        <Entry Placeholder="למשל 15"
               Keyboard="Numeric"
               Text="{Binding InputDurationText, Mode=TwoWay}" />

        <Label Text="כתובת אינטרנט (URL):"
               FontSize="12"
               TextColor="#475569" />
        <Entry Placeholder="https://..."
               Text="{Binding InputUrl, Mode=TwoWay}" />

        <Grid ColumnDefinitions="*, *"
              ColumnSpacing="10"
              Margin="0,8,0,0">
            <Button Grid.Column="0"
                    Text="💾 שמור סרטון"
                    Command="{Binding SaveCommand}"
                    BackgroundColor="#10B981"
                    TextColor="White" />

            <Button Grid.Column="1"
                    Text="🧹 נקה טופס"
                    Command="{Binding ClearFormCommand}"
                    BackgroundColor="#F1F5F9"
                    TextColor="#475569" />
        </Grid>

        <Label Text="{Binding StatusMessage}"
               FontSize="12"
               TextColor="#4338CA"
               HorizontalOptions="Center" />

    </VerticalStackLayout>
</Border>
```

---

## ✍️ 5. פינות העמקה והבנה מושגית (Deep-Dive Callouts)

> [!TIP]
> ### 🔍 1. מה ההבדל בין קישור חד-כיווני (One-Way) לדו-כיווני (Two-Way)?
> - בקישור **One-Way** (ברירת המחדל ברכיבי `Label`): הנתונים זורמים רק מה-ViewModel אל המסך. שינוי ב-C# מעדכן את התצוגה.
> - בקישור **Two-Way** (בשדות `Entry` בטופס): הנתונים זורמים בשני הכיוונים! כל תו שהמשתמש מקליד בתיבת הטקסט מוזרם אוטומטית אל התכונה המתאימה ב-ViewModel, כך שכשלוחצים על "שמור", הנתונים כבר מעודכנים ב-C# ללא צורך בקריאה ידנית של `entry.Text`!
>
> 🔗 תיעוד רשמי: [Microsoft Learn - Data Binding Modes](https://learn.microsoft.com/dotnet/maui/fundamentals/data-binding/binding-mode)

> [!TIP]
> ### 🔍 2. כיצד `CanExecute` מגן על כפתורי הניווט מפני קריסות?
> מה היה קורה אילו המשתמש היה לוחץ על "הקודם" כשהוא כבר בסרטון הראשון (`Index = 0`), או על "הבא" בסרטון האחרון?  
> הקוד היה מנסה לגשת לאינדקס `-1` או `Count` ומקפיץ מיד חריגת `ArgumentOutOfRangeException` שהייתה קורסת את האפליקציה!  
> בזכות הגדרת `CanExecuteNext` ו-`CanExecutePrevious` ב-`MainViewModel`:
> ```csharp
> private bool CanExecutePrevious() => IsNotLoading && _videos.Count > 0 && _currentIndex > 0;
> private bool CanExecuteNext() => IsNotLoading && _videos.Count > 0 && _currentIndex < _videos.Count - 1;
> ```
> מערכת .NET MAUI מנטרלת את הכפתור (אפור) ברגע שמגיעים לקצה הרשימה, וחוסמת לחיצות שגויות באופן הרמטי!
>
> 🔗 תיעוד רשמי: [Microsoft Learn - The Command Interface](https://learn.microsoft.com/dotnet/maui/fundamentals/data-binding/commanding)

> [!TIP]
> ### 🔍 3. למה להשתמש ב-`ActivityIndicator` ולא ב-`Page.IsBusy`?
> בעבר ב-Xamarin השתמשו לעיתים במאפיין של הדף. בארכיטקטורת MVVM מודרנית, הדף אינו אמור לנהל מצבי מערכת. ה-ViewModel מחזיק את המשתנה הבוליאני `IsLoading`, ומעדכן את הממשק דרך `INotifyPropertyChanged`. כך הלוגיקה ניתנת לבדיקה מלאה בבדיקות יחידה (Unit Tests) ללא תלות בממשק גרפי!

---

## ⚙️ 6. ארכיטקטורת MVVM וחיבור הנתונים (State & Commands)

כדי לחבר את הממשק בצורה נקייה, ה-`MainViewModel` מרכז את ניהול המצב והפעולות:

### 1. ניהול הפריט המוצג וטקסט המיקום
```csharp
public VideoItem? CurrentVideo
{
    get => _currentVideo;
    private set
    {
        if (_currentVideo != value)
        {
            _currentVideo = value;
            OnPropertyChanged();
        }
    }
}

public string CurrentPositionText
{
    get => _currentPositionText;
    private set
    {
        if (_currentPositionText != value)
        {
            _currentPositionText = value;
            OnPropertyChanged();
        }
    }
}
```

### 2. עקרון פיתוח מקצועי: רענון פקודות (`RefreshCommands`)
בכל פעם שהאינדקס משתנה או שמתווסף סרטון חדש, אנו מפעילים רענון לכל הפקודות:
```csharp
private void RefreshCommands()
{
    ((Command)NextCommand).ChangeCanExecute();
    ((Command)PreviousCommand).ChangeCanExecute();
    ((Command)SaveCommand).ChangeCanExecute();
    ((Command)ToggleWatchedCommand).ChangeCanExecute();
    ((Command)ClearFormCommand).ChangeCanExecute();
}
```
קריאה זו מאותתת ל-XAML לבדוק מחדש את תנאי ה-`CanExecute`, ומשנה את מצב הכפתורים (זמינים או מושבתים) מיד!

---

## ❓ 7. שאלות חזרה, הבנה ואתגר חשיבה

### ⚖️ חלק א': דילמת ארכיטקטורה ועיצוב (Architectural Dilemma)

**הדילמה: תצוגת דפדוף בודד (Single-Item Pagination) לעומת רשימה נגללת (CollectionView)?**  
בפרויקט הנוכחי בחרנו להציג סרטון אחד בכל פעם עם כפתורי דפדוף, בעוד שבפרויקטים אחרים משתמשים ברשימת כרטיסים נגללת (`CollectionView`).
- **יתרונות תצוגת פריט בודד:** מיקוד מקסימלי של המשתמש, חיסכון בזיכרון (המסך אינו צריך לצייר עשרות פריטים בו-זמנית), ומניעת בלבול בעת עבודה על פריט ספציפי (כגון שאלון, כרטיסיית למידה, או נגן).
- **יתרונות רשימה נגללת:** סקירה מהירה של הרבה פריטים בו-זמנית, גלילה רציפה, וחיפוש ויזואלי מהיר.

> [!TIP]
> **שיקול החלטה למפתח:** בחרו בתצוגת פריט בודד כאשר המשתמש צריך להתרכז בפעולה על אובייקט אחד (קריאה, עריכה, האזנה). בחרו ב-`CollectionView` כאשר המטרה היא סקירה ובחירה מתוך קטלוג.

---

### 🧠 חלק ב': שאלות הבנה מעמיקות עם רמזי הכוונה

1. **מה יקרה אם נמחק את הקריאה ל-`ChangeCanExecute()` בתוך מתודת `RefreshCommands()`?**
   > [!TIP]
   > **רמז לחשיבה:** חשבו על כפתור "הבא" כשמגיעים לסרטון האחרון. האם הכפתור ישתנה לאפור מעצמו בלי שה-ViewModel יודיע ל-XAML לבדוק את התנאי שוב?

2. **מדוע בשדות הטופס ציינו `Mode=TwoWay`, בעוד שבפרטי הסרטון הנוכחי הסתפקנו ב-One-Way?**
   > [!TIP]
   > **רמז לחשיבה:** מי יוזם את שינוי המידע בטופס? ומי יוזם את שינוי המידע בדפדוף בין סרטונים?

3. **כיצד מנגנון ה-`ActivityIndicator` משתלב עם `IsLoading` כדי למנוע לחיצות כפולות בזמן שמירה?**
   > [!TIP]
   > **רמז לחשיבה:** שימו לב לתנאי הביצוע של פקודת השמירה: `() => IsNotLoading`. מה קורה לתנאי זה בזמן ש-`IsLoading = true`?

---

### 🛠️ חלק ג': אתגר מעשי קצר לתלמיד (Mini-Challenge)

**המשימה:**  
הוסיפו לסרגל הדפדוף בבלוק 1 שני כפתורים נוספים:
1. **כפתור "ראשון" (`⏮️`):** קופץ ישירות לסרטון הראשון ברשימה (`_currentIndex = 0`).
2. **כפתור "אחרון" (`⏭️`):** קופץ ישירות לסרטון האחרון ברשימה (`_currentIndex = _videos.Count - 1`).

**שלבי יישום מודרכים:**

1. **שכבת ה-ViewModel (`MainViewModel.cs`):**
   - הגדירו שתי פקודות חדשות: `FirstCommand` ו-`LastCommand`.
   - בבנאי חברו אותן למתודות ביצוע עם תנאי `CanExecute`:
   ```csharp
   FirstCommand = new Command(() => { _currentIndex = 0; UpdateCurrentVideo(); }, CanExecutePrevious);
   LastCommand = new Command(() => { _currentIndex = _videos.Count - 1; UpdateCurrentVideo(); }, CanExecuteNext);
   ```
   - הוסיפו את שתי הפקודות למתודת `RefreshCommands()`:
   ```csharp
   ((Command)FirstCommand).ChangeCanExecute();
   ((Command)LastCommand).ChangeCanExecute();
   ```

2. **שכבת ה-XAML (`MainPage.xaml`):**
   - שנו את הגריד של סרגל הדפדוף מ-`Auto, *, Auto` ל-`Auto, Auto, *, Auto, Auto`:
   ```xml
   <Grid ColumnDefinitions="Auto, Auto, *, Auto, Auto"
         ColumnSpacing="6">
       <Button Grid.Column="0"
               Text="⏮️"
               Command="{Binding FirstCommand}" />

       <Button Grid.Column="1"
               Text="⬅ הקודם"
               Command="{Binding PreviousCommand}" />

       <Label Grid.Column="2"
              Text="{Binding CurrentPositionText}"
              HorizontalOptions="Center"
              VerticalOptions="Center" />

       <Button Grid.Column="3"
               Text="הבא ➡"
               Command="{Binding NextCommand}" />

       <Button Grid.Column="4"
               Text="⏭️"
               Command="{Binding LastCommand}" />
   </Grid>
   ```

3. **אימות:** הריצו את האפליקציה, וודאו שכפתור "ראשון" מנוטרל כשאתם בסרטון 1, וכפתור "אחרון" מנוטרל כשמגיעים לסוף הרשימה!

---

## 📖 נספח: מקורות השראה, תיעוד וביבליוגרפיה

<div style="font-size: 9.5pt; color: #64748b; line-height: 1.6; border-top: 1px solid #e2e8f0; padding-top: 14px; margin-top: 24px;">
מדריך זה נבנה בהשראת מתודולוגיית הפירוק המודולרי של ממשקי מובייל (The Block Strategy) כפי שפותחה ע"י <strong>Leomaris Reyes</strong> (Microsoft MVP, יוצרת AskXammy.com וכותבת סדרת מאמרי ממשק ב-Telerik).<br>
תיעוד רשמי ומקורות נוספים להעמקה:
<ul style="margin-top: 6px; padding-right: 20px;">
  <li>Microsoft Learn: <a href="https://learn.microsoft.com/dotnet/maui/">מדריך הפיתוח הרשמי ל-.NET MAUI</a></li>
  <li>Microsoft Learn: <a href="https://learn.microsoft.com/dotnet/maui/fundamentals/data-binding/">עקרונות Data Binding וארכיטקטורת MVVM</a></li>
  <li>Microsoft Learn: <a href="https://learn.microsoft.com/dotnet/maui/fundamentals/data-binding/commanding">ממשק ICommand ותנאי CanExecute</a></li>
  <li>Microsoft Learn: <a href="https://learn.microsoft.com/dotnet/maui/fundamentals/data-binding/binding-mode">מצבי קישור נתונים (Binding Modes) ב-.NET MAUI</a></li>
</ul>
</div>
