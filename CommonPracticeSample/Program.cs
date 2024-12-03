using CommonPracticeSample.Hubs;

namespace CommonPracticeSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSignalR();

            var app = builder.Build();

            app.MapHub<ChatHub>("/chatHub");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapHub<ChatHub>("/chat");

            app.Run();
        }
    }
}
