using System.Collections.Generic;

namespace Assets.Code.Model
{
    public class Module
    {
        public string Name { get; set; }
        
        public float ModuleWeighting { get; set; }

        public List<ModuleComponent> ModuleComponentList { get; set; }
        
        public bool IgnoreComponents { get; set; }
        public float ModuleGrade { get; set; }

        public Module()
        {
            ModuleComponentList = new List<ModuleComponent>();
        }

        public float GetModuleMarkAcquired()
        {
            if (IgnoreComponents) return ModuleGrade;

            float totalMark = 0;
            foreach (ModuleComponent moduleComponent in ModuleComponentList)
            {
                totalMark += moduleComponent.GetEarnedPercentageTowardsModule();
            }

            return totalMark;
        }

        public float GetYearMarkAcquired()
        {
            float totalMark = GetModuleMarkAcquired();
            return (totalMark / 100) * ModuleWeighting;

        }
    }
}