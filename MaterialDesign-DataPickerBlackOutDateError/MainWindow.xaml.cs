// Author:  Andy Bond
// Date:    2/2/2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace MaterialDesign_DataPickerBlackOutDateError
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        private List<DateTime> list_of_lots_of_dates = new List<DateTime>();

        public MainWindow()
        {
            InitializeComponent();

            // In my application, these dates come from SQL, they are not generated this sloppily.. These are, however, the exact dates I am using in my app
            #region Create List of Valid Dates

            // Create List of Dates
            for (DateTime dt = new DateTime(2017, 1, 3); dt <= new DateTime(2017, 3, 30); dt = dt.AddDays(1))
            {
                if (dt.DayOfWeek != DayOfWeek.Saturday || dt.DayOfWeek != DayOfWeek.Sunday)
                {
                    list_of_lots_of_dates.Add(dt);
                }
            }

            for (DateTime dt = new DateTime(2017, 1, 8); dt <= new DateTime(2017, 2, 6); dt = dt.AddDays(1))
            {
                if (list_of_lots_of_dates.Contains(dt))
                {
                    list_of_lots_of_dates.Remove(dt);
                }
            }

            for (DateTime dt = new DateTime(2017, 3, 16); dt <= new DateTime(2017, 3, 28); dt = dt.AddDays(1))
            {
                if (list_of_lots_of_dates.Contains(dt))
                {
                    list_of_lots_of_dates.Remove(dt);
                }
            }

            list_of_lots_of_dates.Add(new DateTime(2017, 1, 7));
            list_of_lots_of_dates.Remove(new DateTime(2017, 2, 20));
            list_of_lots_of_dates.Remove(new DateTime(2017, 3, 9));
            list_of_lots_of_dates.Remove(new DateTime(2017, 3, 10));
            list_of_lots_of_dates.Remove(new DateTime(2017, 3, 13));

            list_of_lots_of_dates.Sort();

            #endregion

            // Set Up Date Picker
            DateTime first_date = list_of_lots_of_dates.First();
            DateTime last_date = list_of_lots_of_dates.Last();

            DatePicker_TEST.DisplayDateStart = first_date;
            DatePicker_TEST.DisplayDateEnd = last_date;

            for (DateTime date = first_date; date <= last_date; date = date.AddDays(1))
            {
                if (list_of_lots_of_dates.Exists(i => i.Date == date))
                {
                    if (DateTime.Today < date)
                    {
                        DatePicker_TEST.BlackoutDates.Add(new CalendarDateRange(date));
                    }
                }
                else
                {
                    DatePicker_TEST.BlackoutDates.Add(new CalendarDateRange(date));
                }
            }
        }
    }
}
