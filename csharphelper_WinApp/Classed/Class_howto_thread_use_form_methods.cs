
using csharphelper_WinApp.Forms_Cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

  namespace  howto_thread_use_form_methods

 { 

// This class's Run method displays a count in the Output window.

    class Counter
    {
        // The form that owns the Value variable.
        private howto_thread_use_form_methods_Form1 MyForm;

        // This counter's number.
        private int Number;

        // Define a delegate type for the form's DisplayValue method.
        private delegate void DisplayValueDelegateType(string txt);

        // Declare a delegate variable to point to the form's DisplayValue method.
        private DisplayValueDelegateType DisplayValueDelegate;

        public Counter(howto_thread_use_form_methods_Form1 form1, int number)
        {
            MyForm = form1;
            Number = number;

            // Initialize the delegate variable to point
            // to the form's DisplayValue method.
            DisplayValueDelegate = MyForm.DisplayValue;
        }

        // Count off seconds in the Output window.
        public void Run()
        {
            try
            {
                while (true)
                {
                    // Wait 1 second.
                    Thread.Sleep(1000);

                    // Lock the form object. This doesn't do anything
                    // to the form, it just means no other thread can
                    // lock the form object until we release the lock.
                    // That means a thread can update MyForm.Value
                    // and then display its value without interference.
                    lock (MyForm)
                    {
                        // Increment the form's Value.
                        MyForm.Value++;

                        // Display the value on the form.
                        // The call to InvokeRequired returns true
                        // if this code is not running on the same
                        // thread as the object MyForm. In this
                        // example, we know that is true so the call
                        // isn't necessary, but in other cases it
                        // might not be so clear.
                        if (MyForm.InvokeRequired)
                        {
                            // Make an array containing the parameters
                            // to pass to the method.
                            string[] args = new string[] { Number + ": " + MyForm.Value };

                            // Invoke the delegate.
                            MyForm.Invoke(DisplayValueDelegate, args);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // An unexpected error.
                Console.WriteLine("Unexpected error in thread " +
                    Number + "\r\n" + ex.Message);
            }
        }
    }

}