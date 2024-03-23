namespace AssessmentOfAcceleratedAgingOfTheHumanBody1.Models.Questions
{
    public class QuestionModel
    {
        public string Id { get; set; }
        public string? Text { get; set; }
        public List<OptionsModel>? Options { get; set; }
        public string? SelectedOption { get; set; }
    }
}
