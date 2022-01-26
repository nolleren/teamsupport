namespace GraphQL.Data.Answers
{
    public record AnswerInput(
        Guid TickedId,
        Guid UserId,
        string Text
    );
}
