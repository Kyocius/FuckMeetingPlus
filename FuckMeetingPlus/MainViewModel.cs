using System;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;


namespace FuckMeetingPlus;

public class MainViewModel : ObservableObject
{
    private string _path;

    public string Path
    {
        get => _path;
        set => SetProperty(ref _path, value);
    }

    private string _waiting;

    public string Waiting
    {
        get => _waiting;
        set => SetProperty(ref _waiting, value);
    }

    private string _time;

    public string Time
    {
        get => _time;
        set => SetProperty(ref _time, value);
    }

    private string _meetingId;

    public string MeetingId
    {
        get => _meetingId;
        set => SetProperty(ref _meetingId, value);
    }

    private string _x1;

    public string X1
    {
        get => _x1;
        set => SetProperty(ref _x1, value);
    }

    private string _x2;

    public string X2
    {
        get => _x2;
        set => SetProperty(ref _x2, value);
    }

    private string _y1;

    public string Y1
    {
        get => _y1;
        set => SetProperty(ref _y1, value);
    }

    private string _y2;

    public string Y2
    {
        get => _y2;
        set => SetProperty(ref _y2, value);
    }

    public MainViewModel()
    {
        Path = UserSettings.Default.Path;
        Time = UserSettings.Default.Time;
        MeetingId = UserSettings.Default.MeetingId;
        Waiting = UserSettings.Default.Waiting;
        X1 = UserSettings.Default.X1;
        Y1 = UserSettings.Default.Y1;
        X2 = UserSettings.Default.X2;
        Y2 = UserSettings.Default.Y2;
        SaveSettingsCommand = new RelayCommand(SaveUserSettings);
    }

    public ICommand SaveSettingsCommand { get; }
    private void SaveUserSettings()
    {
        //if (string.IsNullOrEmpty(Path))
        //    UserSettings.Default.Path = "Empty";
        //if (string.IsNullOrEmpty(Time))
        //    UserSettings.Default.Time = "0";
        //if (string.IsNullOrEmpty(MeetingId))
        //    UserSettings.Default.MeetingId = "0";
        //if (string.IsNullOrEmpty(Waiting))
        //    UserSettings.Default.Waiting = "0";
        //if (string.IsNullOrEmpty(X1))
        //    UserSettings.Default.X1 = "0";
        //if (string.IsNullOrEmpty(Y1))
        //    UserSettings.Default.Y1 = "0";
        //if (string.IsNullOrEmpty(X2))
        //    UserSettings.Default.X2 = "0";
        //if (string.IsNullOrEmpty(Y2))
        //    UserSettings.Default.Y2 = "0";

        UserSettings.Default.Path = Path;
        UserSettings.Default.MeetingId = MeetingId;
        UserSettings.Default.Time = Time;
        UserSettings.Default.Waiting = Waiting;
        UserSettings.Default.X1 = X1;
        UserSettings.Default.Y1 = Y1;
        UserSettings.Default.X2 = X2;
        UserSettings.Default.Y2 = Y2;

        UserSettings.Default.Save();
    }
}