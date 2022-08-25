using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smith_Lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void techniciansBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            try
            {
                this.techniciansBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.techSupportDataSet);
            }
            catch(DBConcurrencyException ex)
            {
                MessageBox.Show("A concurrency exception has occured. " +
                    "Some rows were not updated.", "Concurrency Exception.");
                this.techniciansTableAdapter.Fill(this.techSupportDataSet.Technicians);
            }
            catch(DataException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                techniciansBindingSource.CancelEdit();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Database error # " + ex.Number + ": " + ex.Message, ex.GetType().ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'techSupportDataSet.Technicians' table. You can move, or remove it, as needed.
            try
            {
                this.techniciansTableAdapter.Fill(this.techSupportDataSet.Technicians);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error # " + ex.Number +
                    ": " + ex.Message, ex.GetType().ToString());
            }
        }
    }
}
