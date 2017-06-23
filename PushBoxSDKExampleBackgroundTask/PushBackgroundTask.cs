using Windows.ApplicationModel.Background;
using HouseOfCode.PushBoxSDK;
using HouseOfCode.PushBoxSDK.Helpers;
using System;

namespace PushBoxSDKExampleBackgroundTask
{
    public sealed class PushBackgroundTask : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            // Important: Get deferral to enable running async functions
            // when triggered.

            var deferral = taskInstance.GetDeferral();
            // Try to get PushBox message from task trigger
            try
            {
                // Important: await HandleBackgroundTaskTriggered to allow sdk work
                var message = await PushBoxSDKBackgroundTask.Instance.HandleBackgroundTaskTriggered(taskInstance);

                if (message != null)
                {
                    // Show toast with PushBox message content
                    ToastHelper.ShowToastNotification(message.Title, message.Message, "/");
                }
            } catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Error handling push in background task, {e.Message}");
            }
        }
    }
}