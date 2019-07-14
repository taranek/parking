namespace ParkingApp.Domain.Validators
{
    public interface IValidator
    {
        bool ValidateBeforeCreate();
        bool ValidateBeforeEdit();
        bool ValidateBeforeDelete();
    }
}
