namespace AirlineCoreLibrary.Utility
{
    public class CoreConstants
    {
        public const string ConnectionString = "Server=localhost;Database=FlyingTogether;User=root;Password=Changelife@26;";
        
        public const string EventMessagePath = "D:\\Projects\\EventStream\\EventPublisher";
        public const string WorkFlowPath = "C:\\Temp\\projects\\compensation\\cp.mvc.businessruleeditor\\src\\cp.mvc.businessruleeditor\\wwwroot\\workflowdata\\workflowdata.json";
        
        public const string FlightApi = "https://localhost:7128/Flight";
        public const string PassengerApi = "https://localhost:7128/Passenger";
        public const string? BREApiUrl = "https://localhost:7128/BusinessRuleEngine/Compensation";

        public const string SenderEmail = "xflyingtogether@gmail.com";
        public const string SenderPass = "I am flying together";
        public const string SenderHost = "smtp.gmail.com";
        public const int SenderPort = 587;

    }

}
