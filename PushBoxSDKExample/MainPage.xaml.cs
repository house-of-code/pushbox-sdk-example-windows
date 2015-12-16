using System;
using System.Diagnostics;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using HouseOfCode.PushBoxSDK;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace PushBoxSDKExample
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            NavigationCacheMode = NavigationCacheMode.Required;

            var pushBoxSdk = PushBoxSDK.Instance;

            // Register push event handler for when app is in foreground
            pushBoxSdk.OnPush += InstanceOnOnPush;

//            pushBoxSdk.OnMessagesReceived += InstanceOnOnMessagesReceived;
//            pushBoxSdk.GetMessages();
//
//            pushBoxSdk.SetGender(Gender.Female);
//
//            pushBoxSdk.SetChannels(new List<string>() {  "channel1", "channel2", "channel3", "channel4" });
        }

        private void InstanceOnOnMessagesReceived(object sender, OnMessagesReceivedEventArgs onMessagesReceivedEventArgs)
        {
            var messages = onMessagesReceivedEventArgs.Messages;

            Debug.WriteLine($"Got {messages.Count} message(s)");

            foreach (var message in messages)
            {
                Debug.WriteLine(message.Title);
            }
        }

        private async void InstanceOnOnPush(object sender, OnPushEventArgs onPushEventArgs)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                var dialog = new MessageDialog(onPushEventArgs.Message.ToString(), onPushEventArgs.Message.Message);
                await dialog.ShowAsync();
            });
        }

        /// <summary>
        ///     Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">
        ///     Event data that describes how this page was reached.
        ///     This parameter is typically used to configure the page.
        /// </param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }
    }
}