//*****************************************************************************************
//*                                                                                       *
//* This is an auto-generated file by Microsoft ML.NET CLI (Command-Line Interface) tool. *
//*                                                                                       *
//*****************************************************************************************

using Microsoft.ML.Data;

namespace IssueMLML.Model.DataModels
{
    public class ModelInput
    {
        [ColumnName("Issue"), LoadColumn(0)]
        public bool Issue { get; set; }


        [ColumnName("IssueText"), LoadColumn(1)]
        public string IssueText { get; set; }


    }
}
