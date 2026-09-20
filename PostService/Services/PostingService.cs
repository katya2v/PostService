using PostService.Models;

namespace PostService.Services;

public class PostingService: IPostingService
{
    private static List<Posting> _postings = 
        new List<Posting>
        {
            new Posting
            {
                Id = 1,
                From = "Alice",
                To = "Bob",
                Content = "Books",
                DeliveryType = DeliveryType.Courier,
                Weight = 2.5f,
                Width = 30,
                Height = 20,
                Depth = 10,
                Value = 50.0f,
                Price = 10.0f,
                CreatedAt = DateTime.UtcNow
            }
        };

    public Posting Create(Posting newPosting)
    {
        var maxId = 1;
        if (_postings.Count > 0)
{
            maxId = _postings.Max(p => p.Id) + 1;
        }
        newPosting.Id = maxId;

        newPosting.Price = CalculatePrice(
            newPosting.Weight,
            newPosting.DeliveryType);

        newPosting.CreatedAt = DateTime.UtcNow;

        _postings.Add(newPosting);
        return newPosting;
    }

    public int Delete(int postingId)
    {
        var posting = Find(postingId);

        if (posting == null)
        {
            return 0;
        }

        _postings.Remove(posting);

        return 1;
    }

    public Posting? Find(int postingId)
    {
        var posting = _postings.FirstOrDefault(p => p.Id ==
        postingId);
        return posting;
    }

    public List<Posting> GetAll()
    {
        return _postings;
    }

    public Posting? Update(Posting posting)
    {
        var existingPosting = Find(posting.Id);

        if (existingPosting == null)
        {
            return null;
        }

        existingPosting.From = posting.From;
        existingPosting.To = posting.To;
        existingPosting.Content = posting.Content;
        existingPosting.DeliveryType = posting.DeliveryType;
        existingPosting.Weight = posting.Weight;
        existingPosting.Width = posting.Width;
        existingPosting.Height = posting.Height;
        existingPosting.Depth = posting.Depth;
        existingPosting.Value = posting.Value;
        existingPosting.Price = posting.Price;

        return existingPosting;
    }

    private float CalculatePrice(float weight, DeliveryType deliveryType)
    {
        return deliveryType switch
        {
            DeliveryType.Courier => weight * 15,
            DeliveryType.Department => weight * 10,
            DeliveryType.ExpressCourier => weight * 24,
            _ => weight * 10
        };
    }
}
