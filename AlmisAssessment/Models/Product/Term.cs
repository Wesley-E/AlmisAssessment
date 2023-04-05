using System;

namespace AlmisAssessment.Models.Product
{
    public class Term
    {
        public Period Period { get; }
        
        public Term(Period period)
        {
            Period = period;
        }

        public int NumberOfCompleted(Period investmentPeriod, DateTime fromDate)
        {
            var originalPeriod = new Period((int)Period.Days, (int)Period.Weeks, Period.Months, Period.Years);
            var totalCompletedPeriods = 0;
            while (Period.CompletionDayIndex(fromDate) <= investmentPeriod.CompletionDayIndex(fromDate))
            {
                Period.AddPeriod(originalPeriod);
                totalCompletedPeriods += 1;
            }

            return totalCompletedPeriods;
        }
    }
}