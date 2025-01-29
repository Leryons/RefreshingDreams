namespace RefreshingDreams
{
    public partial class App : Application
    {
        private readonly CocktailServices _cocktailServices;
        public App(CocktailServices cocktailServices)
        {
            InitializeComponent();
            _cocktailServices = cocktailServices;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

        protected override void OnStart()
        {
            base.OnStart();
            _cocktailServices.GetCocktails();
            
        }
    }
}