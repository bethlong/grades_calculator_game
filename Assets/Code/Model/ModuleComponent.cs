namespace Assets.Code.Model
{
    public class ModuleComponent
    {
        public string Name { get; set; }
        public float PercentageWeighting { get; set; }
        public float Mark { get; set; }
        public float MarkOutOf { get; set; }

        public float GetEarnedPercentageTowardsModule()
        {
            return (Mark / MarkOutOf) * PercentageWeighting;
        }
    }
}