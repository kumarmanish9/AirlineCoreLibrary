namespace AirlineCoreLibrary.Utility
{
    public class CoreConstants
    {
        public const string ConnectionString = "Server=localhost;Database=FlyingTogether;User=root;Password=Changelife@26;";
        
        public const string EventMessagePath = "D:\\Projects\\.Apps\\FlyingTogether\\EventPublisher";
        public const string BREWorkFlowPath = "D:\\Projects\\BusinessRuleEditor\\src\\BusinessRuleEditor\\wwwroot\\workflowdata\\workflowdata.json";
        
        public const string FlightApi = "https://localhost:7128/Flight";
        public const string PassengerApi = "https://localhost:7128/Passenger";
        public const string? BREApiUrl = "https://localhost:7128/BusinessRuleEngine/Compensation";

        public const string SenderEmail = "xflyingtogether@gmail.com";
        // public const string SenderPass = "I am flying together"; // gmail pass
        public const string SenderPass = "bjol vlhf qdyk eutq";
        public const string SenderHost = "smtp.gmail.com";
        public const int SenderPort = 587;

        public static bool IsParrallExecution = false;
    }

}
