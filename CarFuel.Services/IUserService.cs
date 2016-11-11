namespace CarFuel.Services {
    public interface IUserService {

        bool IsLoggedIn();
        string CurrentUserId();
    }
}