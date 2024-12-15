using MediatR;

namespace CoachBuddy.Application.Exercise.Queries.GetExerciseById
{
    public class GetExerciseByIdQuery : IRequest<ExerciseDto>
    {
        public Guid Id { get; set; }
        public GetExerciseByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
