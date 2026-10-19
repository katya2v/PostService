#nullable enable
namespace PostService.App;

partial class PostingEditor
{
    private System.ComponentModel.IContainer? components = null;
    private Panel mainPanel = null!;
    private Panel footer = null!;
    private Panel senderSection = null!;
    private Panel recipientSection = null!;
    private Panel parcelSection = null!;
    private Label senderBadge = null!;
    private Label recipientBadge = null!;
    private Label parcelBadge = null!;
    private Label senderHeading = null!;
    private Label senderDescription = null!;
    private Label recipientHeading = null!;
    private Label recipientDescription = null!;
    private Label parcelHeading = null!;
    private Label parcelDescription = null!;
    private Label senderLabel = null!;
    private Label recipientLabel = null!;
    private Label contentLabel = null!;
    private Label deliveryTypeLabel = null!;
    private Label weightLabel = null!;
    private Label lengthLabel = null!;
    private Label widthLabel = null!;
    private Label heightLabel = null!;
    private Label declaredValueLabel = null!;
    private Label deliveryPriceLabel = null!;
    private TextBox senderName = null!;
    private TextBox recipientName = null!;
    private TextBox parcelContent = null!;
    private ComboBox deliveryType = null!;
    private NumericUpDown weight = null!;
    private NumericUpDown length = null!;
    private NumericUpDown width = null!;
    private NumericUpDown height = null!;
    private NumericUpDown declaredValue = null!;
    private NumericUpDown deliveryPrice = null!;
    private Button save = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        mainPanel = new Panel();
        senderSection = new Panel();
        senderBadge = new Label();
        senderHeading = new Label();
        senderDescription = new Label();
        senderLabel = new Label();
        senderName = new TextBox();
        recipientSection = new Panel();
        recipientBadge = new Label();
        recipientHeading = new Label();
        recipientDescription = new Label();
        recipientLabel = new Label();
        recipientName = new TextBox();
        parcelSection = new Panel();
        parcelBadge = new Label();
        parcelHeading = new Label();
        parcelDescription = new Label();
        contentLabel = new Label();
        parcelContent = new TextBox();
        deliveryTypeLabel = new Label();
        deliveryType = new ComboBox();
        weightLabel = new Label();
        weight = new NumericUpDown();
        lengthLabel = new Label();
        length = new NumericUpDown();
        widthLabel = new Label();
        width = new NumericUpDown();
        heightLabel = new Label();
        height = new NumericUpDown();
        declaredValueLabel = new Label();
        declaredValue = new NumericUpDown();
        deliveryPriceLabel = new Label();
        deliveryPrice = new NumericUpDown();
        footer = new Panel();
        save = new Button();
        mainPanel.SuspendLayout();
        senderSection.SuspendLayout();
        recipientSection.SuspendLayout();
        parcelSection.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)weight).BeginInit();
        ((System.ComponentModel.ISupportInitialize)length).BeginInit();
        ((System.ComponentModel.ISupportInitialize)width).BeginInit();
        ((System.ComponentModel.ISupportInitialize)height).BeginInit();
        ((System.ComponentModel.ISupportInitialize)declaredValue).BeginInit();
        ((System.ComponentModel.ISupportInitialize)deliveryPrice).BeginInit();
        footer.SuspendLayout();
        SuspendLayout();
        // 
        // mainPanel
        // 
        mainPanel.AutoScroll = true;
        mainPanel.BackColor = Color.FromArgb(246, 249, 248);
        mainPanel.Controls.Add(senderSection);
        mainPanel.Controls.Add(recipientSection);
        mainPanel.Controls.Add(parcelSection);
        mainPanel.Dock = DockStyle.Fill;
        mainPanel.Location = new Point(0, 0);
        mainPanel.Name = "mainPanel";
        mainPanel.Padding = new Padding(18);
        mainPanel.Size = new Size(1340, 834);
        mainPanel.TabIndex = 0;
        // 
        // senderSection
        // 
        senderSection.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        senderSection.BackColor = Color.White;
        senderSection.Controls.Add(senderBadge);
        senderSection.Controls.Add(senderHeading);
        senderSection.Controls.Add(senderDescription);
        senderSection.Controls.Add(senderLabel);
        senderSection.Controls.Add(senderName);
        senderSection.Location = new Point(18, 18);
        senderSection.Name = "senderSection";
        senderSection.Size = new Size(1300, 144);
        senderSection.TabIndex = 0;
        // 
        // senderBadge
        // 
        senderBadge.BackColor = Color.FromArgb(231, 244, 240);
        senderBadge.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        senderBadge.ForeColor = Color.FromArgb(0, 119, 105);
        senderBadge.Location = new Point(22, 22);
        senderBadge.Name = "senderBadge";
        senderBadge.Size = new Size(36, 34);
        senderBadge.TabIndex = 0;
        senderBadge.Text = "01";
        senderBadge.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // senderHeading
        // 
        senderHeading.AutoSize = true;
        senderHeading.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        senderHeading.ForeColor = Color.FromArgb(32, 49, 57);
        senderHeading.Location = new Point(72, 20);
        senderHeading.Name = "senderHeading";
        senderHeading.Size = new Size(108, 23);
        senderHeading.TabIndex = 1;
        senderHeading.Text = "Відправник";
        // 
        // senderDescription
        // 
        senderDescription.AutoSize = true;
        senderDescription.Font = new Font("Segoe UI", 8F);
        senderDescription.ForeColor = Color.FromArgb(126, 145, 153);
        senderDescription.Location = new Point(72, 46);
        senderDescription.Name = "senderDescription";
        senderDescription.Size = new Size(158, 19);
        senderDescription.TabIndex = 2;
        senderDescription.Text = "Хто відправляє посилку";
        // 
        // senderLabel
        // 
        senderLabel.AutoSize = true;
        senderLabel.Font = new Font("Segoe UI", 9F);
        senderLabel.ForeColor = Color.FromArgb(53, 73, 82);
        senderLabel.Location = new Point(246, 16);
        senderLabel.Name = "senderLabel";
        senderLabel.Size = new Size(170, 20);
        senderLabel.TabIndex = 3;
        senderLabel.Text = "ПІБ / Назва організації";
        // 
        // senderName
        // 
        senderName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        senderName.Font = new Font("Segoe UI", 10F);
        senderName.Location = new Point(246, 42);
        senderName.MaximumSize = new Size(560, 0);
        senderName.Name = "senderName";
        senderName.PlaceholderText = "Наприклад, Анна Мельник";
        senderName.Size = new Size(470, 30);
        senderName.TabIndex = 4;
        // 
        // recipientSection
        // 
        recipientSection.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        recipientSection.BackColor = Color.White;
        recipientSection.Controls.Add(recipientBadge);
        recipientSection.Controls.Add(recipientHeading);
        recipientSection.Controls.Add(recipientDescription);
        recipientSection.Controls.Add(recipientLabel);
        recipientSection.Controls.Add(recipientName);
        recipientSection.Location = new Point(18, 174);
        recipientSection.Name = "recipientSection";
        recipientSection.Size = new Size(1300, 144);
        recipientSection.TabIndex = 1;
        // 
        // recipientBadge
        // 
        recipientBadge.BackColor = Color.FromArgb(231, 244, 240);
        recipientBadge.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        recipientBadge.ForeColor = Color.FromArgb(0, 119, 105);
        recipientBadge.Location = new Point(22, 22);
        recipientBadge.Name = "recipientBadge";
        recipientBadge.Size = new Size(36, 34);
        recipientBadge.TabIndex = 0;
        recipientBadge.Text = "02";
        recipientBadge.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // recipientHeading
        // 
        recipientHeading.AutoSize = true;
        recipientHeading.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        recipientHeading.ForeColor = Color.FromArgb(32, 49, 57);
        recipientHeading.Location = new Point(72, 20);
        recipientHeading.Name = "recipientHeading";
        recipientHeading.Size = new Size(104, 23);
        recipientHeading.TabIndex = 1;
        recipientHeading.Text = "Отримувач";
        // 
        // recipientDescription
        // 
        recipientDescription.AutoSize = true;
        recipientDescription.Font = new Font("Segoe UI", 8F);
        recipientDescription.ForeColor = Color.FromArgb(126, 145, 153);
        recipientDescription.Location = new Point(72, 46);
        recipientDescription.Name = "recipientDescription";
        recipientDescription.Size = new Size(165, 19);
        recipientDescription.TabIndex = 2;
        recipientDescription.Text = "Кому доставити посилку";
        // 
        // recipientLabel
        // 
        recipientLabel.AutoSize = true;
        recipientLabel.Font = new Font("Segoe UI", 9F);
        recipientLabel.ForeColor = Color.FromArgb(53, 73, 82);
        recipientLabel.Location = new Point(246, 16);
        recipientLabel.Name = "recipientLabel";
        recipientLabel.Size = new Size(170, 20);
        recipientLabel.TabIndex = 3;
        recipientLabel.Text = "ПІБ / Назва організації";
        // 
        // recipientName
        // 
        recipientName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        recipientName.Font = new Font("Segoe UI", 10F);
        recipientName.Location = new Point(246, 42);
        recipientName.MaximumSize = new Size(560, 0);
        recipientName.Name = "recipientName";
        recipientName.PlaceholderText = "Наприклад, Олена Коваль";
        recipientName.Size = new Size(470, 30);
        recipientName.TabIndex = 4;
        // 
        // parcelSection
        // 
        parcelSection.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        parcelSection.BackColor = Color.White;
        parcelSection.Controls.Add(parcelBadge);
        parcelSection.Controls.Add(parcelHeading);
        parcelSection.Controls.Add(parcelDescription);
        parcelSection.Controls.Add(contentLabel);
        parcelSection.Controls.Add(parcelContent);
        parcelSection.Controls.Add(deliveryTypeLabel);
        parcelSection.Controls.Add(deliveryType);
        parcelSection.Controls.Add(weightLabel);
        parcelSection.Controls.Add(weight);
        parcelSection.Controls.Add(lengthLabel);
        parcelSection.Controls.Add(length);
        parcelSection.Controls.Add(widthLabel);
        parcelSection.Controls.Add(width);
        parcelSection.Controls.Add(heightLabel);
        parcelSection.Controls.Add(height);
        parcelSection.Controls.Add(declaredValueLabel);
        parcelSection.Controls.Add(declaredValue);
        parcelSection.Controls.Add(deliveryPriceLabel);
        parcelSection.Controls.Add(deliveryPrice);
        parcelSection.Location = new Point(18, 330);
        parcelSection.Name = "parcelSection";
        parcelSection.Size = new Size(1300, 434);
        parcelSection.TabIndex = 2;
        // 
        // parcelBadge
        // 
        parcelBadge.BackColor = Color.FromArgb(231, 244, 240);
        parcelBadge.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        parcelBadge.ForeColor = Color.FromArgb(0, 119, 105);
        parcelBadge.Location = new Point(22, 22);
        parcelBadge.Name = "parcelBadge";
        parcelBadge.Size = new Size(36, 34);
        parcelBadge.TabIndex = 0;
        parcelBadge.Text = "03";
        parcelBadge.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // parcelHeading
        // 
        parcelHeading.AutoSize = true;
        parcelHeading.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        parcelHeading.ForeColor = Color.FromArgb(32, 49, 57);
        parcelHeading.Location = new Point(72, 20);
        parcelHeading.Name = "parcelHeading";
        parcelHeading.Size = new Size(126, 23);
        parcelHeading.TabIndex = 1;
        parcelHeading.Text = "Відправлення";
        // 
        // parcelDescription
        // 
        parcelDescription.AutoSize = true;
        parcelDescription.Font = new Font("Segoe UI", 8F);
        parcelDescription.ForeColor = Color.FromArgb(126, 145, 153);
        parcelDescription.Location = new Point(72, 46);
        parcelDescription.Name = "parcelDescription";
        parcelDescription.Size = new Size(151, 19);
        parcelDescription.TabIndex = 2;
        parcelDescription.Text = "Параметри та вартість";
        // 
        // contentLabel
        // 
        contentLabel.AutoSize = true;
        contentLabel.Font = new Font("Segoe UI", 9F);
        contentLabel.ForeColor = Color.FromArgb(53, 73, 82);
        contentLabel.Location = new Point(246, 16);
        contentLabel.Name = "contentLabel";
        contentLabel.Size = new Size(146, 20);
        contentLabel.TabIndex = 3;
        contentLabel.Text = "Вміст відправлення";
        // 
        // parcelContent
        // 
        parcelContent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        parcelContent.Font = new Font("Segoe UI", 10F);
        parcelContent.Location = new Point(246, 42);
        parcelContent.Multiline = true;
        parcelContent.Name = "parcelContent";
        parcelContent.PlaceholderText = "Опишіть вміст";
        parcelContent.Size = new Size(1020, 64);
        parcelContent.TabIndex = 4;
        // 
        // deliveryTypeLabel
        // 
        deliveryTypeLabel.AutoSize = true;
        deliveryTypeLabel.Font = new Font("Segoe UI", 9F);
        deliveryTypeLabel.ForeColor = Color.FromArgb(53, 73, 82);
        deliveryTypeLabel.Location = new Point(246, 132);
        deliveryTypeLabel.Name = "deliveryTypeLabel";
        deliveryTypeLabel.Size = new Size(101, 20);
        deliveryTypeLabel.TabIndex = 5;
        deliveryTypeLabel.Text = "Тип доставки";
        // 
        // deliveryType
        // 
        deliveryType.DropDownStyle = ComboBoxStyle.DropDownList;
        deliveryType.Font = new Font("Segoe UI", 10F);
        deliveryType.FormattingEnabled = true;
        deliveryType.Items.AddRange(new object[] { "Відділення", "Кур'єр", "Експрес-кур'єр" });
        deliveryType.Location = new Point(246, 158);
        deliveryType.Name = "deliveryType";
        deliveryType.Size = new Size(470, 31);
        deliveryType.TabIndex = 6;
        // 
        // weightLabel
        // 
        weightLabel.AutoSize = true;
        weightLabel.Font = new Font("Segoe UI", 9F);
        weightLabel.ForeColor = Color.FromArgb(53, 73, 82);
        weightLabel.Location = new Point(746, 132);
        weightLabel.Name = "weightLabel";
        weightLabel.Size = new Size(60, 20);
        weightLabel.TabIndex = 7;
        weightLabel.Text = "Вага, кг";
        // 
        // weight
        // 
        weight.DecimalPlaces = 2;
        weight.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
        weight.Location = new Point(746, 158);
        weight.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        weight.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
        weight.Name = "weight";
        weight.Size = new Size(480, 27);
        weight.TabIndex = 8;
        weight.ThousandsSeparator = true;
        weight.Value = new decimal(new int[] { 1, 0, 0, 131072 });
        // 
        // lengthLabel
        // 
        lengthLabel.AutoSize = true;
        lengthLabel.Font = new Font("Segoe UI", 9F);
        lengthLabel.ForeColor = Color.FromArgb(53, 73, 82);
        lengthLabel.Location = new Point(246, 210);
        lengthLabel.Name = "lengthLabel";
        lengthLabel.Size = new Size(98, 20);
        lengthLabel.TabIndex = 9;
        lengthLabel.Text = "Довжина, см";
        // 
        // length
        // 
        length.Location = new Point(246, 236);
        length.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        length.Name = "length";
        length.Size = new Size(470, 27);
        length.TabIndex = 10;
        // 
        // widthLabel
        // 
        widthLabel.AutoSize = true;
        widthLabel.Font = new Font("Segoe UI", 9F);
        widthLabel.ForeColor = Color.FromArgb(53, 73, 82);
        widthLabel.Location = new Point(746, 210);
        widthLabel.Name = "widthLabel";
        widthLabel.Size = new Size(92, 20);
        widthLabel.TabIndex = 11;
        widthLabel.Text = "Ширина, см";
        // 
        // width
        // 
        width.Location = new Point(746, 236);
        width.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        width.Name = "width";
        width.Size = new Size(480, 27);
        width.TabIndex = 12;
        // 
        // heightLabel
        // 
        heightLabel.AutoSize = true;
        heightLabel.Font = new Font("Segoe UI", 9F);
        heightLabel.ForeColor = Color.FromArgb(53, 73, 82);
        heightLabel.Location = new Point(246, 286);
        heightLabel.Name = "heightLabel";
        heightLabel.Size = new Size(82, 20);
        heightLabel.TabIndex = 13;
        heightLabel.Text = "Висота, см";
        // 
        // height
        // 
        height.Location = new Point(246, 312);
        height.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        height.Name = "height";
        height.Size = new Size(470, 27);
        height.TabIndex = 14;
        // 
        // declaredValueLabel
        // 
        declaredValueLabel.AutoSize = true;
        declaredValueLabel.Font = new Font("Segoe UI", 9F);
        declaredValueLabel.ForeColor = Color.FromArgb(53, 73, 82);
        declaredValueLabel.Location = new Point(746, 286);
        declaredValueLabel.Name = "declaredValueLabel";
        declaredValueLabel.Size = new Size(164, 20);
        declaredValueLabel.TabIndex = 15;
        declaredValueLabel.Text = "Оголошена цінність, ₴";
        // 
        // declaredValue
        // 
        declaredValue.DecimalPlaces = 2;
        declaredValue.Location = new Point(746, 312);
        declaredValue.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
        declaredValue.Name = "declaredValue";
        declaredValue.Size = new Size(480, 27);
        declaredValue.TabIndex = 16;
        // 
        // deliveryPriceLabel
        // 
        deliveryPriceLabel.AutoSize = true;
        deliveryPriceLabel.Font = new Font("Segoe UI", 9F);
        deliveryPriceLabel.ForeColor = Color.FromArgb(53, 73, 82);
        deliveryPriceLabel.Location = new Point(246, 366);
        deliveryPriceLabel.Name = "deliveryPriceLabel";
        deliveryPriceLabel.Size = new Size(147, 20);
        deliveryPriceLabel.TabIndex = 17;
        deliveryPriceLabel.Text = "Вартість доставки, ₴";
        deliveryPriceLabel.Visible = false;
        // 
        // deliveryPrice
        // 
        deliveryPrice.DecimalPlaces = 2;
        deliveryPrice.Location = new Point(246, 392);
        deliveryPrice.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
        deliveryPrice.Name = "deliveryPrice";
        deliveryPrice.Size = new Size(470, 27);
        deliveryPrice.TabIndex = 18;
        deliveryPrice.Visible = false;
        // 
        // footer
        // 
        footer.BackColor = Color.FromArgb(246, 249, 248);
        footer.Controls.Add(save);
        footer.Dock = DockStyle.Bottom;
        footer.Location = new Point(0, 834);
        footer.Name = "footer";
        footer.Padding = new Padding(18, 8, 28, 12);
        footer.Size = new Size(1340, 66);
        footer.TabIndex = 1;
        // 
        // save
        // 
        save.BackColor = Color.FromArgb(0, 119, 105);
        save.Dock = DockStyle.Right;
        save.FlatAppearance.BorderSize = 0;
        save.FlatStyle = FlatStyle.Flat;
        save.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        save.ForeColor = Color.White;
        save.Location = new Point(1107, 8);
        save.Name = "save";
        save.Size = new Size(205, 46);
        save.TabIndex = 0;
        save.Text = "Створити відправлення";
        save.UseVisualStyleBackColor = false;
        save.Click += Save_Click;
        // 
        // PostingEditor
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(246, 249, 248);
        ClientSize = new Size(1340, 900);
        Controls.Add(mainPanel);
        Controls.Add(footer);
        Font = new Font("Segoe UI", 9F);
        MinimumSize = new Size(900, 700);
        Name = "PostingEditor";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Нове відправлення";
        mainPanel.ResumeLayout(false);
        senderSection.ResumeLayout(false);
        senderSection.PerformLayout();
        recipientSection.ResumeLayout(false);
        recipientSection.PerformLayout();
        parcelSection.ResumeLayout(false);
        parcelSection.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)weight).EndInit();
        ((System.ComponentModel.ISupportInitialize)length).EndInit();
        ((System.ComponentModel.ISupportInitialize)width).EndInit();
        ((System.ComponentModel.ISupportInitialize)height).EndInit();
        ((System.ComponentModel.ISupportInitialize)declaredValue).EndInit();
        ((System.ComponentModel.ISupportInitialize)deliveryPrice).EndInit();
        footer.ResumeLayout(false);
        ResumeLayout(false);
    }
}
