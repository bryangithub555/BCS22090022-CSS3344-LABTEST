using BCS22090022.ViewModels;

namespace BCS22090022;

public partial class Question3 : ContentPage
{
	public Question3(Question3ViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}