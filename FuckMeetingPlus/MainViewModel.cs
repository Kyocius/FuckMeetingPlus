using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace FuckMeetingPlus;

public class MainViewModel : ObservableObject
{
    private int x1;

    public int X1
    {
        get => x1;
        set => SetProperty(ref x1, value);
    }

    private int x2;

    public int X2
    {
        get => x2;
        set => SetProperty(ref x2, value);
    }

    public MainViewModel()
    {
        X1 = 3;
        X2 = 4;
    }
}