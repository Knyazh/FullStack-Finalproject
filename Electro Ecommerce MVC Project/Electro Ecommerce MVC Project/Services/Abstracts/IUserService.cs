namespace Electro_Ecommerce_MVC_Project.Services.Abstracts;

public interface IUserService
{
    bool IsCurrentUserAuthenticated();
    //public User CurrentUser { get; }
}
