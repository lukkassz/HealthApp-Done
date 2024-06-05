using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using OfficeOpenXml; // Excel export
using System.IO;
using iTextSharp.text; // PDF export
using iTextSharp.text.pdf; // PDF export

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private int selectedRowId;

        public Form1()
        {
            InitializeComponent();
            AddEditButtonColumn();
            LoadDataIntoDataGridView();
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);

            tabControl.SelectedIndexChanged += new EventHandler(tabControl_SelectedIndexChanged);

            // Set up tab names and texts
            tabControl.TabPages[0].Name = "tabHealthData";
            tabControl.TabPages[0].Text = "Health Data";

            tabControl.TabPages[1].Name = "tabSummary";
            tabControl.TabPages[1].Text = "Summary";

            // Check and set up the Charts tab
            if (!tabControl.TabPages.ContainsKey("tabCharts"))
            {
                var tabCharts = new TabPage();
                tabCharts.Name = "tabCharts";
                tabCharts.Text = "Charts";
                tabControl.TabPages.Add(tabCharts);

                // Create and add chart
                var chFruit = new Chart();
                chFruit.Name = "chFruit";
                chFruit.Dock = DockStyle.Fill;
                tabCharts.Controls.Add(chFruit);

                // Create and add labels
                var lblTotalFruit = new Label();
                lblTotalFruit.Name = "lblTotalFruit";
                lblTotalFruit.AutoSize = true;
                lblTotalFruit.Location = new System.Drawing.Point(20, 20);
                lblTotalFruit.Text = "Total Fruit: ";
                tabCharts.Controls.Add(lblTotalFruit);

                var lblTotalExercise = new Label();
                lblTotalExercise.Name = "lblTotalExercise";
                lblTotalExercise.AutoSize = true;
                lblTotalExercise.Location = new System.Drawing.Point(20, 50);
                lblTotalExercise.Text = "Total Exercise: ";
                tabCharts.Controls.Add(lblTotalExercise);

                var lblTotalFruitValue = new Label();
                lblTotalFruitValue.Name = "lblTotalFruitValue";
                lblTotalFruitValue.AutoSize = true;
                lblTotalFruitValue.Location = new System.Drawing.Point(120, 20);
                tabCharts.Controls.Add(lblTotalFruitValue);

                var lblTotalExerciseValue = new Label();
                lblTotalExerciseValue.Name = "lblTotalExerciseValue";
                lblTotalExerciseValue.AutoSize = true;
                lblTotalExerciseValue.Location = new System.Drawing.Point(120, 50);
                tabCharts.Controls.Add(lblTotalExerciseValue);
            }

            // Add event handler for the Refresh button
            refreshButton.Click += new EventHandler(refreshButton_Click);

            // Set up Update button click event
            btnUpdate.Click += new EventHandler(btnSaveChanges_Click);

            // Add event handler for the Export Excel button
            btnExcelExport.Click += new EventHandler(btnExcelExport_Click);

            // Add event handler for the Export PDF button
            btnPdfExport.Click += new EventHandler(btnPdfExport_Click);
        }

        // Handle Refresh button click event to reload data
        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        // Load data into DataGridView when form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        // Handle tab selection change
        private void tabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabCharts")
            {
                GenerateFruitChart();
            }
        }

        // Generate and display the fruit and exercise chart
        private void GenerateFruitChart()
        {
            var chFruit = (Chart)tabControl.TabPages["tabCharts"].Controls["chFruit"];

            // Clear existing elements to prevent "already exists" error
            chFruit.Series.Clear();
            chFruit.Legends.Clear();
            chFruit.Titles.Clear();
            chFruit.ChartAreas.Clear();

            // Database connection
            string connectionString = @"Server=LUKASZ\SQLEXPRESS03;Database=HealthAppDB;Trusted_Connection=True; TrustServerCertificate=True";
            string queryTotalFruit = "SELECT SUM(FruitPerDay) AS TotalFruit FROM dbo.HealthData";
            string queryTotalExercise = "SELECT SUM(ExercisePerWeek) AS TotalExercise FROM dbo.HealthData";

            int totalFruit = 0;
            int totalExercise = 0;

            try
            {
                // Execute SQL queries to get total fruit and exercise
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(queryTotalFruit, con))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            totalFruit = Convert.ToInt32(result);
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand(queryTotalExercise, con))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            totalExercise = Convert.ToInt32(result);
                        }
                    }
                }

                if (totalFruit == 0 && totalExercise == 0)
                {
                    MessageBox.Show("No data to display on the chart.");
                    return;
                }

                // Add the legend
                Legend legend = new Legend();
                legend.Title = "Legend";
                chFruit.Legends.Add(legend);

                // Configure the chart area
                ChartArea chartArea = new ChartArea();
                chartArea.Name = "ChartArea1";
                chFruit.ChartAreas.Add(chartArea);

                // Create and configure the series
                string seriesName = "Fruit vs Exercise";
                Series series = new Series
                {
                    Name = seriesName,
                    IsVisibleInLegend = true,
                    ChartType = SeriesChartType.Pie
                };
                chFruit.Series.Add(series);

                // Add data points with labels
                series.Points.AddXY($"Total Fruit: {totalFruit}", totalFruit);
                series.Points.AddXY($"Total Exercise: {totalExercise}", totalExercise);

                // Customize colors
                series.Points[0].Color = Color.Green;
                series.Points[1].Color = Color.Blue;

                // Add title
                Title title = new Title();
                title.Text = "Fruit and Exercise Comparison";
                title.Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold);
                chFruit.Titles.Add(title);

                // Update labels with values
                var lblTotalFruitValue = tabControl.TabPages["tabCharts"].Controls["lblTotalFruitValue"] as Label;
                var lblTotalExerciseValue = tabControl.TabPages["tabCharts"].Controls["lblTotalExerciseValue"] as Label;

                if (lblTotalFruitValue != null)
                {
                    lblTotalFruitValue.Text = totalFruit.ToString();
                }

                if (lblTotalExerciseValue != null)
                {
                    lblTotalExerciseValue.Text = totalExercise.ToString();
                }

                // Refresh the chart to display updates
                chFruit.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // Handle the Submit button click event to insert data
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter your name.");
                return;
            }

            // Get the selected values for fruit and exercise
            int fruitPerDay = rbFruit0.Checked ? 0 :
                              rbFruit1.Checked ? 1 :
                              rbFruit2.Checked ? 2 :
                              rbFruit3.Checked ? 3 : -1;

            int exercisePerWeek = exercise0.Checked ? 0 :
                                  exercise1.Checked ? 1 :
                                  exercise2.Checked ? 2 :
                                  exercise3.Checked ? 3 : -1;

            if (fruitPerDay == -1 || exercisePerWeek == -1)
            {
                MessageBox.Show("Please select options for fruit and exercise.");
                return;
            }

            try
            {
                // Insert data into the database
                InsertData(txtName.Text, fruitPerDay, exercisePerWeek);
                MessageBox.Show("Data submitted successfully!");

                // Clear the form
                txtName.Clear();
                rbFruit0.Checked = rbFruit1.Checked = rbFruit2.Checked = rbFruit3.Checked = false;
                exercise0.Checked = exercise1.Checked = exercise2.Checked = exercise3.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // Insert data into the database
        private void InsertData(string name, int fruitPerDay, int exercisePerWeek)
        {
            try
            {
                // Database connection
                string connectionString = @"Server=LUKASZ\SQLEXPRESS03;Database=HealthAppDB;Trusted_Connection=True; TrustServerCertificate=True ";
                string query = "INSERT INTO dbo.HealthData (Name, FruitPerDay, ExercisePerWeek) VALUES (@Name, @FruitPerDay, @ExercisePerWeek)";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@FruitPerDay", fruitPerDay);
                        cmd.Parameters.AddWithValue("@ExercisePerWeek", exercisePerWeek);

                        con.Open();
                        int result = cmd.ExecuteNonQuery();

                        if (result == 1)
                        {
                            MessageBox.Show("Record inserted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("The record was not inserted.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Add Edit button to DataGridView
        private void AddEditButtonColumn()
        {
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "Edit";
            btnEdit.Text = "Edit";
            btnEdit.Name = "btnEdit";
            btnEdit.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnEdit);
        }

        // Load data into DataGridView
        private void LoadDataIntoDataGridView()
        {
            // Database connection
            string connectionString = @"Server=LUKASZ\SQLEXPRESS03;Database=HealthAppDB;Trusted_Connection=True; TrustServerCertificate=True ";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM HealthData", con))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;

                        if (!dataGridView1.Columns.Contains("btnEdit"))
                        {
                            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn();
                            editColumn.Name = "btnEdit";
                            editColumn.Text = "Edit";
                            editColumn.UseColumnTextForButtonValue = true;
                            dataGridView1.Columns.Add(editColumn);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading data: " + ex.Message);
                }
            }
        }

        private void ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                // Add a new worksheet to the empty workbook
                var worksheet = package.Workbook.Worksheets.Add("HealthData");

                // Add the headers
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dataGridView1.Columns[i].HeaderText;
                }

                // Add the rows
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dataGridView1.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // Save the file
                using (var saveFileDialog = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var fi = new FileInfo(saveFileDialog.FileName);
                        package.SaveAs(fi);
                        MessageBox.Show("Exported successfully.");
                    }
                }
            }
        }

        private void ExportToPdf()
        {
            try
            {
                using (var saveFileDialog = new SaveFileDialog() { Filter = "PDF Files|*.pdf" })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var document = new Document();
                        PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                        document.Open();

                        // Add a title to the document
                        var titleFont = iTextSharp.text.FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD);
                        var title = new iTextSharp.text.Paragraph("Health Data", titleFont)
                        {
                            Alignment = iTextSharp.text.Element.ALIGN_CENTER,
                            SpacingAfter = 20
                        };
                        document.Add(title);

                        // Create a PDF table with the same number of columns as the DataGridView
                        PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);

                        // Add the headers from the DataGridView to the PDF table
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new iTextSharp.text.Phrase(column.HeaderText))
                            {
                                BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
                            };
                            pdfTable.AddCell(cell);
                        }

                        // Add the data rows from the DataGridView to the PDF table
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                pdfTable.AddCell(cell.Value?.ToString());
                            }
                        }

                        // Add the PDF table to the document
                        document.Add(pdfTable);

                        document.Close();
                        MessageBox.Show("Exported to PDF successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while exporting to PDF: " + ex.Message);
            }
        }

        // Handle DataGridView cell click event for Edit button
        private void dataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["btnEdit"].Index && e.RowIndex >= 0)
            {
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                selectedRowId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                txtName.Text = Convert.ToString(selectedRow.Cells["Name"].Value);

                int fruitsPerDay = Convert.ToInt32(selectedRow.Cells["FruitPerDay"].Value);
                int exercisesPerWeek = Convert.ToInt32(selectedRow.Cells["ExercisePerWeek"].Value);

                // Set the radio buttons based on the selected row values
                switch (fruitsPerDay)
                {
                    case 0: rbFruit0.Checked = true; break;
                    case 1: rbFruit1.Checked = true; break;
                    case 2: rbFruit2.Checked = true; break;
                    default: rbFruit3.Checked = true; break;
                }

                switch (exercisesPerWeek)
                {
                    case 0: exercise0.Checked = true; break;
                    case 1: exercise1.Checked = true; break;
                    case 2: exercise2.Checked = true; break;
                    default: exercise3.Checked = true; break;
                }

                btnSubmit.Visible = false;
                btnUpdate.Visible = true;
                tabControl.SelectTab(0);
            }
        }

        // Handle the Save Changes button click event to update data
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter your name.");
                return;
            }

            // Get the selected values for fruit and exercise
            int fruitPerDay = rbFruit0.Checked ? 0 :
                              rbFruit1.Checked ? 1 :
                              rbFruit2.Checked ? 2 :
                              rbFruit3.Checked ? 3 : -1;

            int exercisePerWeek = exercise0.Checked ? 0 :
                                  exercise1.Checked ? 1 :
                                  exercise2.Checked ? 2 :
                                  exercise3.Checked ? 3 : -1;

            if (fruitPerDay == -1 || exercisePerWeek == -1)
            {
                MessageBox.Show("Please select options for fruit and exercise.");
                return;
            }

            // Database connection
            string connectionString = @"Server=LUKASZ\SQLEXPRESS03;Database=HealthAppDB;Trusted_Connection=True; TrustServerCertificate=True";
            string query = "UPDATE dbo.HealthData SET Name = @Name, FruitPerDay = @FruitPerDay, ExercisePerWeek = @ExercisePerWeek WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", txtName.Text);
                    command.Parameters.AddWithValue("@FruitPerDay", fruitPerDay);
                    command.Parameters.AddWithValue("@ExercisePerWeek", exercisePerWeek);
                    command.Parameters.AddWithValue("@ID", selectedRowId);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Record updated successfully.");
                            LoadDataIntoDataGridView(); // Reload data to refresh view
                            tabControl.SelectTab(tabControl.TabPages["tabHealthData"]); // Switch to Health Data tab
                        }
                        else
                        {
                            MessageBox.Show("Record not updated.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }

        // Handle the Cancel Edit button click event
        private void btnCancelEdit_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void btnPdfExport_Click(object sender, EventArgs e)
        {
            ExportToPdf();
        }
    }
}
