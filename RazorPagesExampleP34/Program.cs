using RazorPagesExampleP34.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IPersonDataProvider, FilePersonDataProvider>();

// Dependency Injection (DI) - Реєстрація служби з різними життєвими циклами
// Singleton - один екземпляр на весь час життя додатку
//builder.Services.AddSingleton<IPersonDataProvider, PersonDataProvider>();
// Scoped - один екземпляр на кожен запит
//builder.Services.AddScoped<IPersonDataProvider, PersonDataProvider>();
// Transient - новий екземпляр при кожному запиті
//builder.Services.AddTransient<IPersonDataProvider, PersonDataProvider>();


// Постійна частина яка слухає з'єднання
// Під кожний запит створюється окремий контекст (HttpContext) та поток для обробки запиту



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


/*
 * Додати можливість додавання, редагування та видалення навичок для кожної особи.
 * 
 * Сторінка список навичок для особи з кнопкою "Додати навичку", 
 * "Редагувати" та "Видалити" поруч з кожною навичкою.
 * 
 * Сторінка створення навички з полями "Назва навички" та "Рівень володіння" (від 0 до 100).
 * 
 * Сторінка редагування навички з можливістю змінити назву та рівень володіння.
 * 
 * 
 * 
 */ 