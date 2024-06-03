using System.Runtime.ConstrainedExecution;
using System.Text;

namespace AssessmentOfAcceleratedAgingOfTheHumanBody1.Models.User
{
    public class ResultsModel
    {
        public Guid? Id { get; set; }
        public AccountModel? AccauntId { get; set; }
        public string? CreatedAt { get; set; }
        public double BodyMassIndex { get; set; }
        public string? BloodPressure { get; set; }
        public double WaistCircumference { get; set; }
        public int HeartRate { get; set; }
        public int SleepTime { get; set;}
        public bool CircadianRhythms { get; set; }
        public int NumberOfHoursSitting { get; set; }
        public int NumberOfCigarettesSmokedPerDay { get; set; }
        public int AmountOfAlcoholDrunkPerDay {  get; set; }
        public int NumberOfMeals {  get; set; }
        public int ResultsOfTheQualityOfLifeQuestionnaire { get; set; }
        public int ResultsOfThePTSDQuestionnaire { get; set; }
        public string? ResultOfDiagnostic { get; set; }
    }
}
