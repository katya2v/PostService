using PostService.Dtos;
using PostService.Mappings;
using PostService.Models;
using PostService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IPostingService, PostingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    return "Це API поштового клієнта.";
})
.WithName("PostServiceAPI");

app.MapGet("/postings", (IPostingService postingService) => 
    postingService.GetAll());

app.MapGet("/postings/{id}", (int id, IPostingService
postingService) =>
{ 
    var posting = postingService.Find(id);
    
    if (posting == null)
        return Results.NotFound();
    
    var resultDto = PostingMapper.ToPostiongGetDto(posting);
    
    return Results.Ok(resultDto);
});

app.MapPost("/postings", (PostingPostDto postDto,
IPostingService postingService) =>
{
    Posting newPosting = PostingMapper.ToPosting(postDto);

    var savedObject = postingService.Create(newPosting);
    var resultDto = PostingMapper.ToPostiongGetDto(savedObject);
    return Results.Created($"/postings/{resultDto.Id}", resultDto);
});

app.MapPut("/postings/{id}", (int id, PostingPutDto putDto, IPostingService postingService) =>
{
    var posting = PostingMapper.ToPosting(putDto);

    posting.Id = id;

    var updatedPosting = postingService.Update(posting);

    if (updatedPosting == null)
    {
        return Results.NotFound();
    }

    var resultDto = PostingMapper.ToPostiongGetDto(updatedPosting);
    return Results.Ok(resultDto);
});

app.MapDelete("/postings/{id}", (int id, IPostingService postingService) =>
{
    if(postingService.Delete(id) == 0)
    {
        return Results.NotFound();
    }

    return Results.NoContent();
});

app.Run();
