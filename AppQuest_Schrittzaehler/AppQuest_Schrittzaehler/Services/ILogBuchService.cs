namespace AppQuest_Schrittzaehler.Services
{
	public interface ILogBuchService
	{
		void OpenLogBuch(string task, string startStation, string endStation);
	}
}