namespace RandomChooser
{
    partial class ManageItemsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstAllItems = new System.Windows.Forms.ListBox();
            this.txtRename = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstAllItems
            // 
            this.lstAllItems.FormattingEnabled = true;
            this.lstAllItems.Location = new System.Drawing.Point(39, 23);
            this.lstAllItems.Name = "lstAllItems";
            this.lstAllItems.Size = new System.Drawing.Size(120, 108);
            this.lstAllItems.TabIndex = 0;
            this.lstAllItems.SelectedIndexChanged += new System.EventHandler(this.lstAllItems_SelectedIndexChanged);
            // 
            // txtRename
            // 
            this.txtRename.Location = new System.Drawing.Point(267, 23);
            this.txtRename.Name = "txtRename";
            this.txtRename.Size = new System.Drawing.Size(100, 20);
            this.txtRename.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(267, 107);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(267, 49);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(100, 23);
            this.btnRename.TabIndex = 3;
            this.btnRename.Text = "Đổi tên";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(267, 78);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ManageItemsForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 161);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRename);
            this.Controls.Add(this.lstAllItems);
            this.Name = "ManageItemsForm";
            this.Text = "Quản lý các giá trị";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstAllItems;
        private System.Windows.Forms.TextBox txtRename;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnDelete;
    }
}