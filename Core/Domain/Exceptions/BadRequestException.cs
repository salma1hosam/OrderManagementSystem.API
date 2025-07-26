namespace Domain.Exceptions
{
    public sealed class BadRequestException(List<string> errors) : Exception()
    {
        public List<string> Errors { get; } = errors;
    }
}
