using PostService.CommonTypes;
using PostService.Dtos;
using System.Drawing;
using System.Net.Http.Json;

namespace PostService.App;

public partial class PostingEditor : Form
{
    private static readonly HttpClient Client = new() { BaseAddress = new Uri("http://localhost:5085/") };
    private readonly PostingGetDto? posting;
    private readonly Dictionary<Control, Label> validationMessages = new();

    public PostingEditor() : this(null) { }

    public PostingEditor(PostingGetDto? posting)
    {
        this.posting = posting;
        InitializeComponent();
        AddValidationMessage(senderName);
        AddValidationMessage(recipientName);
        AddValidationMessage(parcelContent);
        AddValidationMessage(deliveryType);
        AddValidationMessage(weight);
        AddValidationMessage(length);
        AddValidationMessage(width);
        AddValidationMessage(height);
        Text = posting == null ? "Нове відправлення" : $"Редагування відправлення №{posting.Id}";
        save.Text = posting == null ? "Створити відправлення" : "Зберегти зміни";
        if (posting != null)
        {
            deliveryPriceLabel.Visible = true;
            deliveryPrice.Visible = true;
            Populate(posting);
        }
    }

    private void Populate(PostingGetDto item)
    {
        senderName.Text = item.From;
        recipientName.Text = item.To;
        parcelContent.Text = item.Content;
        deliveryType.SelectedIndex = (int)item.DeliveryType;
        weight.Value = Clamp(weight, (decimal)item.Weight);
        length.Value = Clamp(length, (decimal)item.Depth);
        width.Value = Clamp(width, (decimal)item.Width);
        height.Value = Clamp(height, (decimal)item.Height);
        declaredValue.Value = Clamp(declaredValue, (decimal)(item.Value ?? 0));
        deliveryPrice.Value = Clamp(deliveryPrice, (decimal)item.Price);
    }

    private static decimal Clamp(NumericUpDown control, decimal amount) => Math.Max(control.Minimum, Math.Min(control.Maximum, amount));

    private void AddValidationMessage(Control field)
    {
        var message = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 8F),
            ForeColor = Color.FromArgb(190, 54, 64),
            Location = new Point(field.Left, field.Bottom + 3),
            Name = $"{field.Name}ValidationMessage",
            Visible = false
        };

        field.Parent!.Controls.Add(message);
        message.BringToFront();
        validationMessages.Add(field, message);

        if (field is TextBox textBox) textBox.TextChanged += (_, _) => ClearFieldError(field);
        else if (field is ComboBox comboBox) comboBox.SelectedIndexChanged += (_, _) => ClearFieldError(field);
        else if (field is NumericUpDown numeric) numeric.ValueChanged += (_, _) => ClearFieldError(field);
    }

    private void SetFieldError(Control field, string error)
    {
        var message = validationMessages[field];
        message.Text = error;
        message.Visible = true;
        field.AccessibleDescription = error;
    }

    private void ClearFieldError(Control field)
    {
        var message = validationMessages[field];
        message.Visible = false;
        message.Text = string.Empty;
        field.AccessibleDescription = null;
    }

    private bool ValidateRequiredFields()
    {
        foreach (var field in validationMessages.Keys) ClearFieldError(field);
        Control? firstInvalid = null;

        void RequireText(Control control, string message)
        {
            if (string.IsNullOrWhiteSpace(control.Text))
            {
                SetFieldError(control, message);
                firstInvalid ??= control;
            }
        }

        void RequirePositive(NumericUpDown control, string message)
        {
            if (control.Value <= 0)
            {
                SetFieldError(control, message);
                firstInvalid ??= control;
            }
        }

        RequireText(senderName, "Вкажіть відправника.");
        RequireText(recipientName, "Вкажіть отримувача.");
        RequireText(parcelContent, "Вкажіть вміст відправлення.");

        if (deliveryType.SelectedIndex < 0)
        {
            SetFieldError(deliveryType, "Оберіть тип доставки.");
            firstInvalid ??= deliveryType;
        }

        RequirePositive(weight, "Вага має бути більшою за нуль.");
        RequirePositive(length, "Довжина має бути більшою за нуль.");
        RequirePositive(width, "Ширина має бути більшою за нуль.");
        RequirePositive(height, "Висота має бути більшою за нуль.");

        if (firstInvalid != null)
        {
            firstInvalid.Focus();
            return false;
        }

        return true;
    }

    private async void Save_Click(object? senderObject, EventArgs e)
    {
        if (!ValidateRequiredFields()) return;

        save.Enabled = false;
        try
        {
            HttpResponseMessage response;
            if (posting == null)
            {
                var dto = new PostingPostDto
                {
                    From = senderName.Text.Trim(),
                    To = recipientName.Text.Trim(),
                    Content = parcelContent.Text.Trim(),
                    DeliveryType = (DeliveryType)deliveryType.SelectedIndex,
                    Weight = (float)weight.Value,
                    Width = (int)width.Value,
                    Height = (int)height.Value,
                    Depth = (int)length.Value,
                    Value = (float)declaredValue.Value
                };
                response = await Client.PostAsJsonAsync("postings", dto);
            }
            else
            {
                var dto = new PostingPutDto
                {
                    From = senderName.Text.Trim(),
                    To = recipientName.Text.Trim(),
                    Content = parcelContent.Text.Trim(),
                    DeliveryType = (DeliveryType)deliveryType.SelectedIndex,
                    Weight = (float)weight.Value,
                    Width = (int)width.Value,
                    Height = (int)height.Value,
                    Depth = (int)length.Value,
                    Value = (float)declaredValue.Value,
                    Price = (float)deliveryPrice.Value
                };
                response = await Client.PutAsJsonAsync($"postings/{posting.Id}", dto);
            }

            using (response)
            {
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(this, $"Сервер повернув помилку: {(int)response.StatusCode} {response.ReasonPhrase}", "Не вдалося зберегти", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (HttpRequestException)
        {
            MessageBox.Show(this, "Не вдалося з'єднатися із сервером.", "Помилка з'єднання", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally { save.Enabled = true; }
    }
}
