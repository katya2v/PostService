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
            components = new System.ComponentModel.Container();
            gridPostings = new DataGridView();
            btnDelete = new Button();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)gridPostings).BeginInit();
            SuspendLayout();
            //
            // gridPostings
            //
            gridPostings.AllowUserToAddRows = false;
            gridPostings.AllowUserToDeleteRows = false;
            gridPostings.AutoGenerateColumns = false;
            gridPostings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridPostings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPostings.Columns.AddRange(
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Ідентифікатор", Name = "colId", Visible = false },
                new DataGridViewTextBoxColumn { DataPropertyName = "From", HeaderText = "Відправник", Name = "colFrom" },
                new DataGridViewTextBoxColumn { DataPropertyName = "To", HeaderText = "Одержувач", Name = "colTo" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Content", HeaderText = "Вміст", Name = "colContent" },
                new DataGridViewTextBoxColumn { DataPropertyName = "DeliveryType", HeaderText = "Тип доставки", Name = "colDeliveryType" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Weight", HeaderText = "Вага", Name = "colWeight" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Width", HeaderText = "Ширина", Name = "colWidth" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Height", HeaderText = "Висота", Name = "colHeight" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Depth", HeaderText = "Глибина", Name = "colDepth" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Value", HeaderText = "Оголошена вартість", Name = "colValue" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "Ціна доставки", Name = "colPrice" },
                new DataGridViewTextBoxColumn { DataPropertyName = "CreatedAt", HeaderText = "Дата створення", Name = "colCreatedAt", Visible = false });
            gridPostings.Location = new Point(12, 12);
            gridPostings.MultiSelect = false;
            gridPostings.Name = "gridPostings";
            gridPostings.ReadOnly = true;
            gridPostings.RowHeadersWidth = 51;
            gridPostings.RowTemplate.Height = 29;
            gridPostings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridPostings.Size = new Size(776, 380);
            //
            // btnDelete
            //
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.Location = new Point(12, 405);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 33);
            btnDelete.Text = "Видалити";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            //
            // btnRefresh
            //
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefresh.Location = new Point(668, 405);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 33);
            btnRefresh.Text = "Оновити";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            //
            // PostingList
            //
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gridPostings);
            Controls.Add(btnDelete);
            Controls.Add(btnRefresh);
            Name = "PostingList";
            Text = "Відправлення";
            Load += PostingList_Load;
            ((System.ComponentModel.ISupportInitialize)gridPostings).EndInit();
            ResumeLayout(false);
        }

        private DataGridView gridPostings;
        private Button btnDelete;
        private Button btnRefresh;

        #endregion
    }
}
