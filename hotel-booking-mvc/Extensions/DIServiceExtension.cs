using hotel_booking_services.Implmentations;
using hotel_booking_services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace hotel_booking_mvc.Extensions
{
	public static class DIServiceExtension
	{
		public static void ConfigureDependencies(this IServiceCollection services,IConfiguration configuration)
		{
			services.AddSingleton<IHttpRequestFactory, HttpRequestFactory>();
			services.AddScoped<IHotelService, HotelService>();
			services.AddTransient<IAuthenticationService, AuthenticationService>();
			services.AddTransient<IAdminService, AdminService>();
			services.AddScoped<IManagerService, ManagerService>();
		}
	}
}
