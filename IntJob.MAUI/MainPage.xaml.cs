using IntJob.DataAccess.DbAccess;
using Microsoft.Extensions.Configuration;

namespace IntJob.Maui;

public partial class MainPage : ContentPage
{
	int count = 0;

    private DataStore _dataStore;

    public MainPage(DataStore dataStore)
    {
        InitializeComponent();

        _dataStore = dataStore;
    }

    private async void OnCounterClicked(object sender, EventArgs e)
	{
        var testItem = await _dataStore.DeleteHoliday(36);
        //testItem.Name = "New Name";
        //testItem.Date = "2024-01-01";
        //testItem = await _dataStore.UpdateHoliday(testItem);
        //var items = await _dataStore.ListHolidays();
        //Console.WriteLine(items.First().Date);
        //Console.WriteLine(testItem.Date);
        count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time {testItem}";
		else
			CounterBtn.Text = $"Clicked {count}";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}


