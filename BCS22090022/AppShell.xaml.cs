namespace BCS22090022
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Question3), typeof(Question3));
            Routing.RegisterRoute(nameof(Question1), typeof(Question1));
        }
    }
}
