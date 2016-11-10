using System;

namespace AppQuest_Schrittzaehler.Services
{
    public class StepEventArgs : EventArgs
    {
        public int Step { get; set; }
    }

    public delegate void StatusUpdateHandler(object sender, StepEventArgs e);

    public interface IStepCounterService
	{
	    void Listen();
	    void Pause();

        event StatusUpdateHandler OnStep;
    }
}
