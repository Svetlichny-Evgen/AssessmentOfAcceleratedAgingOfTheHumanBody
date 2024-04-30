using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace AssessmentOfAcceleratedAgingOfTheHumanBody1.Models.Questions
{
    public class QuestionModel
    {
        [Required]
        public string Id { get; set; }
        public string? Text { get; set; }
        public List<OptionsModel>? Options { get; set; }
        [Required(ErrorMessage = "Відповідь на запитання повинна будти обрана")]
        public string? SelectedOption { get; set; }
    }
}
