/// Homework No. 7 Lab No. 1
/// File Name : Program.cs
/// @author : Joshua Um
/// Date : Oct 6 2021
/// 
/// Problem Statement : Create a simple GUI that accepts a left hand value and a right hand value. Use a ListBox to have the user choose (+, -, *, /, %). Use try-catch blocks to handle bad input.  
/// Display a MessageBox notifying the user of the error.  Have a button that calculates the results.
/// 
/// Plan:
/// 1. Take input for a left hand value and right hand value, and an operation.
/// 2. User presses submit, enter submitButton_Click().
/// 3. Attempt to parse input string to a double, handle exception if input isn't valid.
/// 4. Determine type of operation using listbox selectedIndex.
/// 5. If index isn't valid, handle exception.
/// 6. Perform operation with 2 values and store result in final result textbox.
/// 7. Handle exception if dividing by zero.







using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HW7Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (double.TryParse(leftHandValueBox.Text, out double leftHandValue) && double.TryParse(rightHandValueBox.Text, out double rightHandValue))
                {
                    int operation = operationListBox.SelectedIndex;
                    Console.WriteLine(leftHandValue + " " + rightHandValue);
                
                    switch (operation)
                    {
                        case 0:

                            finalValueBox.Text =  (leftHandValue + rightHandValue).ToString();

                            break;
                        case 1:

                            finalValueBox.Text = (leftHandValue - rightHandValue).ToString();

                            break;
                        case 2:

                            finalValueBox.Text = (leftHandValue * rightHandValue).ToString();

                            break;
                        case 3:
                            if (rightHandValue == 0) throw new DivideByZeroException();
                                
                            try
                            {
                                finalValueBox.Text = (leftHandValue / rightHandValue).ToString();
                            }
                            catch (DivideByZeroException)
                            {
                                MessageBox.Show("Error: Cannot divide by zero.");
                            }
                            

                            break;
                        case 4:
                            finalValueBox.Text = (leftHandValue % rightHandValue).ToString();
                            break;
                        default:
                            MessageBox.Show("Error: Invalid operation given.");
                            break;
                    }




                }
                else
                {
                    throw new InvalidCastException();       
                }
            }
            catch(InvalidCastException)
            {
                
                MessageBox.Show("Error: Invalid Input.");
            }
        
           


        }
    }
}
