using Windows.ApplicationModel.Background;
using HouseOfCode.PushBoxSDK;
using HouseOfCode.PushBoxSDK.Helpers;

namespace PushBoxSDKExampleBackgroundTask
{
    public sealed class PushBackgroundTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            // Try to get PushBox message from task trigger
            var message = PushBoxSDKBackgroundTask.Instance.HandleBackgroundTaskTriggered(taskInstance);

            if (message != null)
            {
                // Show toast with PushBox message content
                ToastHelper.ShowToastNotification(message.Title, message.Message, "/");
            }
        }
    }
}