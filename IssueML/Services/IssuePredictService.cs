using IssueMLML.Model.DataModels;
using Microsoft.Extensions.Logging;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueML.Services
{
    public interface IIssuePredictService
    {
        IDictionary<string,object> PredictIssueBySement(string str);
    }

    public class IssuePredictService : IIssuePredictService
    {
        private ILogger LOGGER;
        private MLContext mlContext;

        public IssuePredictService(ILogger<IssuePredictService> logger)
        {
            this.LOGGER = logger;
            mlContext = new MLContext();
        }

        public IDictionary<string,object> PredictIssueBySement(string str)
        {
            IDictionary<string, object> dictionary = new Dictionary<string, object>();

            //Load ML Context             

            ITransformer mlModel = mlContext.Model.Load("MLModel.zip", out var modelInputSchema);

            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            // Use the code below to add input data
            var input = new ModelInput();
            input.IssueText = str;

            // Try model on sample data
            // True is Issue, false is non-Issue
            ModelOutput result = predEngine.Predict(input);

            LOGGER.LogInformation($"Text: {input.IssueText} | Prediction: {(Convert.ToBoolean(result.Prediction) ? "Issue" : "Non Issue")} ");
            dictionary["text"] = input.IssueText;
            dictionary["prediction"] = Convert.ToBoolean(result.Prediction) ? "Issue" : "Non Issue";
            dictionary["issue"] = Convert.ToBoolean(result.Prediction);

            //return $"Text: {input.IssueText} | Prediction: {(Convert.ToBoolean(result.Prediction) ? "Issue" : "Non Issue")} ";
            return dictionary;
        }
    }
}
