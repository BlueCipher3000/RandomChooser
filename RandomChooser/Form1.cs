using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RandomChooser
{
    public partial class Form1 : Form
    {
        private string filePath = Path.Combine(Application.StartupPath, "candidates.txt");
        private void SaveListToDisk()
        {
            // Collect all items from the CheckedListBox
            var items = clbItems.Items.Cast<string>().ToList();
            // Write them to a plain text file, one per line
            File.WriteAllLines(filePath, items);
        }
        private void LoadListFromDisk()
        {
            if (File.Exists(filePath))
            {
                string[] savedItems = File.ReadAllLines(filePath);
                clbItems.Items.Clear();
                foreach (var item in savedItems)
                {
                    // Add them back and default them to checked
                    clbItems.Items.Add(item, true);
                }
            }
            if (File.Exists(settingsPath))
            {
                if (int.TryParse(File.ReadAllText(settingsPath), out int savedSeconds))
                {
                    totalSpinTime = savedSeconds * 1000; // Convert back to ms
                }
            }
        }
        private Timer spinTimer;
        private int elapsedMs = 0;
        private int totalSpinTime = 5000; // Default to 5 seconds (in ms)
        private string settingsPath = Path.Combine(Application.StartupPath, "settings.cfg");
        private List<string> activePool;
        private Random rng = new Random();
        public Form1()
        {
            InitializeComponent();
            // Critical for shortcuts to work regardless of focus
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            // Initialize the Timer
            spinTimer = new Timer();
            spinTimer.Interval = 50; // Change name every 50ms
            spinTimer.Tick += SpinTimer_Tick;
            LoadListFromDisk();
        }
        private void StartSpin()
        {
            // Gather currently checked items
            activePool = clbItems.CheckedItems.Cast<string>().ToList();

            if (activePool.Count < 1)
            {
                MessageBox.Show("Please check at least one item!");
                return;
            }

            // Reset and Start
            elapsedMs = 0;
            lblResult.ForeColor = System.Drawing.Color.Gray; // Dim during shuffle
            spinTimer.Start();
        }
        private void SpinTimer_Tick(object sender, EventArgs e)
        {
            // 1. Increment the timer's progress
            elapsedMs += spinTimer.Interval;

            // 2. Pick a random name from your pool and show it on the label
            if (activePool != null && activePool.Count > 0)
            {
                int randomIndex = rng.Next(activePool.Count);
                lblResult.Text = activePool[randomIndex];
            }

            // 3. Check if 5 seconds (5000ms) have passed
            if (elapsedMs >= totalSpinTime)
            {
                spinTimer.Stop(); // Stop the heart

                // Final "Winner" styling
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "★ " + lblResult.Text + " ★";

                // Optional: Trigger a sound or alert
                System.Media.SystemSounds.Exclamation.Play();
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // 'A' Key opens the separate input window
            if (e.KeyCode == Keys.Space && !spinTimer.Enabled)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                StartSpin();
            }

            // 'A' to open your Add Component window
            if (e.KeyCode == Keys.A)
            {
                OpenAddWindow();
            }

            // Number shortcuts 1-9 for toggling
            HandleNumberShortcuts(e.KeyCode);
            if (e.KeyCode == Keys.M && !spinTimer.Enabled)
            {
                OpenManageWindow();
            }
            if (e.KeyCode == Keys.S && !spinTimer.Enabled)
            {
                OpenSettingsWindow();
            }
        }
        //private void PerformSpin()
        //{
        //    var activeItems = clbItems.CheckedItems.Cast<object>().ToList();
        //    if (activeItems.Count > 0)
        //    {
        //        var result = activeItems[new Random().Next(activeItems.Count)];
        //        MessageBox.Show($"Selected: {result}");
        //    }
        //}
        private void HandleNumberShortcuts(Keys key)
        {
            if (clbItems.Items.Count > 0 && clbItems.Items.Count < 10)
            {
                if (key >= Keys.D1 && key <= Keys.D9)
                {
                    int index = key - Keys.D1;
                    if (index < clbItems.Items.Count)
                    {
                        clbItems.SetItemChecked(index, !clbItems.GetItemChecked(index));
                    }
                }
            }
        }
        private void OpenAddWindow()
        {
            using (var addForm = new AddValueForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    string newValue = addForm.ValueEntered;
                    if (!string.IsNullOrWhiteSpace(newValue))
                    {
                        clbItems.Items.Add(newValue);
                        SaveListToDisk();
                    }
                }
            }
        }
        private void OpenManageWindow()
        {
            var currentItems = clbItems.Items.Cast<string>().ToList();

            using (var manageForm = new ManageItemsForm(currentItems))
            {
                if (manageForm.ShowDialog() == DialogResult.OK)
                {
                    // Clear the old list and add the updated ones
                    clbItems.Items.Clear();
                    foreach (var item in manageForm.UpdatedItems)
                    {
                        // Re-add them as checked by default
                        clbItems.Items.Add(item, true);
                    }
                    SaveListToDisk();
                }
            }
        }
        private void OpenSettingsWindow()
        {
            // Pass current seconds (ms / 1000)
            using (var settForm = new SettingsForm(totalSpinTime / 1000))
            {
                if (settForm.ShowDialog() == DialogResult.OK)
                {
                    totalSpinTime = settForm.SelectedDuration * 1000;
                    // Save to disk immediately
                    File.WriteAllText(settingsPath, settForm.SelectedDuration.ToString());
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenAddWindow();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            OpenManageWindow();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // Adjust the number (20) to find the "sweet spot" for your design
            float newSize = this.Width / 32f;

            if (newSize > 8) // Keep it readable
            {
                lblResult.Font = new Font(lblResult.Font.FontFamily, newSize, lblResult.Font.Style);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenSettingsWindow();
        }
    }
}
