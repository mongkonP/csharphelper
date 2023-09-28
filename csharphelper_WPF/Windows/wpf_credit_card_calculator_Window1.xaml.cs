using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Globalization;

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for wpf_credit_card_calculator_Window1.xaml
    /// </summary>
    public partial class wpf_credit_card_calculator_Window1 : Window
    {
        public wpf_credit_card_calculator_Window1()
        {
            InitializeComponent();
        }

        // Calculate the payments.
        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            // Get the parameters.
            decimal balance = decimal.Parse(txtInitialBalance.Text, NumberStyles.Any);
            decimal interest_rate = decimal.Parse(txtInterestRate.Text.Replace("%", "")) / 100;
            decimal payment_percent = decimal.Parse(txtPaymentPercent.Text.Replace("%", "")) / 100;
            decimal min_payment = decimal.Parse(txtMinPayment.Text, NumberStyles.Any);
            interest_rate /= 12;

            lblTotalPayments.Content = null;
            decimal total_payments = 0;

            // Display the initial balance.
            lvwPayments.Items.Clear();
            PaymentData data = new PaymentData()
            {
                Period = "0",
                Payment = null,
                Interest = null,
                Balance = balance.ToString("c"),
            };
            lvwPayments.Items.Add(data);

            // Loop until balance == 0.
            for (int i = 1; balance > 0; i++)
            {
                // Calculate the payment.
                decimal payment = balance * payment_percent;
                if (payment < min_payment) payment = min_payment;

                // Calculate interest.
                decimal interest = balance * interest_rate;
                balance += interest;

                // See if we can pay off the balance.
                if (payment > balance) payment = balance;
                total_payments += payment;
                balance -= payment;

                // Display results.
                data = new PaymentData()
                {
                    Period = i.ToString(),
                    Payment = payment.ToString("c"),
                    Interest = interest.ToString("c"),
                    Balance = balance.ToString("c"),
                };
                lvwPayments.Items.Add(data);
            }

            // Display the total payments.
            lblTotalPayments.Content = total_payments.ToString("c");
        }
    }
}
