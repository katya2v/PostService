using PostService.DataAccess;
using PostService.Dtos;
using PostService.Mappings;
using PostService.Models;
using PostService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IPostingRepository, PostingRepository>();

builder.Services.AddScoped<IPostingService, PostingService>();

builder.Services.AddCors(options => options.AddPolicy("AllowAll", policy =>
    policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    foreach (var xmlFile in new[] { "PostService.xml", "PostService.Dtos.xml", "PostService.CommonTypes.xml" })
    {
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        if (File.Exists(xmlPath))
        {
            options.IncludeXmlComments(xmlPath);
        }
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowAll");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    return "Це API поштового клієнта.";
})
.WithName("GetApiInfo")
.WithSummary("Інформація про API")
.WithDescription("Повертає коротке повідомлення про сервіс. Вхідних параметрів немає.")
.WithTags("Сервіс")
.Produces<string>(StatusCodes.Status200OK);

app.MapGet("/postings", (IPostingService postingService) =>
    postingService.GetAll())
.WithName("GetAllPostings")
.WithSummary("Отримати всі відправлення")
.WithDescription("Повертає список поштових відправлень. Вхідних параметрів немає.")
.WithTags("Відправлення")
.Produces<List<PostingGetDto>>(StatusCodes.Status200OK);

app.MapGet("/postings/{id}", (int id, IPostingService
postingService) =>
{
    var posting = postingService.Find(id);

    if (posting == null)
        return Results.NotFound();

    var resultDto = PostingMapper.ToPostiongGetDto(posting);

    return Results.Ok(resultDto);
})
.WithName("GetPostingById")
.WithSummary("Отримати відправлення за ID")
.WithDescription("Параметр маршруту `id` — унікальний ідентифікатор відправлення.")
.WithTags("Відправлення")
.Produces<PostingGetDto>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.MapPost("/postings", (PostingPostDto postDto,
IPostingService postingService) =>
{
    Posting newPosting = PostingMapper.ToPosting(postDto);

    var savedObject = postingService.Create(newPosting);
    var resultDto = PostingMapper.ToPostiongGetDto(savedObject);
    return Results.Created($"/postings/{resultDto.Id}", resultDto);
})
.WithName("CreatePosting")
.WithSummary("Створити відправлення")
.WithDescription("Тіло запиту — JSON-об'єкт `PostingPostDto`. Ціну та дату створення формує сервіс.")
.WithTags("Відправлення")
.Accepts<PostingPostDto>("application/json")
.Produces<PostingGetDto>(StatusCodes.Status201Created);

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
})
.WithName("UpdatePosting")
.WithSummary("Оновити відправлення")
.WithDescription("Параметр маршруту `id` — ідентифікатор відправлення. Тіло запиту — JSON-об'єкт `PostingPutDto` з новими даними.")
.WithTags("Відправлення")
.Accepts<PostingPutDto>("application/json")
.Produces<PostingGetDto>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.MapDelete("/postings/{id}", (int id, IPostingService postingService) =>
{
    if (postingService.Delete(id) == 0)
    {
        return Results.NotFound();
    }

    return Results.NoContent();
})
.WithName("DeletePosting")
.WithSummary("Видалити відправлення")
.WithDescription("Параметр маршруту `id` — ідентифікатор відправлення, яке потрібно видалити.")
.WithTags("Відправлення")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound);

using var scope = app.Services.CreateScope();
var repository = (PostingRepository)scope.ServiceProvider.GetRequiredService<IPostingRepository>();
repository.CreateDb();

app.Run();
