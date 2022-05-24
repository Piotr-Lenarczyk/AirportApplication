namespace AirportApplication;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)  
    {  
        services.AddControllersWithViews();  
        services.AddRazorPages();  
    } 
}