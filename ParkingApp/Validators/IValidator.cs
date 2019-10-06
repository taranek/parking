namespace ParkingApp.Domain.Validators
{
    public interface IValidator<T>
    {
        bool ValidateBeforeCreate( T entity);
        bool ValidateBeforeEdit(T id);
        bool ValidateBeforeDelete(T id);
    }
}
