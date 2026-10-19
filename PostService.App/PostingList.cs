using PostService.Dtos;
using System.Net.Http.Json;

namespace PostService.App
{
    public partial class PostingList : Form
    {
        private readonly HttpClient httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5085/")
        };

        public PostingList()
        {
            InitializeComponent();
        }

        private async void PostingList_Load(object? sender, EventArgs e)
        {
            await LoadPostingsAsync();
        }

        private async Task LoadPostingsAsync()
        {
            try
            {
                var postings = await httpClient.GetFromJsonAsync<PostingGetDto[]>("postings");
                dgvShipments.DataSource = postings ?? Array.Empty<PostingGetDto>();
            }
            catch (HttpRequestException)
            {
                MessageBox.Show(this, "Не вдалося з'єднатися із сервером.", "Помилка з'єднання",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRefresh_Click(object? sender, EventArgs e)
        {
            await LoadPostingsAsync();
        }

        private async void btnCreate_Click(object? sender, EventArgs e)
        {
            using var form = new PostingEditor();
            if (form.ShowDialog(this) == DialogResult.OK)
                await LoadPostingsAsync();
        }

        private async void btnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvShipments.CurrentRow?.DataBoundItem is not PostingGetDto posting)
            {
                MessageBox.Show(this, "Виберіть відправлення для редагування.", "Редагування",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var form = new PostingEditor(posting);
            if (form.ShowDialog(this) == DialogResult.OK)
                await LoadPostingsAsync();
        }

        private async void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvShipments.CurrentRow?.DataBoundItem is not PostingGetDto posting)
            {
                MessageBox.Show(this, "Виберіть відправлення для видалення.", "Видалення",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using var response = await httpClient.DeleteAsync($"postings/{posting.Id}");
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(this, "Сервер не підтвердив видалення відправлення.", "Помилка видалення",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                await LoadPostingsAsync();
            }
            catch (HttpRequestException)
            {
                MessageBox.Show(this, "Не вдалося з'єднатися із сервером.", "Помилка з'єднання",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
