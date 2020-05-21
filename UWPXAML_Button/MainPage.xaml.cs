using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;

// A demo app showing some options around setting the UI Automation Name property
// of a UWP XAML Button.

namespace UWPXAML_Button
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // Button #2.
            // Build up the UIA Name property from the contents of the Button.
            // Add a comma to have a screen reader pause slightly at that point.
            // This assumes the fixed order of the text is acceptable worldwide.
            AutomationProperties.SetName(SetFavouriteAPI2Button,
                SetFavouriteAPI2.Text + ", " + CurrentFavourite2.Text);
        }
    }


     // Button #3.
    // A custom Button will uses its very own custom AutomationPeer to 
    // return a UIA Name built up from the contents of the Button.
    public class MyButton : Button
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new MyButtonAutomationPeer(this);
        }
    }

    public class MyButtonAutomationPeer : ButtonAutomationPeer
    {
        public MyButtonAutomationPeer(MyButton owner) :
            base(owner)
        {
        }

        protected override string GetNameCore()
        {
            var loader = new ResourceLoader();

            return loader.GetString("SetFavouriteAPI") + ", " +
                loader.GetString("CurrentFavourite");
        }
    }
}
