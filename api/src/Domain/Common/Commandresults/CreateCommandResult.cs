namespace Domain.Common.CommandResults
{
    public class CreateCommandResult<T>
    {
        public T Id { get; }

        public CreateCommandResult(T id)
        {
            Id = id;
        }
    }
}
