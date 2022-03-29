
using ConferenceRegistrationAPI;
using ConferenceRegistrationAPI.Adapters.Mongo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ProductsSettings>(builder.Configuration.GetSection(ProductsSettings.SectionName));

builder.Services.AddScoped<IProductsService, ProductsService>();

//Adapters
builder.Services.AddSingleton<MongoProductsAdapter>();

builder.Services.AddHttpClient<MarkupServiceAdapter>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("markupApi"));
}).AddPolicyHandler(HttpPolicies.GetMarkupRetryPolicy());

builder.Services.AddScoped<MarkupServiceAmountPort>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
