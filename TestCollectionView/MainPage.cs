using CommunityToolkit.Maui.Markup;

namespace TestCollectionView;

public class MainPage : ContentPage
{
    public MainPage()
    {
        BindingContext = new MainPageViewModel();
        
        Content = new Grid()
        {
            Children =
            {
                new RefreshView()
                {
                    Content = new CollectionView()
                    {
                        ItemSizingStrategy = ItemSizingStrategy.MeasureAllItems,
                        ItemTemplate = new TemplateSelector
                        {
                            ItemATemplate = new DataTemplate(() => new Grid()
                            {
                                BackgroundColor = Colors.Aqua,
                                HeightRequest = 20
                            }),
                            ItemBTemplate = new DataTemplate(() => new Grid()
                            {
                                BackgroundColor = Colors.Pink,
                                HeightRequest = 100
                            })
                        }
                    }
                    .Bind(ItemsView.ItemsSourceProperty, nameof(MainPageViewModel.Items))
                }
                .Bind(RefreshView.CommandProperty, nameof(MainPageViewModel.RefreshCommand))
                .Bind(RefreshView.IsRefreshingProperty, nameof(MainPageViewModel.IsRefreshing))
            }
        };
    }
}

public class TemplateSelector : DataTemplateSelector
{
    public DataTemplate ItemATemplate { get; set; }
    public DataTemplate ItemBTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        if (item is ItemA) {
            return ItemATemplate;
        }

        return ItemBTemplate;
    }
}