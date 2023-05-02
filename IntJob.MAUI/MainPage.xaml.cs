using IntJob.DataAccess.DbAccess;
using Microsoft.Extensions.Configuration;

namespace IntJob.Maui;

public partial class MainPage : ContentPage
{
	int count = 0;

    private DataStore<RateModel, RateData> _dataStore;

    public MainPage(
        DataStore<AgentModel, AgentData> agentDataStore,
        DataStore<HolidayModel, HolidayData> holidayDataStore,
        DataStore<IndustryModel, IndustryData> industryDataStore,
        DataStore<JobModel, JobData> jobDataStore,
        DataStore<RateModel, RateData> rateDateStore
    )
    {
        InitializeComponent();

        _dataStore = rateDateStore;
    }

    private async void OnCounterClicked(object sender, EventArgs e)
	{
        //var testItem = await _dataStore.Create(new RateModel
        //{
        //    AgentId = 1,
        //});
        //Console.WriteLine($"{testItem.Id}, {testItem.Name}");
        //testItem.Name = "New Name";
        ////testItem. = "2024-01-01";
        //testItem = await _dataStore.Update(testItem);
        //Console.WriteLine($"{testItem.Id}, {testItem.Name}");
        //var items = await _dataStore.List();
        //Console.WriteLine(items.Last().Name);
        ////Console.WriteLine(testItem.Date);

        await _dataStore.Delete(190);
        count++;

		if (count == 1)
            //CounterBtn.Text = $"Clicked {count} time {testItem.Name} {items.Count()}";
            CounterBtn.Text = $"Clicked {count} time";

        else
            CounterBtn.Text = $"Clicked {count}";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}


