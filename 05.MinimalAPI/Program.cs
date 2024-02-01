using API.DTOs;
using API.Entities;
using API.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IGamesRepository, InMemGamesRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


var group = app.MapGroup("/game")
                     .WithParameterValidation()
                     .WithTags("Game")
                     .WithOpenApi();

group.MapGet("/", async (IGamesRepository repository) =>
{
    return Results.Ok(await repository.GetAllAsync());
}).WithName("GetGame")
  .WithOpenApi()
  .WithDescription("Gets all available games");

group.MapGet("{id}", async Task<Results<Ok<Game>, NotFound>> (IGamesRepository repository, int id) =>
{
    Game game = await repository.GetAsync(id);

    return game is not null ? TypedResults.Ok(game) : TypedResults.NotFound();
}).WithName("GetGameById")
  .WithOpenApi();

group.MapPost("", (IGamesRepository repository, CreateGameDto gameDto) =>
{
    Game game = new()
    {
        Name = gameDto.Name,
        Genre = gameDto.Genre,
        Price = gameDto.Price,
        ReleaseDate = gameDto.ReleaseDate,
        ImageUri = gameDto.ImageUri
    };

    repository.CreateAsync(game);

    return Results.CreatedAtRoute("GetGame", new { id = game.Id }, game);
}).WithOpenApi();

group.MapPut("{id}", async (IGamesRepository repository, int id, UpdateGameDto updatedGameDto) =>
{
    Game game = await repository.GetAsync(id);

    if (game is null)
        return Results.NotFound();

    game.Name = updatedGameDto.Name;
    game.Genre = updatedGameDto.Genre;
    game.Price = updatedGameDto.Price;
    game.ReleaseDate = updatedGameDto.ReleaseDate;
    game.ImageUri = updatedGameDto.ImageUri;

    await repository.UpdateAsync(game);

    return Results.NoContent();
}).WithOpenApi();

group.MapDelete("{id}", async (IGamesRepository repository, int id) =>
{
    Game game = await repository.GetAsync(id);

    if (game is null)
    {
        return Results.NotFound();
    }

    await repository.DeleteAsync(id);

    return Results.NoContent();
}).WithOpenApi();

app.Run();
