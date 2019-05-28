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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ExampleV6._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn = new SqlConnection("Data Source=S-217-TS;Initial Catalog=Example_DB;Integrated Security=True");
        bool removing = false;
        public MainWindow()
        {
            InitializeComponent();
            add("I", btnWrap.Children.Count);
            add("made", btnWrap.Children.Count);
            add("a", btnWrap.Children.Count);
            displayDataGrid();
        }
        public void txtBoxGen(int position)
        {   // generates(to btnWrap.Children) a textbox at a given position
            TextBox txtBox = new TextBox();
            txtBox.Height = 17;
            txtBox.Width = 50;
            txtBox.Name = "txtBox" + position;
            txtBox.Tag = "click to operate, click off to save";
            txtBox.LostFocus += txtBox_LostFocus;
            txtBox.Focus();

            btnWrap.Children.Insert(position, txtBox);
        }
        public void add(string word, int position)
        {   // generates(to btnWrap.Children) a button with a certain text at a certain position
            Button btn = new Button();
            List<char> filter = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ' ' };
            var query = from c in filter where word.Contains(c) select word;
            if(query.Count() > 0)
            {
                word = "error";
            }

            btn.Name = "word_" + position;
            btn.Content = word;
            btn.Click += word_Click;

            btn.Margin = new Thickness(2,0,0,0);
            btn.BorderThickness = new Thickness(0);
            btn.Background = Brushes.White;

            btn.ContextMenu = new ContextMenu();
            btn.ContextMenu.IsEnabled = true;
            btn.ContextMenu.Name = word;
                btnWrap.Children.Insert(position, btn);
        }
        private void displayDataGrid()
        {   // sets the context for the grid to the database view
            
            SqlDataAdapter adapter = new SqlDataAdapter("select DateSaved,JournalEntry from Journals", conn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            grid.DataContext = data.DefaultView;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            txtBoxGen(btnWrap.Children.Count);
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {   // toggles removemode
            if (!removing)
            {
                removing = true;
                (sender as Button).Background = Brushes.Red;
            }
            else
            {
                removing = false;
                (sender as Button).Background = Brushes.LightGray;
            }
        }
        private void Push_Click(object sender, RoutedEventArgs e)
        {   // adds journal to database and updates view
            if (btnWrap.Children.Count > 2)
            {
                string currentJournal = "";
                    foreach (Object b in btnWrap.Children)
                    {   // creates a journal string
                        if (b.GetType().Name == "Button")
                        {
                            currentJournal += (b as Button).Content.ToString();
                            if (!(btnWrap.Children.IndexOf((b as Button)) == btnWrap.Children.Count))
                                currentJournal += " ";
                        }
                    }
                    
                    try
                    {
                        if (conn.State == ConnectionState.Closed)
                            conn.Open();

                        DateTime currentDate = DateTime.Now;
                        string journalEntry = currentJournal;

                        string query = "insert into Journals values('" + currentDate + "','" + journalEntry + "')";
                        SqlCommand comm = new SqlCommand(query, conn);
                        int i = comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred for: " + ex.ToString());
                    }
                    finally
                    {
                        if (conn.State == ConnectionState.Open)
                            conn.Close();
                        btnWrap.Children.Clear();
                        displayDataGrid();
                    }
                }
        }
        private void Pull_Click(object sender, RoutedEventArgs e)
        {   // takes selected item from grid and puts it in text field
            if (grid.SelectedIndex != -1)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    btnWrap.Children.Clear();
                    DataRowView row = (DataRowView)grid.SelectedItem;
                    foreach (string s in row["JournalEntry"].ToString().Split(' '))
                    {
                            add(s, btnWrap.Children.Count);
                    }
                    string query = "delete from Journals where DateSaved = '" + row["DateSaved"] + "';";
                    SqlCommand comm = new SqlCommand(query, conn);
                    int i = comm.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred for: " + ex.ToString());
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();

                    displayDataGrid();
                }
            }
        }
        public void txtBox_LostFocus(object sender, EventArgs e)
        {   // when textbox loses focus create a button in its place
            add((sender as TextBox).Text.ToString(), btnWrap.Children.IndexOf((sender as TextBox)));
            btnWrap.Children.Remove((sender as TextBox));
        }
        public void word_Click(object sender, EventArgs e)
        {   // word operations
            if (removing)    // removing mode
            {
                btnWrap.Children.RemoveAt(btnWrap.Children.IndexOf(sender as Button));
            }
            else            // context menu display
            {
                MenuItem addItem = new MenuItem();
                MenuItem editItem = new MenuItem();
                (sender as Button).ContextMenu = new ContextMenu();
                (sender as Button).ContextMenu.IsEnabled = true;
                (sender as Button).ContextMenu.Name = (sender as Button).Content.ToString();

                editItem.Header = "Edit";
                editItem.Click += edit_Click;
                addItem.Header = "Add";
                addItem.Click += addBetween_Click;
                (sender as Button).ContextMenu.Items.Add(editItem);
                (sender as Button).ContextMenu.Items.Add(addItem);
                (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
                (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                (sender as Button).ContextMenu.IsOpen = true;
            }
        }
        public void edit_Click(object sender, EventArgs e)
        {   // removes the button from which this was called and replaces it with a textbox
            ContextMenu contMenu = (ContextMenu)(sender as MenuItem).Parent;
            foreach (object b in btnWrap.Children)
            {
                if ((b as Button).ContextMenu.Name == contMenu.Name)
                {
                    Button btn = (b as Button);
                    int i = btnWrap.Children.IndexOf(btn);
                    txtBoxGen(btnWrap.Children.IndexOf(btn));
                    (btnWrap.Children[i] as TextBox).Text = btn.Content.ToString();
                    btnWrap.Children.Remove(btn);
                    break;
                }
            }
        }
        public void addBetween_Click(object sender, EventArgs e)
        {   // adds a text box after the button this was called from
            ContextMenu contMenu = (ContextMenu)(sender as MenuItem).Parent;
            Button btn = new Button();
            foreach (object b in btnWrap.Children)
            {
                if ((b as Button).ContextMenu.Name == contMenu.Name)
                {
                    btn = (b as Button);
                    txtBoxGen(btnWrap.Children.IndexOf(btn) + 1);
                    break;
                }
            }
        }
    }
}
