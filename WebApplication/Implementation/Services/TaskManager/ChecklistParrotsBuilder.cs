﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using SKBKontur.TaskManagerClient.BusinessObjects.TaskManager;

namespace SKBKontur.Treller.WebApplication.Implementation.Services.TaskManager
{
    public class ChecklistParrotsBuilder : IChecklistParrotsBuilder
    {
        public ParrotsInfoViewModel Build(IEnumerable<CardChecklist> checklists, int daysCount, DateTime? beginDate, DateTime? endDate)
        {
            var result = new ParrotsInfoViewModel();

            foreach (var listItem in checklists.SelectMany(x => x.Items))
            {
                const string floatRegexPattern = @"\d+[.,]?[\d]*";
                var isMatch = Regex.Match(listItem.Description, string.Format(@"\({0}[/,\\]{0}\)$", floatRegexPattern), RegexOptions.IgnoreCase);
                if (isMatch.Success)
                {
                    var matchResult = isMatch.Value.Trim('(', ')').Split('/');

                    var totalCount = matchResult.Length > 1 ? Parse(matchResult[1]) : Parse(matchResult[0]);
                    
                    result.ProgressInfo.TotalCount += totalCount;

                    result.ProgressInfo.CurrentCount += listItem.IsChecked ? totalCount : Parse(matchResult[0]);
                }
                else
                {
                    if (listItem.IsChecked)
                    {
                        result.ProgressInfo.CurrentCount += 1;
                    }
                    result.ProgressInfo.TotalCount += 1;
                }
            }

            result.AverageSpeedInDay = daysCount == 0 ? 0 : result.ProgressInfo.CurrentCount / daysCount;
            result.AverageDaysRemind = (int)(result.AverageSpeedInDay > 0 ? (result.ProgressInfo.TotalCount - result.ProgressInfo.CurrentCount) / result.AverageSpeedInDay : 0);
            result.PastDays = daysCount;
            result.BeginDate = beginDate;
            result.EndDate = endDate;

            return result;
        }

        private static decimal Parse(string value)
        {
            decimal result;
            if (decimal.TryParse(value, NumberStyles.AllowDecimalPoint,
                                 new NumberFormatInfo {NumberDecimalSeparator = "."}, out result)
                ||
                decimal.TryParse(value, NumberStyles.AllowDecimalPoint,
                                 new NumberFormatInfo {NumberDecimalSeparator = ","}, out result))
            {
                return result;
            }

            return 1;
        }
    }
}