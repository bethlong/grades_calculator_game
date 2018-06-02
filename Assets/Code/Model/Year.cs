using System.Collections.Generic;

namespace Assets.Code.Model
{
    public class Year
    {
        public string Name { get; set; }
        
        public float YearWeighting { get; set; }

        public bool IgnoreModules;
        public float YearGrade;
        public List<Module> ModuleList { get; set; }

        public Year()
        {
            ModuleList = new List<Module>();
        }

        public float GetTotalGrade()
        {
            if (IgnoreModules) return YearGrade;
            
            float totalGrade = 0;
            foreach (Module module in ModuleList)
            {
                totalGrade += module.GetYearMarkAcquired();
            }

            return totalGrade;
        }
    }
}