using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TekstilMagazasiDB
{
    public partial class Magaza : Form
    {
        public Magaza()
        {
            InitializeComponent();
        }

        NpgsqlConnection connect = new NpgsqlConnection("server = localHost; port = 5432; Database = ProductDb; user ID = postgres; password = dbproject");

        private void Form1_Load(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("select * from category", connect);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            categoryComboBox.DisplayMember = "category_name";
            categoryComboBox.ValueMember = "category_id";
            categoryComboBox.DataSource = dataTable;
            connect.Close();
            connect.Open();
            NpgsqlDataAdapter adapter2 = new NpgsqlDataAdapter("select * from personnel_type", connect);
            DataTable dataTable2 = new DataTable();
            adapter2.Fill(dataTable2);
            comboBox1.DisplayMember = "personnel_type_name";
            comboBox1.ValueMember = "personnel_type_id";
            comboBox1.DataSource = dataTable2;
            connect.Close();
        }


        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listButton_Click_1(object sender, EventArgs e)
        {
            string query = "select * from category";
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connect);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            connect.Close();
        }

        private void addButton_Click_1(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command = new NpgsqlCommand("insert into category(category_id, category_name) values (@p1, @p2)", connect);
            command.Parameters.AddWithValue("@p1", int.Parse(categoryIdTextBox.Text));
            command.Parameters.AddWithValue("@p2", categoryNameTextBox.Text);
            command.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Kategori ekleme başarılı.");
        }

        private void deleteButton_Click_1(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command = new NpgsqlCommand("delete from category where category_id=@p1", connect);
            command.Parameters.AddWithValue("@p1", int.Parse(categoryIdTextBox.Text));
            command.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Kategori silme işlemi başarılı.");
        }

        private void addButton_Click_2(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command = new NpgsqlCommand("insert into product(product_id, product_name, stock, price, category) values (@p1, @p2, @p3, @p4, @p5)", connect);
            command.Parameters.AddWithValue("@p1", int.Parse(ProductIdTextBox.Text));
            command.Parameters.AddWithValue("@p2", ProductNameTextBox.Text);
            command.Parameters.AddWithValue("@p3", int.Parse(stockTextBox.Text));
            command.Parameters.AddWithValue("@p4", double.Parse(priceTextBox.Text));
            command.Parameters.AddWithValue("@p5", int.Parse(categoryComboBox.SelectedValue.ToString()));
            command.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Ürün ekleme başarılı.");
        }

        private void listButton2_Click(object sender, EventArgs e)
        {
            string query = "select * from product";
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connect);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
            connect.Close();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click2(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command = new NpgsqlCommand("delete from product where product_id=@p1", connect);
            command.Parameters.AddWithValue("@p1", int.Parse(ProductIdTextBox.Text));
            command.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Ürün silme işlemi başarılı.");
        }

        private void updateButton2_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command = new NpgsqlCommand("update product set product_name=@p1, stock=@p2, price = @p3 where product_id = @p4", connect);
            command.Parameters.AddWithValue("@p1", ProductNameTextBox.Text);
            command.Parameters.AddWithValue("@p2", int.Parse(stockTextBox.Text));
            command.Parameters.AddWithValue("@p3", double.Parse(priceTextBox.Text));
            command.Parameters.AddWithValue("@p4", int.Parse(ProductIdTextBox.Text));
            command.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Ürün güncelleme başarılı.");
        }

        private void searchButton2_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("select * from product where product_name like '%" + ProductNameTextBox.Text + "%'", connect);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
            connect.Close();

        }

        private void listButton3_Click(object sender, EventArgs e)
        {
            string query = "select * from personnel";
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connect);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView3.DataSource = dataSet.Tables[0];
            connect.Close();
        }

        private void addButton3_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command = new NpgsqlCommand("insert into personnel(personnel_id, personnel_name, personnel_surname, personnel_age, personnel_salary, personnel_type) " +
                "values (@p1, @p2, @p3, @p4, @p5, @p6)", connect);
            command.Parameters.AddWithValue("@p1", int.Parse(textBox4.Text));
            command.Parameters.AddWithValue("@p2", textBox3.Text);
            command.Parameters.AddWithValue("@p3", textBox2.Text);
            command.Parameters.AddWithValue("@p4", int.Parse(textBox1.Text));
            command.Parameters.AddWithValue("@p5", double.Parse(textBox5.Text));
            command.Parameters.AddWithValue("@p6", int.Parse(comboBox1.SelectedValue.ToString()));
            command.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Personel ekleme başarılı.");
        }

        private void deleteButton3_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command = new NpgsqlCommand("delete from personnel where personnel_id=@p1", connect);
            command.Parameters.AddWithValue("@p1", int.Parse(textBox4.Text));
            command.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Personel silme işlemi başarılı.");
        }

        private void UpdateButton3_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command = new NpgsqlCommand("update personnel set personnel_name=@p2, personnel_surname=@p3, personnel_age = @p4, personnel_salary=@p5 where personnel_id = @p1", connect);
            command.Parameters.AddWithValue("@p1", int.Parse(textBox4.Text));
            command.Parameters.AddWithValue("@p2", textBox3.Text);
            command.Parameters.AddWithValue("@p3", textBox2.Text);
            command.Parameters.AddWithValue("@p4", int.Parse(textBox1.Text));
            command.Parameters.AddWithValue("@p5", double.Parse(textBox5.Text));
            command.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Ürün güncelleme başarılı.");
        }

        private void searchButton3_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("select * from personnel where (personnel_name like '%" + textBox3.Text + "%' and " +
                "personnel_surname like '%" + textBox2.Text + "%')", connect);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView3.DataSource = dataSet.Tables[0];
            connect.Close();
        }
    }
}
