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

namespace CRUD_OPERATION
{
    public partial class Form2 : Form
    {
        private const string connectionString = "Data Source=54.227.219.32,1433;Initial Catalog=MarineAdventuresDB;User ID=sa;Password=Kanamujo56$;";

        public Form2()
        {
            InitializeComponent();
        }
        private void InsertOperations(string storedprocedures_2, string successmessage)
        {
            if (ValidateInput())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(storedprocedures_2, connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@CustomerID", int.Parse(textBox1.Text)); // Assuming textBox1 is where you get the value
                            command.Parameters.AddWithValue("@FirstName", textBox4.Text);// Assuming textBox1 is where you get the value
                            command.Parameters.AddWithValue("@LastName", textBox3.Text);
                            command.Parameters.AddWithValue("@Address", textBox2.Text);
                            command.Parameters.AddWithValue("@UnpaidBalance", int.Parse(textBox5.Text));




                            command.ExecuteNonQuery();
                            MessageBox.Show("Owner added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshDataGridView();


                        }

                    }
                    catch (Exception ex)
                    {
                        // Handle the exception (e.g., display an error message)
                        MessageBox.Show($"Error retrieving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }

                }
            }
        }
        private void DeleteOperation(string storedProcedure_2, string successMessage)
        {
            if (ValidateInput())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(storedProcedure_2, connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));

                            command.ExecuteNonQuery();
                            MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshDataGridView();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error retrieving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }
        private void ReadOperation(string storedProcedure2)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    connection.Open();

                    using (SqlCommand command = new SqlCommand(storedProcedure2, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);

                            dataGridView1.DataSource = dataTable;
                        }

                        MessageBox.Show("Data retrieved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void RefreshDataGridView()
        {
            ReadOperation("SearchCustomer");
        }

        private bool ValidateInput()
        {
            // Validate numeric inputs
            if (!int.TryParse(textBox1.Text, out _))
            {
                MessageBox.Show("Customer ID must be a numeric value.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Additional validation can be added based on specific requirements

            // If all validations pass, return true
            return true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertOperations("InsertCustomer", "Customer added successfully!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertOperations("UpdateCustomer", "Customer updated successfully!");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteOperation("sp_DeleteOwner", "Owner deleted successfully!");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReadOperation("SearchCustomer");

        }
    }
}
