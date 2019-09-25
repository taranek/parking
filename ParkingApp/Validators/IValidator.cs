namespace ParkingApp.Domain.Validators
{
    public interface IValidator
    {
        bool ValidateBeforeCreate( int id);
        bool ValidateBeforeEdit(int id);
        bool ValidateBeforeDelete(int id);
    }
}
