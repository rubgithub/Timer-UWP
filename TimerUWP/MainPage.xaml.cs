using System;
using System.Diagnostics;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Background;

namespace TimerUWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            RegisterTask();
        }

        private void RegisterTask()
        {
            //create a task/timer to run each 15 minutes (minimum allowed 15min)
            var builder = new BackgroundTaskBuilder
            {
                Name = "My Background TimerTrigger"
            };
            builder.SetTrigger(new TimeTrigger(15, false));
            builder.Register();
            Debug.WriteLine($"RegisterTask {DateTime.Now}");
        }
    }

    sealed partial class App 
    {
        protected override void OnBackgroundActivated(BackgroundActivatedEventArgs args)
        {
            //Can be fired more than once per trigger, check it out.
            Debug.WriteLine($"OnBackgroundActivated - {DateTime.Now}");
        }
    }
}
