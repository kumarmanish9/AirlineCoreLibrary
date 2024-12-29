namespace AirlineCoreLibrary.Model
{
    /// <summary>
    /// RuleEngineRequest
    /// </summary>
    public class RuleEngineRequest
    {
        public string? WorkflowName { get; set; }
        public string? EventType { get; set; }
        public string? EventReason { get; set; }
        public bool? IsOvernight { get; set; }
        public int? DelayInMinutes { get; set; }
        public string? CabinType { get; set; }
        public string? PaxStatus { get; set; }
    }

    /// <summary>
    /// RuleEngineResponse
    /// </summary>
    public class RuleEngineResponse
    {
        /// <summary>
        /// IsEligible
        /// </summary>
        public bool? IsEligible { get; set; }

        /// <summary>
        /// Compensation
        /// </summary>
        public string? Compensation { get; set; }

        /// <summary>
        /// ReasonCode on success event
        /// </summary>
        public string? ReasonCode { get; set; }

        /// <summary>
        /// Remarks: Custome message
        /// </summary>
        public string? Remarks { get; set; }
    }

}
