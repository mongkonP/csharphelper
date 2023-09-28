
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_raise_events

 { 

class BankAccount
    {
        // Raised if the program tries to debit more
        // than the account's balance.
        //public delegate void OverdrawnEventHandler(object sender, OverdrawnArgs args);
        //public event OverdrawnEventHandler Overdrawn;

        public event EventHandler<OverdrawnArgs> Overdrawn;

        // The account's current balance.
        public decimal Balance { get; set; }

        // Subtract from the account.
        public void Debit(decimal amount)
        {
            if (amount < 0) throw new
                ArgumentOutOfRangeException(
                    "Debit amount must be positive.");

            // See if the account holds this much money.
            if (Balance >= amount)
            {
                // There is enough money. Subtract the amount.
                Balance -= amount;
            }
            else
            {
                // There isn't enough money.
                // Raise the Overdrawn event.
                if (Overdrawn != null)
                {
                    // Make the OverdrawnArgs object.
                    OverdrawnArgs args = new OverdrawnArgs();
                    args.DebitAmount = amount;

                    // Raise the event.
                    Overdrawn(this, args);

                    // If the program wants to allow the account
                    // to have a negative balance, remove the money.
                    if (args.Allow) Balance -= amount;
                }
            }
        }

        // Add to the account.
        public void Credit(decimal amount)
        {
            if (amount < 0) throw new
                ArgumentOutOfRangeException(
                    "Credit amount must be positive.");
            Balance += amount;
        }
    }








    // Used to hold information when the account is overdrawn.
    class OverdrawnArgs : EventArgs
    {
        // The amount being subtracted.
        public decimal DebitAmount;

        // Default is to not allow the account
        // to have a negative balance.
        public bool Allow = false;
    }

}