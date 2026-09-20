using PostService.CommonTypes;
using PostService.DataAccess;
using PostService.Models;

namespace PostService.Services;

public class PostingService: IPostingService
{
    private readonly IPostingRepository _repository;
    public PostingService(IPostingRepository repository)
    {
        _repository = repository;
    }

    public Posting Create(Posting newPosting)
    {
        newPosting.Price = CalculatePrice(
            newPosting.Weight,
            newPosting.DeliveryType);

        newPosting.CreatedAt = DateTime.UtcNow;

        var postingId = _repository.Create(newPosting);

        newPosting.Id = postingId;

        return newPosting;
    }

    public int Delete(int postingId) =>
        _repository.Delete(postingId);

    public Posting? Find(int postingId) =>
        _repository.GetById(postingId);

    public List<Posting> GetAll() => 
        _repository.GetList();

    public Posting? Update(Posting posting)
    {
        var existingPosting = _repository.GetById(posting.Id);

        if (existingPosting == null)
        {
            return null;
        }

        _repository.Update(posting);

        return posting;
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
