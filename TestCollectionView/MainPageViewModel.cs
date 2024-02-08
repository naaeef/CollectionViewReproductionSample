using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestCollectionView;

public class MainPageViewModel : INotifyPropertyChanged
{
    public IList<object> Items { get; set; }

    private bool _isRefreshing;
    
    public bool IsRefreshing
    {
        get => _isRefreshing;
        set
        {
            _isRefreshing = value;
            OnPropertyChanged();
        }
    }
    
    public Command RefreshCommand { get; set; }

    public MainPageViewModel()
    {
        RefreshCommand = new Command(
            async () =>
            {
                await Task.Delay(2000);
                IsRefreshing = false;
            });
        
        Items = new List<object>();
        for (int i = 0; i < 100; i++) {
            Items.Add(new ItemA());
            Items.Add(new ItemB());
            Items.Add(new ItemB());
            Items.Add(new ItemB());
            Items.Add(new ItemB());
        }    
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class ItemA
{
    
}

public class ItemB
{
    
}