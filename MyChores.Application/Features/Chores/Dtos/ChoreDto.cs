namespace MyChores.Application.Features.Chores.Dtos
{
    public class ChoreDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool Completed { get; set; }
        public string ChoreOwner { get; set; }
        public string ChoreTaker { get; set; }
        public string DayOfWeek { get; set; }
        public string Recourse { get; set; }
        public string CreatedDate { get; set; }
        public string LastModifiedDate { get; set; }
    }
}
