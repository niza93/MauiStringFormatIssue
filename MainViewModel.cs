using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiStringFormatIssue.ViewModels
{
  public class MainViewModel : INotifyPropertyChanged
  {
    private float mFloatValue;

    public float FloatValue
    {
      get => mFloatValue;
      set => Set(ref mFloatValue, value);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
      if (!Equals(field, value))
      {
        field = value;
        RaisePropertyChanged(propertyName);
        return true;
      }
      return false;
    }
  }
}
