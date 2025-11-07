using RazorPagesExampleP34.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
if (true)
{
    builder.Services.AddScoped<IPersonDataProvider, FilePersonDataProvider>();
} else
{
    builder.Services.AddScoped<IPersonDataProvider, PersonDataProvider>();
}




    var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();  //  /css/site.css 

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
