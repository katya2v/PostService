(() => {
  const apiUrl = "http://localhost:5085";
  const form = document.querySelector("#posting-form");
  if (!form) return;

  const params = new URLSearchParams(window.location.search);
  const rawId = params.get("id");
  const editingId = rawId === null ? null : Number(rawId);
  const isEditing = editingId !== null && Number.isInteger(editingId) && editingId > 0;
  const title = document.querySelector("#page-title");
  const description = document.querySelector("#page-description");
  const saveButton = document.querySelector("#save-posting");
  const formNotice = document.querySelector("#form-notice");
  const editOnly = [...form.querySelectorAll(".edit-only")];
  const submitLabel = isEditing ? "Зберегти зміни" : "Створити відправлення";

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
      throw new Error(response.status === 404 ? "Відправлення не знайдено." : `Сервер повернув помилку ${response.status}${response.statusText ? ` — ${response.statusText}` : ""}.`);
    }
    if (response.status === 204) return null;
    return response.json();
  }

  function setNotice(message) {
    formNotice.textContent = message;
    formNotice.hidden = false;
  }

  function clearNotice() {
    formNotice.textContent = "";
    formNotice.hidden = true;
  }

  function clearValidation() {
    form.querySelectorAll(".field").forEach((field) => {
      field.classList.remove("invalid");
      field.querySelector(".field-error").textContent = "";
      field.querySelector("input,textarea,select").removeAttribute("aria-invalid");
    });
    clearNotice();
  }

  function setFieldError(input, message) {
    const field = input.closest(".field");
    field.classList.add("invalid");
    field.querySelector(".field-error").textContent = message;
    input.setAttribute("aria-invalid", "true");
  }

  function validateForm() {
    clearValidation();
    let firstInvalid = null;
    const requireValue = (name, message, isValid = (value) => value.trim() !== "") => {
      const input = form.elements.namedItem(name);
      if (!isValid(input.value)) {
        setFieldError(input, message);
        firstInvalid ??= input;
      }
    };

    requireValue("from", "Вкажіть відправника.");
    requireValue("to", "Вкажіть отримувача.");
    requireValue("content", "Вкажіть вміст відправлення.");
    requireValue("deliveryType", "Оберіть тип доставки.", (value) => ["0", "1", "2"].includes(value));
    requireValue("weight", "Вага має бути від 0,01 до 1 000 кг.", (value) => Number(value) >= 0.01 && Number(value) <= 1000 && Number.isInteger(Number(value) * 100));
    for (const [name, label] of [["depth", "Довжина"], ["width", "Ширина"], ["height", "Висота"]]) {
      requireValue(name, `${label} має бути від 1 до 10 000 см.`, (value) => Number.isInteger(Number(value)) && Number(value) >= 1 && Number(value) <= 10000);
    }
    for (const name of ["value", "price"]) {
      const input = form.elements.namedItem(name);
      if (input.closest(".field").hidden || !input.value) continue;
      if (!Number.isFinite(Number(input.value)) || Number(input.value) < 0 || Number(input.value) > 10000000 || !Number.isInteger(Number(input.value) * 100)) {
        setFieldError(input, "Вкажіть суму від 0 до 10 000 000 грн (до 2 знаків після коми).");
        firstInvalid ??= input;
      }
    }

    firstInvalid?.focus();
    return firstInvalid === null;
  }

  function populate(item) {
    for (const [name, value] of Object.entries({
      from: item.from,
      to: item.to,
      content: item.content,
      deliveryType: item.deliveryType,
      weight: item.weight,
      depth: item.depth,
      width: item.width,
      height: item.height,
      value: item.value ?? 0,
      price: item.price ?? 0
    })) {
      form.elements.namedItem(name).value = String(value);
    }
  }

  async function loadPosting() {
    if (rawId !== null && !isEditing) {
      setNotice("Некоректний ID відправлення.");
      saveButton.disabled = true;
      return;
    }
    if (!isEditing) return;

    title.textContent = `Редагування відправлення №${editingId}`;
    description.textContent = "Змініть параметри та збережіть оновлення.";
    saveButton.innerHTML = 'Зберегти зміни <span aria-hidden="true">→</span>';
    editOnly.forEach((field) => { field.hidden = false; });
    saveButton.disabled = true;
    saveButton.textContent = "Завантажуємо…";
    try {
      const item = await request(`/postings/${editingId}`);
      populate(item);
      saveButton.disabled = false;
      saveButton.innerHTML = 'Зберегти зміни <span aria-hidden="true">→</span>';
    } catch (error) {
      setNotice(error.message);
      saveButton.disabled = true;
    }
  }

  async function savePosting(event) {
    event.preventDefault();
    if (!validateForm()) return;

    const data = new FormData(form);
    const payload = {
      from: data.get("from").trim(),
      to: data.get("to").trim(),
      content: data.get("content").trim(),
      deliveryType: Number(data.get("deliveryType")),
      weight: Number(data.get("weight")),
      width: Number(data.get("width")),
      height: Number(data.get("height")),
      depth: Number(data.get("depth")),
      value: data.get("value") ? Number(data.get("value")) : 0
    };
    if (isEditing) payload.price = data.get("price") ? Number(data.get("price")) : 0;

    saveButton.disabled = true;
    saveButton.classList.add("is-saving");
    saveButton.textContent = "Зберігаємо…";
    try {
      await request(isEditing ? `/postings/${editingId}` : "/postings", {
        method: isEditing ? "PUT" : "POST",
        body: JSON.stringify(payload)
      });
      sessionStorage.setItem("postingNotice", isEditing ? "Зміни успішно збережено." : "Відправлення успішно створено.");
      window.location.assign("postings.html");
    } catch (error) {
      setNotice(error.message);
      saveButton.disabled = false;
      saveButton.classList.remove("is-saving");
      saveButton.innerHTML = `${submitLabel} <span aria-hidden="true">→</span>`;
    }
  }

  form.querySelectorAll("input,textarea,select").forEach((input) => input.addEventListener(input.tagName === "SELECT" ? "change" : "input", () => {
    if (!input.closest(".field").classList.contains("invalid")) return;
    input.closest(".field").classList.remove("invalid");
    input.closest(".field").querySelector(".field-error").textContent = "";
    input.removeAttribute("aria-invalid");
  }));
  form.addEventListener("submit", savePosting);

  if (!isEditing) editOnly.forEach((field) => { field.hidden = true; });
  loadPosting();
})();
