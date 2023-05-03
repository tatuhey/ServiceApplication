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
using static System.Net.Mime.MediaTypeNames;

namespace ServiceApplication2
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

        //6.2	Create a global List<T> of type Drone called “FinishedList”. 
        List<Drone> FinishedList = new List<Drone>();

        //6.3	Create a global Queue<T> of type Drone called “RegularService”.
        Queue<Drone> RegularService = new Queue<Drone>();

        //6.4	Create a global Queue<T> of type Drone called “ExpressService”.
        Queue<Drone> ExpressService = new Queue<Drone>();

        #region methods
        //6.5	Create a button method called “AddNewItem” that will add a new service item to a Queue<> based on the priority.
        //Use TextBoxes for the Client Name, Drone Model, Service Problem and Service Cost. Use a numeric up/down control for the Service Tag.
        //The new service item will be added to the appropriate Queue based on the Priority radio button.
        private void AddNewItem()
        {
            try
            {
                string name = tbClientName.Text;
                string model = tbDroneModel.Text;
                string problem = tbServiceProblem.Text;
                double cost = double.Parse(tbServiceCost.Text);
                int tag = int.Parse(iuoServiceTag.Text);
                int priority = GetServicePriority();

                if (priority == 1)
                {
                    Drone newRegular = new Drone();
                    newRegular.setName(name);
                    newRegular.setModel(model);
                    newRegular.setProblem(problem);
                    newRegular.setCost(cost);
                    newRegular.setTag(tag);
                    RegularService.Enqueue(newRegular);
                }

                if (priority == 0)
                {
                    Drone newExpress = new Drone();
                    newExpress.setName(name);
                    newExpress.setModel(model);
                    newExpress.setProblem(problem);
                    newExpress.setCost(ExpressCost(cost));
                    newExpress.setTag(tag);
                    ExpressService.Enqueue(newExpress);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error when adding data to the queue.\n {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //6.6	Before a new service item is added to the Express Queue the service cost must be increased by 15%.
        private double ExpressCost(double cost)
        {
            double expCost = cost * 15 / 100;
            return expCost;
        }

        //6.7	Create a custom method called “GetServicePriority” which returns the value of the priority radio group.
        //This method must be called inside the “AddNewItem” method before the new service item is added to a queue.
        private int GetServicePriority()
        {
            //int value = -1;
            if (rbExpress.IsChecked == true)
                return 0;
            if (rbRegular.IsChecked == true)
                return 1;
            else return -1;
        }

        //6.8	Create a custom method that will display all the elements in the RegularService queue.
        //The display must use a List View and with appropriate column headers.
        private void DisplayRegular()
        {
            lvRegular.Items.Clear();
            lvRegular.ItemsSource = RegularService;
        }

        //6.9	Create a custom method that will display all the elements in the ExpressService queue.
        //The display must use a List View and with appropriate column headers.
        private void DisplayExpress()
        {
            lvExpress.Items.Clear();
            lvExpress.ItemsSource = ExpressService;
        }

        //6.10	Create a custom keypress method to ensure the Service Cost textbox can only accept a double value with one decimal point.
        private void tbServiceCost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //if (!char.IsDigit(e.Text, e.Text.Length - 1) && e.Text != "." || (e.Text == "." && ((TextBox)sender).Text.Contains(".")))
            //{
            //    e.Handled = true;
            //}

            TextBox textBox = (TextBox)sender;
            string text = textBox.Text.Insert(textBox.CaretIndex, e.Text);

            if (!char.IsDigit(e.Text, e.Text.Length - 1) && e.Text != "." || text.Count(c => c == '.') > 1)
            {
                e.Handled = true;
            }
        }

        //6.11	Create a custom method to increment the service tag control,
        //this method must be called inside the “AddNewItem” method before the new service item is added to a queue.
        #endregion

        //6.12	Create a mouse click method for the regular service ListView that will display the Client Name and Service Problem in the related textboxes.

        //6.13	Create a mouse click method for the express service ListView that will display the Client Name and Service Problem in the related textboxes.

        //6.14	Create a button click method that will remove a service item from the regular ListView and dequeue the regular service Queue<T> data structure.
        //The dequeued item must be added to the List<T> and displayed in the ListBox for finished service items.

        //6.15	Create a button click method that will remove a service item from the express ListView and dequeue the express service Queue<T> data structure.
        //The dequeued item must be added to the List<T> and displayed in the ListBox for finished service items.

        //6.16	Create a double mouse click method that will delete a service item from the finished listbox and remove the same item from the List<T>.

        //6.17	Create a custom method that will clear all the textboxes after each service item has been added.

        //6.18	All code is required to be adequately commented. Map the programming criteria and features to your code/methods
        //by adding comments above the method signatures. Ensure your code is compliant with the CITEMS coding standards (refer http://www.citems.com.au/).

    }
}
