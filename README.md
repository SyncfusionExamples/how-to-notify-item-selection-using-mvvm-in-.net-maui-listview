# How to notify item selection using MVVM in .NET MAUI ListView (SfListView)?

The [.NET MAUI ListView](https://www.syncfusion.com/maui-controls/maui-listview) allows you to determine whether an item is selected by maintaining a boolean property in the model class. The property value is updated using selection events such as [SelectionChanging](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.ListView.SfListView.html#Syncfusion_Maui_ListView_SfListView_SelectionChanging), [SelectionChanged](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.ListView.SfListView.html#Syncfusion_Maui_ListView_SfListView_SelectionChanged).

**XAML:**
```
<ContentPage xmlns:listView="clr-namespace:Syncfusion.Maui.ListView;assembly=Syncfusion.Maui.ListView">
    <ContentPage.BindingContext>
        <local:ContactsViewModel x:Name="ViewModel"/>
    </ContentPage.BindingContext>
    <ContentPage.Resources>
        <ResourceDictionary>
            <local:CustomConverter x:Key="EventArgs" />
        </ResourceDictionary>
    </ContentPage.Resources>
    <ContentPage.Content>
        <Grid>
            <listView:SfListView x:Name="listView" 
                           ItemsSource="{Binding Items}" >
                <listView:SfListView.Behaviors>
                    <local:EventToCommandBehavior EventName="SelectionChanged" 
                                        Command="{Binding SelectionChangedCommand}"
                                        Converter="{StaticResource EventArgs}" />
                </listView:SfListView.Behaviors>

                <listView:SfListView.ItemTemplate>
                    <DataTemplate>
                        <Grid>
                            <Label Text="{Binding ContactName}" FontSize="Medium" />                          
                        </Grid>
                    </DataTemplate>
                </listView:SfListView.ItemTemplate>
            </listView:SfListView>
        </Grid>
    </ContentPage.Content>
</ContentPage>
```

**C#:**

```
namespace ListViewMaui
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        public Command<object> SelectionChangedCommand
        {
            get { return selectionChangedCommand; }
            protected set { selectionChangedCommand = value; }
        }


        public ContactsViewModel()
        {
            selectionChangedCommand = new Command<object>(OnSelectionChanged);
            Items = new ObservableCollection<Contacts>();
        }


        public void OnSelectionChanged(object obj)
        {
            var eventArgs = obj as ItemSelectionChangedEventArgs;

            for (int i = 0; i < eventArgs.RemovedItems.Count; i++)
            {
                var item = eventArgs.RemovedItems[i] as Contacts;
                if (item.IsSelected)
                {
                    item.IsSelected = false;
                    App.Current.MainPage.DisplayAlert("Message", "Item removed from selected item", "ok");
                }
            }
            for (int i = 0; i < eventArgs.AddedItems.Count; i++)
            {
                var item = eventArgs.AddedItems[i] as Contacts;
                if (!item.IsSelected)
                {
                    item.IsSelected = true;
                    App.Current.MainPage.DisplayAlert("Message", "Item added into selected item", "ok");
                }
            }
        }
    }
}
```

**Output:**
 
 ![RemovedFromSelectedItem.PNG](https://support.syncfusion.com/kb/attachment/article/14859/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjE2NjM4Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.JJI5LvAlcPQmLnmzWT23SCWwMK0t6GNiftUtMUe6px4)

 
 ![AddedSelectedItem.PNG](https://support.syncfusion.com/kb/attachment/article/14859/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjE2NjM5Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.XaZYbJQCqZFzdIXqvp0WsK28kUtR6-Yz2k0osxGmUFU)


**Conclusion**

I hope you enjoyed learning how to notify item selection using MVVM in the .NET MAUI ListView.

You can refer to our [.NET MAUI ListView feature tour](https://www.syncfusion.com/maui-controls/maui-listview) page to know about its other groundbreaking feature representations and [documentation](https://help.syncfusion.com/maui/listview/getting-started), and how to quickly get started with configuration specifications. Explore our [.NET MAUI ListView example](https://github.com/syncfusion/maui-demos/tree/master/MAUI/ListView) to understand how to create and manipulate data.

You can check out our components from the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page for current customers. If you are new to Syncfusion®, try our 30-day [free trial](https://www.syncfusion.com/downloads/maui/confirm) to check out our other controls.

Please let us know in the comments section if you have any queries or require clarification. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/create), or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sflistview). We are always happy to assist you!
