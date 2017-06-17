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
        static ProjectAccess database;

        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

        public static ProjectAccess Database
        {
            get
            {
                if (database == null)
                {
                    database = new ProjectAccess(DependencyService.Get<ILocalFileHelper>().GetLocalFilePath("Project.db3"));
                }
                return database;
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
