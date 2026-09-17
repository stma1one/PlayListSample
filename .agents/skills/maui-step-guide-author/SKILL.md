---
name: maui-step-guide-author
description: Author comprehensive, step-by-step .NET MAUI learning guides and UI replications following Leomaris Reyes' (AskXammy) Block Strategy pedagogy. Includes an interactive pedagogical user intake, dual-block deconstruction (XAML & ViewModel), generalized analytical tables, dedicated data loading feedback, and print-perfect PDF layout standards.
---

# MAUI Step Guide Author (Universal Block Strategy Pedagogy)

## Mission

Generate rich, engaging, step-by-step .NET MAUI learning guides and UI replications inspired by the world-class teaching style of **Leomaris Reyes** (Microsoft MVP, creator of AskXammy.com and Telerik .NET MAUI UI articles).

The goal is to demystify mobile development and MVVM architecture for high-school / K-12 students and developers. Instead of overwhelming learners with 300 lines of completed code in a single dump, every screen is deconstructed into:
1. **An Interactive Pedagogical Intake (תחקור משתמש מקדים)** that aligns on the guide scope and archetype.
2. **The Golden Path (שביל הזהב)** progressing logically from sketch to model, logic, view, service, and forms.
3. **The Dual-Block Strategy (פירוק כפול לבלוקים)** deconstructing BOTH the XAML View and the C# ViewModel into bite-sized, logical blocks.
4. **Generalized Analytical Tables (טבלאות ניתוח שכבתיות)** providing a clear mental map before every code layer.
5. **Dedicated Data Loading & Feedback (טעינת נתונים עם ActivityIndicator)** explaining state lifecycle and UX.
6. **Print-Perfect Layout Standards (תקן עימוד והדפסה ל-PDF)** guaranteeing zero clipped columns, zero orphaned headings, and zero blank pages.

All guides are authored in **Hebrew** with English code identifiers, following professional K-12 pedagogical standards.

---

## When to Use This Skill

Trigger this skill whenever:
1. A user asks to **create a guide or tutorial** for a screen, feature, or UI pattern (e.g., *"create a step-by-step guide for our login screen"*, *"how do I build this player view in MVVM?"*).
2. The `maui-k12-baton-workflow` reaches **Stage 6 (`CODE_LEARNING_REVIEWER`)** and compiles learning documentation for `Learning/MAUI-Learning-Book.md` or a dedicated screen guide.
3. A student or team needs an accessible, visual, block-by-block breakdown of a design, ViewModel logic, or XAML architecture.

---

## 🧭 שלב 0: תחקור פדגוגי מקדים והצעת מבנה (User Intake & Scaffolding)

**חוק ברזל:** לעולם אין לרוץ לכתיבת מדריך שלם מבלי לעצור תחילה לתחקור מקדים והסכמה על שלד המדריך מול המשתמש.

כאשר מופעלת המיומנות, הסוכן פותח בשיחת אפיון קצרה וממוקדת:

### 1. שאלות התחקור המנחות (Intake Questions)
- **מהות המסך והמטרה העסקית:** מהו המסך או התכונה שנבנה? (מסך תצוגה בודד? דפדוף פריטים? טופס הזנה? רשימה נגללת? לוח מחוונים?)
- **קהל היעד ושלב הלמידה:** מהי רמת התלמיד? (מתחיל מאפס הזקוק לבידוד משתנים מקסימלי? חוזר על MVVM? מתקדם?)
- **עומק השכבות בפרויקט (Architectural Depth):** האם נתחיל מנתונים מקומיים ב-ViewModel, נעבור לשכבת שירות מדומה (Mockup), או שנחבר ישר למסד נתונים (SQLite) / שירות ענן?
- **צרכי מצב ומשוב (State & Feedback):** האם יש פעולות א-סינכרוניות הדורשות חיווי טעינה (`ActivityIndicator`)? אילו פקודות דורשות הגנה ב-`CanExecute`?

### 2. הצעת חלופות מבנה מובילות (Guide Archetypes)
הסוכן יציג למשתמש 2-3 חלופות מבנה מותאמות לבחירה:

* **חלופה א' — "שביל הזהב המלא" (The Full 3-Phase Golden Path) [מומלץ למסכים עם לוגיקה עשירה]:**
  - חלק 1: מבוא, מטרת המדריך ופירוק הסקיצה (Wireframe).
  - שלב א': תצוגת פריט ודפדוף מקומי (ללא שירות חיצוני וללא טופס — בידוד מוחלט של Data Binding ו-Commands).
  - שלב ב': שכבת שירות (Interface & Mockup) וחלק מובנה לטעינת נתונים (`ActivityIndicator` ו-`IsLoading`).
  - שלב ג': טופס הזנה ועריכה בקישור דו-כיווני (`TwoWay Binding`, אימות קלט, פקודת שמירה).
  - נספח א': מדריך בדיקות יחידה (Unit Testing עם xUnit ותבנית AAA).
  - נספח ב': מקורות השראה ותיעוד רשמי.

* **חלופה ב' — "פירוק ממשק ממוקד" (Focused Single-Screen UI Deep-Dive) [מומלץ למסכי תצוגה מורכבים]:**
  - התמקדות בשלד הפריסה הוויזואלי: גרדיאנטים מקוריים, כרטיסים צפים (`Border` עם שוליים שליליים), תגיות וצללים.
  - חיבור ישיר ל-ViewModel מצב תצוגה פשוט.

* **חלופה ג' — "מסך רשימה ופרטים" (Dynamic Collection & Master-Detail) [מומלץ למסכי אוספים]:**
  - התמקדות ב-`ObservableCollection<T>`, פקד `CollectionView`, תבניות פריט (`DataTemplate`), חיפוש/סינון וניווט.

**עצירת המתנה:** הסוכן ממתין לאישור התלמיד על שלד המדריך הנבחר לפני תחילת הכתיבה!

---

## 🧱 עקרון הפירוק הכפול לבלוקים (The Universal Dual-Block Strategy)

חוק יסוד במדריכים: **שום קובץ אינו נכתב כגוש קוד ארוך**. הפירוק חל במקביל הן על ה-View והן על ה-ViewModel:

### א. תקן 6 הבלוקים הלוגיים של ה-ViewModel:
בכל שלב שבו מוצג או מורחב ViewModel, יש לפרקו לפי המבנה התקני:
1. **🧱 בלוק 1: שדות פרטיים (`Private Fields`):** משתני זיכרון פנימיים, שירותים מוזרקים (`_service`), אינדקסים ומשימות א-סינכרוניות (`private Task load;`).
2. **🧱 בלוק 2: מאפייני מצב פומביים (`Observable State Properties`):** נתונים הנחשפים למסך עם מימוש מלא של `get/set` וקריאה ל-`OnPropertyChanged()`.
3. **🧱 בלוק 3: הצהרת פקודות (`Command Declarations`):** מאפייני `ICommand` בלבד (לקריאה בלבד).
4. **🧱 בלוק 4: פעולה בונה ואתחול (`Constructor & Initialization`):** קבלת תלויות, יצירת מופעי הפקודות (`new Command(Execute, CanExecute)`), והתנעת טעינת נתונים ראשונית.
5. **🧱 בלוק 5: מתודות ביצוע ותנאי הגנה (`Execute & CanExecute Methods`):** הלוגיקה העסקית של כל פעולה, מלווה בתנאי `CanExecute` המונעים שגיאות וחריגות טווח.
6. **🧱 בלוק 6: סנכרון ורענון פקודות מרכזי (`Centralized RefreshCommands`):** מתודה פרטית אחת (למשל `RefreshCommands()`) המאגדת את כל קריאות ה-`((Command)Cmd).ChangeCanExecute()` ומסנכרנת את מצב הכפתורים במסך.

### ב. תקן 6 הבלוקים של ממשק המשתמש (XAML View):
1. **🧱 בלוק 1: ראש הדף, מרחבי שמות ו-Compiled Bindings:** הגדרת `xmlns:vm`, `x:DataType`, כותרת וכיווניות (`FlowDirection="RightToLeft"`). חובה להדגיש לתלמיד מה קבוע ומה עליו לעדכן לשמות הפרויקט שלו.
2. **🧱 בלוק 2: שלד הפריסה הראשי (Layout Backbone Grid):** הגדרת שורות ועמודות עם הסבר מנומק לכל שורה (`Auto`, קבוע, `*`) והערות מקום לבלוקים הבאים (`<!-- בלוק 1: ... -->`).
3. **🧱 בלוק 3: כרטיסיות ומסגרות עיצוביות (`Border & Containers`):** שימוש ב-`Border`, `StrokeShape="RoundRectangle"`, צבעי רקע וריפוד (`Padding`).
4. **🧱 בלוק 4: סרגלי ניווט ותצוגת תוכן:** גרידים פנימיים לכפתורים, תוויות טקסט עם `StringFormat*`, ועיצוב טיפוגרפי.
5. **🧱 בלוק 5: מנגנון חיווי ומשוב (ActivityIndicator):** מיקום אסטרטגי של גלגל הטעינה מעל הכרטיסיות.
6. **🧱 בלוק 6: שדות קלט וטפסים (Forms):** שימוש בפקדי `Entry` עם `Mode=TwoWay` וסוג מקלדת מותאם (`Keyboard="Numeric"`).

---

## 📊 תקן טבלאות הניתוח השכבתיות (Generalized Analytical Tables)

**חוק ברזל:** לפני הצגת קוד של שכבה מסוימת, יש לספק טבלת ניתוח מקדימה המשמשת כמפת דרכים מושגית לתלמיד:

1. **טבלת ניתוח ישות/מודל (Entity Table):**
   | שדה / תכונה | טיפוס נתונים | תפקיד עסקי ושימוש ב-UI / במסד נתונים | דוגמה מוחשית לערך |
   | :--- | :--- | :--- | :--- |

2. **טבלת מאפייני מצב ב-ViewModel (State Table):**
   | שם המאפיין | טיפוס | מתי הוא מתעדכן? | תוצאה ויזואלית במסך |
   | :--- | :--- | :--- | :--- |

3. **טבלת פקודות והגנות CanExecute (Commands Table):**
   | פקודה (`ICommand`) | פקד מפעיל ב-XAML | מתודת ביצוע (`Execute`) | תנאי הגנה (`CanExecute`) | מצב הכפתור כשהתנאי שקרי (`false`) |
   | :--- | :--- | :--- | :--- | :--- |

4. **טבלת מיפוי מסך מול לוגיקה (XAML-to-ViewModel Mapping Table):**
   | פקד ב-XAML | תכונה מקושרת | ביטוי Data Binding | כיוון קישור (`Binding Mode`) | תפקיד בממשק |
   | :--- | :--- | :--- | :--- | :--- |

5. **טבלת חוזה שירות (Service Contract Table):**
   | מתודה וחתימה בממשק | טיפוס מוחזר | פרמטרים | תפקיד ומשמעות עסקית | מדוע `Task` א-סינכרוני? |
   | :--- | :--- | :--- | :--- | :--- |

6. **טבלת ניהול משוב וטעינה (Feedback & Loading Table):**
   | רכיב / שלב במערכת | מיקום בקוד | תפקיד במנגנון הטעינה | תוצאה ויזואלית במסך |
   | :--- | :--- | :--- | :--- |

7. **טבלת שדות קלט ואימות טופס (Form Inputs Table):**
   | שדה קלט | טיפוס | פקד מקושר ב-XAML | כיוון קישור | סוג מקלדת ואימות | תפקיד עסקי |
   | :--- | :--- | :--- | :--- | :--- | :--- |

---

## ⏳ תקן מנגנון טעינת נתונים ומשוב (`ActivityIndicator` & `IsLoading`)

כאשר משלבים שכבת שירות או פעולות א-סינכרוניות, חובה להקדיש חלק מובנה ועצמאי לנושא טעינת נתונים לפני המעבר לטפסים:

1. **מהו הפקד `ActivityIndicator`:**
   - הסבר ההבדל בין מד התקדמות מוגדר באחוזים (`ProgressBar`) לבין אנימציית טעינה מעגלית באורך לא-ידוע מראש (Indeterminate Progress).
   - חשיבות בחוויית משתמש (Mobile UX): מניעת תחושה שהאפליקציה "קפאה" ומניעת לחיצות כפולות חוזרות (Spam Clicks).
2. **חובת הקישור הכפול (`IsRunning` + `IsVisible`):**
   - **מלכודת מתחילים קריטית:** הסבר מדוע אם מקשרים רק את `IsRunning="{Binding IsLoading}"`, בסיום הטעינה הגלגל יפסיק להסתובב **אך יישאר תקוע כעיגול קפוא על המסך ויגנוב שטח פריסה!**
   - הקישור הכפול מבטיח שהפקד גם מסתובב בזמן טעינה וגם נעלם לחלוטין ומפנה מקום בסיומה.
3. **המאפיין הנגזר `IsNotLoading`:**
   - הגדרה ב-`BaseViewModel`: `public bool IsNotLoading => !IsLoading;`
   - מניעת שימוש בממירי ערכים מסורבלים (`InvertedBoolConverter`) אצל תלמידים.
   - התרעה כפולה ב-setter של `IsLoading`: קריאה ל-`OnPropertyChanged()` עבור עצמו ועבור `IsNotLoading`.
4. **מחזור חיים מלא ומחייב (`try-catch-finally`):**
   - הרמת `IsLoading = true; RefreshCommands();` לפני הפנייה לשירות.
   - ביצוע הפעולה מול השירות בתוך `try`.
   - טיפול בחריגות ב-`catch`.
   - **חובת בלוק ה-`finally`:** הסבר מדוע כיבוי `IsLoading = false; RefreshCommands();` **חייב** להתבצע ב-`finally`, כדי ששגיאת שרת או רשת לא תשאיר את גלגל הטעינה מסתובב לנצח ואת המסך נעול!
5. **שילוב ב-`CanExecute`:**
   - שילוב `IsNotLoading` בכל תנאי פקודה רלוונטית למניעת לחיצות בזמן שהמערכת עסוקה.

---

## 🖨️ תקן עימוד, הדפסה ומניעת גלישות ב-PDF (The Print-Perfect Standard)

כל מדריך חייב להיות מוכן לקימפול מושלם ל-PDF (דרך תסריט `generate_book_pdf.py`):

1. **מניעת גלישת רוחב בטבלאות (Zero Horizontal Overflow):**
   - רוחב טבלאות מותאם: `padding: 6px 7px;` בתאי הטבלה (ולא 12px!).
   - גודל גופן טבלה מותאם: `font-size: 8.5pt` לתאים, ו-`7.5pt` לתגיות קוד בתוכם.
   - שבירת שורות רכה מובטחת לתגיות קוד בטבלאות: `table code { word-break: break-word; white-space: normal; }`.
2. **מניעת כותרות יתומות (Zero Orphaned Headings):**
   - כל הכותרות מ-`h1` ועד `h6` חייבות לכלול כללי הדפסה: `break-after: avoid; page-break-after: avoid;`.
3. **מניעת עמודים ריקים בקוד ארוך (Fluid Code Pagination):**
   - בבלוקי קוד ארוכים (`.code-block`), מוגדר `break-inside: auto; page-break-inside: auto;` כדי לאפשר זרימה טבעית לעמוד הבא ללא עמודים לבנים ריקים.
4. **מעברי עמוד יזומים (Intentional Page Breaks):**
   - שימוש ב-`<div style="page-break-before: always;"></div>` לפני שלבים מרכזיים הכוללים טבלה גדולה וקוד, כדי לשמור על שלמות הנושא בעמוד אחד.
5. **תקן שבירת שורות ב-XAML (Attribute-per-line):**
   - בכל תגית בעלת 2 תכונות ומעלה — יורדים שורה עבור כל תכונה עם הזחה תואמת.
6. **כלל `StringFormat*`:**
   - בכל שימוש ב-`StringFormat`, יש להוסיף סימון כוכבית (`*`) ובתחתית המסמך/פרק לקשר לתיעוד הרשמי: [Microsoft Learn - String formatting in .NET MAUI Data Binding](https://learn.microsoft.com/dotnet/maui/fundamentals/data-binding/string-formatting).
7. **שאלות הבנה ובדיקה עצמית בסוף כל שלב:**
   - בסיום כל פרק ושלב משולבת תיבת `> [!TIP]` הכוללת 2-3 שאלות הבנה רפלקטיביות המאתגרות את הבנת ה"למה" ולא רק ה"איך".
8. **איסור על תגיות HTML מורכבות ב-Markdown:**
   - אין להטמיע תגיות `<div>` גולמיות מוזחות מרובות שורות ב-Markdown המבלבלות את ה-Parser, אלא להשתמש בתמונות Mockup שצולמו מראש (`Learning/Images/...`).

---

## 📂 מבנה הקבצים התקני במערכת

* **מדריך המסך ב-Markdown:** `Learning/Guides/<ScreenName>-Guide.md`
* **הדמיית ממשק ב-HTML (אופציונלי ללכידת תמונות):** `Learning/Mockups/<ScreenName>.html`
* **תמונות בלוקים וסקיצות:** `Learning/Images/<ScreenName>-*.png`
* **ספר הלמידה המרכז:** `Learning/MAUI-Learning-Book.md`
* **תוצרי הדפסה מקומפלים:**
  - מדריך עצמאי: `Learning/<ScreenName>-Guide.pdf` ו-`Learning/<ScreenName>-Guide.html`
  - ספר למידה שלם: `Learning/MAUI-Learning-Book.pdf` ו-`Learning/MAUI-Learning-Book.html`
* **תסריטי קימפול:** `Scripts/Generate-Learning-Book-Pdf.py` ו-`Scripts/Generate-Learning-Book-Pdf.ps1`
