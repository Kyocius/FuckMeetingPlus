using System;
using System.Diagnostics;
using System.Threading;
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
    private string _waiting;
    private string _time;
    private string _meetingId;
    private string _x1;
    private string _x2;
    private string _y1;
    private string _y2;
    private string _missionText;
    private string _currentTime;
    private Timer _myTimer;

    public string Path
    {
        get => _path;
        set => SetProperty(ref _path, value);
    }

    public string Waiting
    {
        get => _waiting;
        set => SetProperty(ref _waiting, value);
    }

    public string Time
    {
        get => _time;
        set => SetProperty(ref _time, value);
    }


    public string MeetingId
    {
        get => _meetingId;
        set => SetProperty(ref _meetingId, value);
    }

    public string X1
    {
        get => _x1;
        set => SetProperty(ref _x1, value);
    }

    public string X2
    {
        get => _x2;
        set => SetProperty(ref _x2, value);
    }

    public string Y1
    {
        get => _y1;
        set => SetProperty(ref _y1, value);
    }

    public string Y2
    {
        get => _y2;
        set => SetProperty(ref _y2, value);
    }

    public string MissionText
    {
        get => _missionText;
        set => SetProperty(ref _missionText, value);
    }

    #endregion

    #region Commands

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
        _myTimer.Start();
        MissionText = "任务开始...";
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
        MissionText = "准备就绪";

        InitializeTimer();

        SaveSettingsCommand = new RelayCommand(SaveUserSettings);
        StartCommand = new RelayCommand(StartFishTouching);
    }

    /// <summary>
    /// 主逻辑函数，参数无用，仅用来匹配委托
    /// </summary>
    private void MainLogic(object sender, EventArgs e)
    {
        _currentTime = DateTime.Now.ToString("MM/dd/HH/mm");

        if (_currentTime == Time)
        {
            try
            {
                Process.Start(Path);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

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

            MissionText = "任务完成";

            _myTimer.Enabled = false;
            _myTimer.Stop();
        }
    }

    /// <summary>
    /// 初始化Timer
    /// </summary>
    private void InitializeTimer()
    {
        _myTimer = new Timer();
        _myTimer.Interval = 30000; //注意间隔时间为30秒
        _myTimer.Enabled = false;
        _myTimer.Elapsed += MainLogic;
    }
}