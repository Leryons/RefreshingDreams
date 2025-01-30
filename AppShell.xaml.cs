namespace RefreshingDreams
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(MenuPage), typeof(MenuPage));
            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
        }
    }
}
