namespace GraphQL.API.Answers
{
    public record AnswerInput(
        Guid TickedId,
        Guid UserId,
        string Text
    );
}
