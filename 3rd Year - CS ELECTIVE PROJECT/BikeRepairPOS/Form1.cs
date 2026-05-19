using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BikeRepairPOS
{
    public partial class Form1 : Form
    {
        // Service prices dictionary
        private Dictionary<string, decimal> servicePrices = new Dictionary<string, decimal>
        {
            { "Tire Repair", 15m },
            { "Chain Replacement", 25m },
            { "Brake Pads", 35m },
            { "Spoke Repair", 12m },
            { "Wheel Alignment", 20m },
            { "Gear Adjustment", 18m }
        };

        private System.ComponentModel.IContainer components = null;

        private CheckBox[] serviceCheckBoxes = new CheckBox[6];
        private Label totalLabel;
        private ListBox historyListBox;
        private TextBox customerNameTextBox;
        private ComboBox bikeTypeComboBox;

        public Form1()
        {
            CreateControls();
            LoadSampleHistory();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "BikeRepairPOS";
        }

        private void CreateControls()
        {
            // Form settings
            this.Text = "Bike Repair Shop - POS System";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            // Title Label
            Label titleLabel = new Label();
            titleLabel.Text = "🚴 BIKE REPAIR SHOP POS";
            titleLabel.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(33, 150, 243);
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(20, 15);
            this.Controls.Add(titleLabel);

            // ========== LEFT PANEL ==========
            // Customer Name Label
            Label customerNameLabel = new Label();
            customerNameLabel.Text = "Customer Name:";
            customerNameLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            customerNameLabel.Location = new Point(20, 60);
            customerNameLabel.AutoSize = true;
            this.Controls.Add(customerNameLabel);

            // Customer Name TextBox
            customerNameTextBox = new TextBox();
            customerNameTextBox.Location = new Point(20, 85);
            customerNameTextBox.Size = new Size(300, 30);
            customerNameTextBox.Font = new Font("Segoe UI", 10);
            this.Controls.Add(customerNameTextBox);

            // Bike Type Label
            Label bikeTypeLabel = new Label();
            bikeTypeLabel.Text = "Bike Type:";
            bikeTypeLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            bikeTypeLabel.Location = new Point(20, 130);
            bikeTypeLabel.AutoSize = true;
            this.Controls.Add(bikeTypeLabel);

            // Bike Type ComboBox
            bikeTypeComboBox = new ComboBox();
            bikeTypeComboBox.Location = new Point(20, 155);
            bikeTypeComboBox.Size = new Size(300, 30);
            bikeTypeComboBox.Font = new Font("Segoe UI", 10);
            bikeTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            bikeTypeComboBox.Items.AddRange(new string[] { "Mountain", "Road", "City", "BMX" });
            bikeTypeComboBox.SelectedIndex = 0;
            this.Controls.Add(bikeTypeComboBox);

            // Services Label
            Label servicesLabel = new Label();
            servicesLabel.Text = "Services:";
            servicesLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            servicesLabel.Location = new Point(20, 200);
            servicesLabel.AutoSize = true;
            this.Controls.Add(servicesLabel);

            // Service CheckBoxes
            string[] serviceNames = { "Tire Repair (₱15)", "Chain Replacement (₱25)", "Brake Pads (₱35)", 
                                      "Spoke Repair (₱12)", "Wheel Alignment (₱20)", "Gear Adjustment (₱18)" };
            int yPosition = 230;

            for (int i = 0; i < 6; i++)
            {
                serviceCheckBoxes[i] = new CheckBox();
                serviceCheckBoxes[i].Text = serviceNames[i];
                serviceCheckBoxes[i].Location = new Point(20, yPosition);
                serviceCheckBoxes[i].Size = new Size(300, 25);
                serviceCheckBoxes[i].Font = new Font("Segoe UI", 10);
                serviceCheckBoxes[i].ForeColor = Color.FromArgb(60, 60, 60);
                serviceCheckBoxes[i].CheckedChanged += (s, e) => UpdateTotal();
                this.Controls.Add(serviceCheckBoxes[i]);
                yPosition += 30;
            }

            // Total Label
            Label totalTextLabel = new Label();
            totalTextLabel.Text = "Total Amount:";
            totalTextLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            totalTextLabel.Location = new Point(20, 415);
            totalTextLabel.AutoSize = true;
            this.Controls.Add(totalTextLabel);

            totalLabel = new Label();
            totalLabel.Text = "₱0.00";
            totalLabel.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            totalLabel.ForeColor = Color.FromArgb(76, 175, 80);
            totalLabel.Location = new Point(20, 440);
            totalLabel.Size = new Size(300, 35);
            totalLabel.BorderStyle = BorderStyle.FixedSingle;
            totalLabel.TextAlign = ContentAlignment.MiddleCenter;
            totalLabel.BackColor = Color.White;
            this.Controls.Add(totalLabel);

            // ========== BUTTONS ==========
            Button completeButton = new Button();
            completeButton.Text = "✓ Complete Repair";
            completeButton.Location = new Point(20, 490);
            completeButton.Size = new Size(140, 40);
            completeButton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            completeButton.BackColor = Color.FromArgb(76, 175, 80);
            completeButton.ForeColor = Color.White;
            completeButton.FlatStyle = FlatStyle.Flat;
            completeButton.FlatAppearance.BorderSize = 0;
            completeButton.Cursor = Cursors.Hand;
            completeButton.Click += CompleteRepair_Click;
            this.Controls.Add(completeButton);

            Button clearButton = new Button();
            clearButton.Text = "✕ Clear";
            clearButton.Location = new Point(180, 490);
            clearButton.Size = new Size(140, 40);
            clearButton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            clearButton.BackColor = Color.FromArgb(244, 67, 54);
            clearButton.ForeColor = Color.White;
            clearButton.FlatStyle = FlatStyle.Flat;
            clearButton.FlatAppearance.BorderSize = 0;
            clearButton.Cursor = Cursors.Hand;
            clearButton.Click += Clear_Click;
            this.Controls.Add(clearButton);

            // ========== RIGHT PANEL - HISTORY ==========
            Label historyTitleLabel = new Label();
            historyTitleLabel.Text = "📋 Repair History";
            historyTitleLabel.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            historyTitleLabel.ForeColor = Color.FromArgb(33, 150, 243);
            historyTitleLabel.Location = new Point(370, 60);
            historyTitleLabel.AutoSize = true;
            this.Controls.Add(historyTitleLabel);

            historyListBox = new ListBox();
            historyListBox.Location = new Point(370, 90);
            historyListBox.Size = new Size(500, 440);
            historyListBox.Font = new Font("Segoe UI", 9);
            historyListBox.BackColor = Color.White;
            historyListBox.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(historyListBox);

            // Clear History Button
            Button clearHistoryButton = new Button();
            clearHistoryButton.Text = "Clear History";
            clearHistoryButton.Location = new Point(370, 540);
            clearHistoryButton.Size = new Size(200, 30);
            clearHistoryButton.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            clearHistoryButton.BackColor = Color.FromArgb(158, 158, 158);
            clearHistoryButton.ForeColor = Color.White;
            clearHistoryButton.FlatStyle = FlatStyle.Flat;
            clearHistoryButton.FlatAppearance.BorderSize = 0;
            clearHistoryButton.Cursor = Cursors.Hand;
            clearHistoryButton.Click += (s, e) => historyListBox.Items.Clear();
            this.Controls.Add(clearHistoryButton);
        }

        private void UpdateTotal()
        {
            decimal total = 0;
            string[] serviceKeys = { "Tire Repair", "Chain Replacement", "Brake Pads", "Spoke Repair", "Wheel Alignment", "Gear Adjustment" };

            for (int i = 0; i < 6; i++)
            {
                if (serviceCheckBoxes[i].Checked)
                {
                    total += servicePrices[serviceKeys[i]];
                }
            }

            totalLabel.Text = "₱" + total.ToString("F2");
        }

        private void CompleteRepair_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(customerNameTextBox.Text))
            {
                MessageBox.Show("Please enter customer name!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if at least one service is selected
            bool hasService = false;
            for (int i = 0; i < 6; i++)
            {
                if (serviceCheckBoxes[i].Checked)
                {
                    hasService = true;
                    break;
                }
            }

            if (!hasService)
            {
                MessageBox.Show("Please select at least one service!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Build service list
            string services = "";
            string[] serviceKeys = { "Tire Repair", "Chain Replacement", "Brake Pads", "Spoke Repair", "Wheel Alignment", "Gear Adjustment" };
            for (int i = 0; i < 6; i++)
            {
                if (serviceCheckBoxes[i].Checked)
                {
                    services += (services == "" ? "" : ", ") + serviceKeys[i];
                }
            }

            string total = totalLabel.Text;
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string bikeType = bikeTypeComboBox.SelectedItem.ToString();

            // Add to history
            string historyEntry = $"[{timestamp}] {customerNameTextBox.Text} | {bikeType} | {services} | {total}";
            historyListBox.Items.Add(historyEntry);

            // Show confirmation
            MessageBox.Show($"✓ Repair completed!\n\nCustomer: {customerNameTextBox.Text}\nBike Type: {bikeType}\nServices: {services}\nTotal: {total}", 
                           "Repair Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear form
            Clear_Click(null, null);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            customerNameTextBox.Clear();
            bikeTypeComboBox.SelectedIndex = 0;

            for (int i = 0; i < 6; i++)
            {
                serviceCheckBoxes[i].Checked = false;
            }

            totalLabel.Text = "₱0.00";
            customerNameTextBox.Focus();
        }

        private void LoadSampleHistory()
        {
            historyListBox.Items.Add("[2026-03-24 09:15:00] John Smith | Mountain | Tire Repair, Chain Replacement | ₱40.00");
            historyListBox.Items.Add("[2026-03-24 09:45:00] Sarah Johnson | Road | Brake Pads, Wheel Alignment | ₱55.00");
            historyListBox.Items.Add("[2026-03-24 10:20:00] Mike Davis | City | Spoke Repair, Gear Adjustment | ₱30.00");
            historyListBox.Items.Add("[2026-03-24 10:55:00] Emily Wilson | BMX | Tire Repair, Brake Pads | ₱50.00");
            historyListBox.Items.Add("[2026-03-24 11:30:00] Robert Brown | Mountain | Chain Replacement, Wheel Alignment, Gear Adjustment | ₱63.00");
        }
    }
}
