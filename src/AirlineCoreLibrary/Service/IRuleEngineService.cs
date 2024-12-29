using AirlineCoreLibrary.Model;

namespace AirlineCoreLibrary.Service
{
    /// <summary>
    /// IRuleEngineService : RuleEngineService
    /// </summary>
    public interface IRuleEngineService
    {
        /// <summary>
        /// ExecuteRuleEngineRequest
        /// </summary>
        /// <param name="ruleEngineRequest"></param>
        /// <param name="requestId"></param>
        /// <returns></returns>
        RuleEngineResponse ExecuteRuleEngineRequest(RuleEngineRequest ruleEngineRequest, string requestId);

    }
}
