using NUnit.Framework;
using System;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace MobileDev.Android
{
    // Tests are run through NUnit.
    [TestFixture()]
    public class SimpleTest
    {
        IApp app;

        /* The SetUp attribute will mark the method to run before every 
         * Test method. A TearDown method can also be added to run 
         * after a Test method regardless of it passing or failing. */
        [SetUp]
        public void Setup()
        {
            /* You'll need an ApiKey to run on emulators for more than 15 min 
            or on any physical device */
            app = ConfigureApp
                .Android
                .ApkFile(Constants.ApkPath)
                .ApiKey(Constants.ApiKey)
                .StartApp();
        }

        /* The Test attribute marks a method to be tested. A TestCase
         * attribute can be added to run a Test method with varying parameters*/
        [Test()]
        public void FindingUs()
        {
            app.Screenshot("App is open");
            /* The Intial method is a custom written extension method. 
             * You can find the method in Extension.cs. Try your own!*/
            app.Initial();

            app.Tap(x => x.Text("Exhibitors"));
            // WaitFor's are assertions. Use them to line up screenshots too!
            app.WaitForElement(x => x.Text("Exhibitors by Name"));
            app.Screenshot("Exhibitors search open");

            app.Tap(x => x.Text("Exhibitors by Name"));
            app.WaitForElement(x => x.Id("cc_event_guide_list_bookmark"));
            app.Screenshot("List of company names open");

            for (int i = 0; i < 2; i++)
            {
                app.ScrollDown();
                if ((app.Query(x => x.Marked("Xamarin"))).Length > 0)
                {
                    break;
                }
            }
            app.Screenshot("Scrolled thrice for the Xamarin name");

            /* Marked is a nice shortcut and will look for matching 
            text in the Id, Text, or Label attributes */
            app.Tap(x => x.Marked("Search"));
            /* Intellisence will show you different options! The EnterText method
             * can select then type or type into an already selected field. */
            app.EnterText(x => x.Id("search_bar"), "Xamarin");
            app.PressEnter();
            app.Screenshot("Searching for Xamarin with the search bar");

            app.Tap(x => x.Id("list_item_title").Text("Xamarin"));
            app.WaitForElement(x => x.Text("Xamarin"));
            // Screenshots are only taken on the cloud and are paired with the text you insert here.
            app.Screenshot("Xamarin page");
        }
    }
}

