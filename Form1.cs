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
    public partial class Form1 : Form
    {
        private const string connectionString = "Data Source=54.227.219.32,1433;Initial Catalog=****;User ID=***;Password=******;";


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void PerformOperations(string storedprocedures, string successmessage)
        {
            if (ValidateInput())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(storedprocedures, connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@OwnerID", int.Parse(textBox1.Text)); // Assuming textBox1 is where you get the value
                            command.Parameters.AddWithValue("@FirstName", textBox2.Text);// Assuming textBox1 is where you get the value
                            command.Parameters.AddWithValue("@LastName", textBox3.Text);

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
        private void PerformDeleteOperation(string storedProcedure, string successMessage)
        {
            if (ValidateInput())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@OwnerID", int.Parse(textBox1.Text));

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
        private void PerformReadOperation(string storedProcedure)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    connection.Open();

                    using (SqlCommand command = new SqlCommand(storedProcedure, connection))
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
            PerformReadOperation("sp_GetOwners");
        }





        private void button1_Click(object sender, EventArgs e)
        {
            PerformOperations("sp_InsertOwner", "Owner added successfully!");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            PerformOperations("sp_UpdateOwner", "Owner updated successfully!");

        }
        private void button3_Click(object sender, EventArgs e)
        {
            PerformDeleteOperation("sp_DeleteOwner", "Owner deleted successfully!");

        }
        private void button8_Click(object sender, EventArgs e)
        {
            PerformReadOperation("sp_GetOwners");


        }


        private bool ValidateInput()
        {
            // Validate numeric inputs
            if (!int.TryParse(textBox1.Text, out _))
            {
                MessageBox.Show("Owner ID must be a numeric value.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Additional validation can be added based on specific requirements

            // If all validations pass, return true
            return true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       
    }

}



