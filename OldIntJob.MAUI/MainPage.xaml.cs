using IntJob.DataAccess.DbAccess;
using Microsoft.Extensions.Configuration;

namespace IntJob.MAUI;

public partial class MainPage : ContentPage
{
	int count = 0;

	private AgentData _data;

	public MainPage(IConfiguration config)
	{
		InitializeComponent();

		_data = new AgentData(new SqliteDataAccess(config));
			//MauiProgram.Service.GetService<IConfiguration>()));
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		var agent = await GetAgent(1);


		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times {agent.Name}";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

	private async Task<AgentModel> GetAgent(int id)
	{
		
		try
		{
			return await _data.GetAgent(id);
		}
		catch (Exception ex)
		{
			
			return null;
		}
	}
}


