using Application2;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR(); // Adiciona SignalR
builder.Services.AddControllers().AddNewtonsoftJson(); // Adiciona suporte a JSON com Newtonsoft
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configura o pipeline de requisições HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapRazorPages();
app.MapControllers(); // Mapeia os controladores da API
app.MapHub<SyncHub>("/syncHub"); // Mapeia o hub do SignalR

app.Run();
