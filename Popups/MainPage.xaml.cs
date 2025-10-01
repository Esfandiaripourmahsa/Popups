
namespace Popups
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }



        private Random rnd = new Random(); 
        private Color GetRandomColor()
        {
            return Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        private async void OnAdd_Clicked(object sender, EventArgs e)
        {
            string name = await DisplayPromptAsync("Toevoegen", "Naam: ");

            if (!string.IsNullOrWhiteSpace(name)) {

                Button button = new Button();
                button.Text = name;
                button.BackgroundColor = GetRandomColor();
                button.Clicked += OnName_Clicked;

                flex.Children.Add(button);

            }

           
        }

        private async void OnName_Clicked(object? sender, EventArgs e)
        {
            // Button button = sender as Button;
            // if (button != null) { }

            if (sender is Button button)
            {
                //button.BackgroundColor = GetRandomColor();

                string name = button.Text;
                bool answer = await DisplayAlert("Verwijderen?", $"Bent u zeker dat u {name} wil verwijderen?", "Yes", "No");
                if (answer ==true)
                {
                    flex.Children.Remove(button);
                }

            }
             
            

        }

        
    }

}
