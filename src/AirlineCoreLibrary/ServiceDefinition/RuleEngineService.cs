using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Service;
using AirlineCoreLibrary.Utility;
using Newtonsoft.Json;
using RulesEngine.Extensions;
using RulesEngine.Models;

namespace AirlineCoreLibrary.ServiceDefinition
{
    internal class RuleEngineService : IRuleEngineService
    {
        /// <summary>
        /// ExecuteRuleEngineRequest
        /// </summary>
        /// <param name="ruleEngineRequest"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RuleEngineResponse ExecuteRuleEngineRequest(RuleEngineRequest ruleEngineRequest)
        {
            RuleEngineResponse ruleEngineResponse = new ();
            string reasonCode = string.Empty;

            try
            {
                string rulesFile = CoreConstants.BREWorkFlowPath;
                //var rulesFile = Directory.GetFiles(Directory.GetCurrentDirectory(), "workflowdata.json", SearchOption.AllDirectories).FirstOrDefault();

                if (rulesFile == null || rulesFile.Length == 0)
                {
                    Console.WriteLine("RuleEngineService:ExecuteRuleEngineRequest, Message: Flight compensation eligibility rules not found");
                    throw new Exception("RuleEngineService:ExecuteRuleEngineRequest, Message: Flight compensation eligibility rules not found");
                }

                var RulesFileData = File.ReadAllText(rulesFile);
                #region Workflow Execution
                List<RuleResultTree> resultList = new();
                var workflow = JsonConvert.DeserializeObject<List<Workflow>>(RulesFileData);
                var ruleEngineWF = new RulesEngine.RulesEngine(workflow?.ToArray(), null);
                var ruleParam = new RuleParameter("input", ruleEngineRequest);
                resultList = ruleEngineWF.ExecuteAllRulesAsync(ruleEngineRequest.WorkflowName?.ToLowerInvariant(), ruleParam).Result;
                
                resultList.OnSuccess((successResponse) =>
                {
                    ruleEngineResponse.IsEligible = true;
                    ruleEngineResponse.Compensation = successResponse;
                    ruleEngineResponse.ReasonCode = successResponse;
                    ruleEngineResponse.Remarks = "Success";
                });
                resultList.OnFail(() =>
                {
                    ruleEngineResponse.IsEligible = false;
                    ruleEngineResponse.Compensation = null;
                    ruleEngineResponse.ReasonCode = "Failed";
                    ruleEngineResponse.Remarks = "Failed: Reason code not found for given criteria!";
                });
                #endregion
            }
            catch (Exception ex)
            {
                ruleEngineResponse.ReasonCode = null;
                ruleEngineResponse.Remarks = $"Exception: Something went wrong, please make sure input values and expression are correct!\nError: {ex.Message}";
            }

            if (ruleEngineResponse.ReasonCode == null && ruleEngineRequest.DelayInMinutes >= 100 && ruleEngineRequest.DelayInMinutes <= 300)
            {
                AppLogger.LogWarning($"Message: Delay is between 100 and 300 minutes, so offering Voucher");
                ruleEngineResponse.ReasonCode = "Voucher";
                ruleEngineResponse.Remarks = "Success";
            }

            return ruleEngineResponse;
        }
    }
}
