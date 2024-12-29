using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Service;
using AirlineCoreLibrary.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCoreLibrary.ServiceDefinition
{
    internal class CompensationProcessor(IDatabaseService database, HttpClient httpClient, INotification notification) : ICompensationProcessor
    {
        public async Task ProcessCompensationAsync(Flight? flight, PassengerCompenation? passenger)
        {
            // Prepare BRE compensation request
            RuleEngineRequest request = new()
            {
                EventType = flight?.EventType,
                EventReason = flight?.EventReason,
                IsOvernight = flight?.IsOvernight,
                DelayInMinutes = flight?.DelayInMinutes,

                CabinType = passenger?.CabinType,
                PaxStatus = passenger?.PaxStatus,

                WorkflowName = "CompensationWorkflow"
            };

            // Invoke BRE API
            HttpResponseMessage ruleEngineResponse = await httpClient.PostAsync(
                CoreConstants.BREApiUrl,
                new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            if (ruleEngineResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var message = await ruleEngineResponse.Content.ReadAsStringAsync();
                RuleEngineResponse? ruleEngineResult = JsonConvert.DeserializeObject<RuleEngineResponse>(message);
                if (ruleEngineResult != null && passenger != null)
                {
                    bool isEligible = ruleEngineResult.IsEligible ?? false;
                    // BRE compensation response update in the database
                    passenger.Compensation = ruleEngineResult.Compensation;
                    passenger.IsEligible = isEligible;
                    passenger.CompStatus = isEligible ? nameof(CompStatus.Pending) : nameof(CompStatus.NotEligible);
                    passenger.AgentRemarks = ruleEngineResult.Remarks;
                    
                    await database.UpdatePassengerAsync(passenger);
                }
            }

            // Publish message for notification service
            await notification.SendNotification(passenger);
        }
    }
}
