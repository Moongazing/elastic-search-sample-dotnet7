
using TunahanAliOzturk.ElasticSearch.API.Extensions.ElasticSearch;
using TunahanAliOzturk.ElasticSearch.API.Repositories;
using TunahanAliOzturk.ElasticSearch.API.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddElasticService(builder.Configuration);

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ProductRepository>();


builder.Services.AddScoped<EComerceService>();
builder.Services.AddScoped<ECommerceRepossitory>();

var app = builder.Build();






if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
