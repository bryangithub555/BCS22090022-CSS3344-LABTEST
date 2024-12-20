namespace BCS22090022;

public partial class Question1 : ContentPage
{
	public Question1()
	{
		InitializeComponent();
        slider1.ValueChanged += (s, e) =>
        {
            label1.Text = e.NewValue.ToString("F0"); 
        };
    }

}