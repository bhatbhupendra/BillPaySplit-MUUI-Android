namespace BillPay
{
	public partial class MainPage : ContentPage
	{
		decimal bill;
		int tip;
		int noPersons = 1;

		public MainPage()
		{
			InitializeComponent();
		}

		private void txtBill_Completed(object sender, EventArgs e)
		{
			bill = decimal.Parse(txtBill.Text);
			CalculateTotal();
		}

		private void CalculateTotal()
		{
			//Total tip
			var totalTip = (bill * tip) / 100;
			//Tip by person
			var tipByPerson = (totalTip / noPersons);
			lblTipByPerson.Text =$"{tipByPerson:C}";
			//subtotal
			var subtotal = (bill / noPersons);
			lblSubtotal.Text = $"{subtotal:C}";
			//total
			var totalByPerson = (bill + totalTip) / noPersons;
			lblTotal.Text = $"{totalByPerson}";

		}

		private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			tip = (int)sldTip.Value;
			lblTip.Text = $"Tip:{tip}%";
			CalculateTotal();
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			if(sender is Button)
			{
				var btn = (Button)sender;
				var percnetage = int.Parse(btn.Text.Replace("%", ""));
				sldTip.Value = percnetage;
			}

		}

		private void btnMinus_Clicked(object sender, EventArgs e)
		{
			if(noPersons > 1)
			{
				noPersons--;
			}
			lblNoPerons.Text = noPersons.ToString();
			CalculateTotal();
		}

		private void btnPlus_Clicked(object sender, EventArgs e)
		{
			noPersons++;
			lblNoPerons.Text = noPersons.ToString();
			CalculateTotal() ;
		}
	}

}
