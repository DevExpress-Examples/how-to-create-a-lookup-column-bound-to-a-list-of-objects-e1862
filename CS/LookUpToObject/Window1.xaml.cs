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
using System.Collections.ObjectModel;
using DevExpress.Xpf.Editors.Settings;

namespace LookUpToObject {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();

            Person JohnDoe = new Person() { FirstName = "John", LastName = "Doe" };
            Person JohnSmith = new Person() { FirstName = "John", LastName = "Smith" };
            ObservableCollection<Person> colPersons = new ObservableCollection<Person>();
            colPersons.Add(JohnDoe);
            colPersons.Add(JohnSmith);
            ((ComboBoxEditSettings)gridControl1.Columns["Owner"].EditSettings).ItemsSource = colPersons;

            ObservableCollection<Task> colTasks = new ObservableCollection<Task>();
            colTasks.Add(new Task() { TaskID = 1, Owner = JohnDoe });
            colTasks.Add(new Task() { TaskID = 2, Owner = JohnDoe });

            gridControl1.DataSource = colTasks;
        }
    }

    public class Task {
        public Task() { }
        public int TaskID { get; set; }
        public Person Owner { get; set; }
    }

    public class Person {
        public Person() { }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString() {
            return String.Format("{0} {1}", FirstName, LastName);
        }
    }
}
