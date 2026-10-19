using PostService.CommonTypes;

namespace PostService.Dtos;

/// <summary>Дані для оновлення поштового відправлення.</summary>
public class PostingPutDto
{
    /// <summary>Ім'я або назва відправника.</summary>
    public string From { get; set; }
    /// <summary>Ім'я або назва отримувача.</summary>
    public string To { get; set; }
    /// <summary>Опис вмісту відправлення.</summary>
    public string Content { get; set; }
    /// <summary>Тип доставки: 0 — відділення, 1 — кур'єр, 2 — експрес-кур'єр.</summary>
    public DeliveryType DeliveryType { get; set; }
    /// <summary>Вага відправлення у кілограмах.</summary>
    public float Weight { get; set; }
    /// <summary>Ширина посилки у сантиметрах.</summary>
    public int Width { get; set; }
    /// <summary>Висота посилки у сантиметрах.</summary>
    public int Height { get; set; }
    /// <summary>Глибина посилки у сантиметрах.</summary>
    public int Depth { get; set; }
    /// <summary>Оголошена цінність у гривнях.</summary>
    public float Value { get; set; }
    /// <summary>Вартість доставки у гривнях.</summary>
    public float Price { get; set; }
}
