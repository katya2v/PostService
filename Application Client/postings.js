(() => {
  const apiUrl = "http://localhost:5085";
  const body = document.querySelector("#postings-body");
  if (!body) return;

  const notice = document.querySelector("#notice");
  const deliveryNames = ["Відділення", "Кур'єр", "Експрес-кур'єр"];
  let postings = [];
  let selectedId = null;

  const escapeHtml = (value) => String(value ?? "").replace(/[&<>"']/g, (char) => ({ "&": "&amp;", "<": "&lt;", ">": "&gt;", '"': "&quot;", "'": "&#39;" })[char]);
  const formatNumber = (value, digits = 2) => Number(value || 0).toLocaleString("uk-UA", { minimumFractionDigits: 0, maximumFractionDigits: digits });
  const formatMoney = (value) => `${formatNumber(value, 2)} ₴`;
  const formatDate = (value) => {
    if (!value) return "—";
    const date = new Date(value);
    return Number.isNaN(date.valueOf()) ? "—" : new Intl.DateTimeFormat("uk-UA", { day: "2-digit", month: "short", year: "numeric" }).format(date);
  };
  const deliveryName = (value) => deliveryNames[Number(value)] ?? "Не вказано";

  async function request(path, options = {}) {
    let response;
    try {
      response = await fetch(`${apiUrl}${path}`, {
        ...options,
        headers: { ...(options.body ? { "Content-Type": "application/json" } : {}), ...options.headers }
      });
    } catch {
      throw new Error("Не вдалося з'єднатися з PostService. Перевірте, чи запущений API.");
    }
    if (!response.ok) {
      const message = response.status === 404 ? "Запис не знайдено. Оновіть список." : `Сервер повернув помилку ${response.status}${response.statusText ? ` — ${response.statusText}` : ""}.`;
      throw new Error(message);
    }
    if (response.status === 204) return null;
    return response.json();
  }

  function showNotice(message, kind = "error") {
    notice.textContent = message;
    notice.className = `notice ${kind}`;
    notice.hidden = false;
  }

  function render() {
    const count = postings.length;
    const noun = count === 1 || count % 10 === 1 && count % 100 !== 11 ? "відправлення" : count % 10 >= 2 && count % 10 <= 4 && (count % 100 < 12 || count % 100 > 14) ? "відправлення" : "відправлень";
    document.querySelector("#list-count").textContent = `${count} ${noun}`;
    document.querySelector("#list-footer-count").textContent = `Показано ${count}`;

    if (!count) {
      body.innerHTML = '<tr><td colspan="8"><div class="empty-state"><span class="empty-icon">＋</span><b>Відправлень поки немає</b><p>Створіть перше відправлення, щоб воно з’явилося у списку.</p><a class="button button-primary empty-create" href="editor.html">Створити відправлення <span>→</span></a></div></td></tr>';
      return;
    }

    body.innerHTML = postings.map((item) => `
      <tr data-id="${Number(item.id)}" class="${Number(item.id) === Number(selectedId) ? "selected" : ""}">
        <td><span class="posting-id"><span class="row-select" aria-hidden="true"></span>${escapeHtml(item.id)}</span></td>
        <td><span class="recipient-name">${escapeHtml(item.to || "—")}</span></td>
        <td class="cell-muted">${escapeHtml(item.content || "—")}</td>
        <td><span class="delivery-pill">${escapeHtml(deliveryName(item.deliveryType))}</span></td>
        <td class="weight-cell">${formatNumber(item.weight)} кг</td>
        <td>${formatMoney(item.value)}</td>
        <td class="date-cell">${escapeHtml(formatDate(item.createdAt))}</td>
        <td><div class="row-actions"><a class="row-menu edit-row" href="editor.html?id=${encodeURIComponent(item.id)}" title="Редагувати" aria-label="Редагувати ${escapeHtml(item.id)}">✎</a><button class="row-menu delete delete-row" type="button" title="Видалити" aria-label="Видалити ${escapeHtml(item.id)}">×</button></div></td>
      </tr>`).join("");

    body.querySelectorAll("tr[data-id]").forEach((row) => {
      row.addEventListener("click", (event) => {
        if (event.target.closest("button,a")) return;
        selectedId = Number(row.dataset.id);
        render();
      });
      row.querySelector(".delete-row").addEventListener("click", () => deletePosting(Number(row.dataset.id)));
    });
  }

  async function loadPostings() {
    notice.hidden = true;
    body.innerHTML = '<tr><td colspan="8"><div class="table-loading"><span class="spinner"></span> Завантажуємо відправлення…</div></td></tr>';
    try {
      const result = await request("/postings");
      postings = Array.isArray(result) ? result : [];
      render();
    } catch (error) {
      postings = [];
      document.querySelector("#list-count").textContent = "Не вдалося завантажити записи";
      document.querySelector("#list-footer-count").textContent = "—";
      body.innerHTML = '<tr><td colspan="8"><div class="empty-state"><span class="empty-icon">!</span><b>Не вдалося підключитися до PostService</b><p>Перевірте, чи запущений API, та повторіть спробу.</p><button class="button button-primary retry-load" type="button">Спробувати ще раз <span>↻</span></button></div></td></tr>';
      body.querySelector(".retry-load").addEventListener("click", loadPostings);
      showNotice(error.message);
    }
  }

  async function deletePosting(id) {
    const posting = postings.find((item) => Number(item.id) === id);
    if (!posting || !window.confirm(`Видалити відправлення №${id} для «${posting.to}»?`)) return;
    try {
      await request(`/postings/${id}`, { method: "DELETE" });
      if (selectedId === id) selectedId = null;
      await loadPostings();
      showNotice("Відправлення видалено.", "success");
    } catch (error) {
      showNotice(error.message);
    }
  }

  const savedNotice = sessionStorage.getItem("postingNotice");
  if (savedNotice) {
    showNotice(savedNotice, "success");
    sessionStorage.removeItem("postingNotice");
  }
  loadPostings();
})();
