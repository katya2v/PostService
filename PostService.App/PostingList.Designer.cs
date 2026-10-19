namespace PostService.App
{
    partial class PostingList
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvShipments = new DataGridView();
            btnDelete = new Button();
            btnRefresh = new Button();
            btnCreate = new Button();
            btnEdit = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvShipments).BeginInit();
            SuspendLayout();
            // 
            // dgvShipments
            // 
            dgvShipments.AllowUserToAddRows = false;
            dgvShipments.AllowUserToDeleteRows = false;
            dgvShipments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvShipments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvShipments.BackgroundColor = Color.FromArgb(246, 249, 248);
            dgvShipments.BorderStyle = BorderStyle.None;
            dgvShipments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvShipments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvShipments.ColumnHeadersHeight = 48;
            dgvShipments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.PaleGreen;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvShipments.DefaultCellStyle = dataGridViewCellStyle1;
            dgvShipments.EnableHeadersVisualStyles = false;
            dgvShipments.GridColor = Color.FromArgb(228, 236, 234);
            dgvShipments.Location = new Point(12, 12);
            dgvShipments.MultiSelect = false;
            dgvShipments.Name = "dgvShipments";
            dgvShipments.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightGreen;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvShipments.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvShipments.RowHeadersVisible = false;
            dgvShipments.RowHeadersWidth = 51;
            dgvShipments.RowTemplate.Height = 61;
            dgvShipments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvShipments.Size = new Size(776, 380);
            dgvShipments.TabIndex = 0;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.BackColor = Color.FromArgb(246, 249, 248);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.FromArgb(0, 92, 82);
            btnDelete.Location = new Point(12, 405);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 33);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Видалити";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefresh.BackColor = Color.FromArgb(231, 244, 240);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.FromArgb(0, 119, 105);
            btnRefresh.Location = new Point(668, 405);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 33);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Оновити";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnCreate
            // 
            btnCreate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCreate.BackColor = Color.FromArgb(0, 119, 105);
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(148, 405);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(120, 33);
            btnCreate.TabIndex = 3;
            btnCreate.Text = "Створити";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEdit.BackColor = Color.FromArgb(231, 244, 240);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.ForeColor = Color.FromArgb(0, 119, 105);
            btnEdit.Location = new Point(278, 405);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(120, 33);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Редагувати";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // PostingList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 249, 248);
            ClientSize = new Size(800, 450);
            Controls.Add(dgvShipments);
            Controls.Add(btnDelete);
            Controls.Add(btnRefresh);
            Controls.Add(btnCreate);
            Controls.Add(btnEdit);
            Name = "PostingList";
            Text = "Відправлення";
            Load += PostingList_Load;
            ((System.ComponentModel.ISupportInitialize)dgvShipments).EndInit();
            ResumeLayout(false);
        }

        private DataGridView dgvShipments;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnCreate;
        private Button btnEdit;

        #endregion
    }
}
