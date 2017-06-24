using ArduinoController.Database;
using ArduinoController.Database.Access;
using ArduinoController.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ArduinoController
{
    public partial class App : Application
    {
        static ProjectAccess projectDatabase;
        static WiFiSettingsAccess wifiSettingsDatabase;

        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

        public static ProjectAccess ProjectDatabase
        {
            get
            {
                if (projectDatabase == null)
                {
                    projectDatabase = new ProjectAccess(DependencyService.Get<ILocalFileHelper>().GetLocalFilePath("Project.db3"));
                }
                return projectDatabase;
            }
        }

        public static WiFiSettingsAccess WiFiSettingsDatabase
        {
            get
            {
                if (wifiSettingsDatabase == null)
                {
                    wifiSettingsDatabase = new WiFiSettingsAccess(DependencyService.Get<ILocalFileHelper>().GetLocalFilePath("WiFiSettings.db3"));
                }
                return wifiSettingsDatabase;
            }
        }

        public static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ProjectsPage())
                    {
                        Title = "Projects",
                        Icon = Device.OnPlatform("tab_feed.png",null,null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "Settings",
                        Icon = Device.OnPlatform("tab_about.png",null,null)
                    },
                }
            };
        }
    }
}
