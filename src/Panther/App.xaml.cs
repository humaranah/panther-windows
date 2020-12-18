using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Panther
{
    /// <summary>
    /// Provides application-specific behavior to complement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the Singleton application object. This is the first line of created code
        /// executed and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();
            Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is normally started by the end user. Other entry points
        /// will be used when the application starts to open a specific file, for example.
        /// </summary>
        /// <param name="e">Detailed information about the application and the initialization process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            // Do not repeat application initialization if the window still has content,
            // just make sure the window is active.
            if (!(Window.Current.Content is Frame rootFrame))
            {
                // Create a frame to act as a navigation context and navigate to the first page.
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load the state of the previously suspended application
                }

                // Put the frame in the current window.
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack is not restored, navigate to the first page,
                    // configuring the new page by passing it the required information
                    // as a navigation parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Make sure the current window is active.
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Invoked when the application is normally started by the end user. Other points will be used
        /// </summary>
        /// <param name="sender">Frame that produced the navigation error</param>
        /// <param name="e">Details about the navigation error</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when suspending execution of the application. The state of the application is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">Origin of the suspension request.</param>
        /// <param name="e">Details on the suspension request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop all background activity
            deferral.Complete();
        }
    }
}
