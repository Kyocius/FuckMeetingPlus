using System;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using FuckMeetingPlus.Utils;
using Timer = System.Timers.Timer;

namespace FuckMeetingPlus;

public class MainViewModel : ObservableObject
{
    #region Properties

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

    #endregion

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
        StartCommand = new RelayCommand(StartFishTouching);
    }

    public ICommand SaveSettingsCommand { get; }

    private void SaveUserSettings()
    {
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

    public ICommand StartCommand { get; }

    private void StartFishTouching()
    {
        while (true)
        {
            CurrentTime = DateTime.Now.ToString("MM/dd/HH/mm");
            Thread.Sleep(10000);

            if (CurrentTime == Time)
            {
                MainLogic();
                break;
            }
        }
    }

    private string CurrentTime;

    /// <summary>
    /// 主逻辑函数
    /// </summary>
    private void MainLogic()
    {
        Process.Start(Path);
        Thread.Sleep(Convert.ToInt32(Waiting) * 1000);

        var intX1 = Convert.ToInt32(X1);
        var intY1 = Convert.ToInt32(Y1);
        NativeMethod.LeftMouseClick(intX1, intY1);
        Thread.Sleep(500);

        NativeMethod.KeyInput(MeetingId);
        Thread.Sleep(500);

        var intX2 = Convert.ToInt32(X2);
        var intY2 = Convert.ToInt32(Y2);
        NativeMethod.LeftMouseClick(intX2, intY2);
    }
}