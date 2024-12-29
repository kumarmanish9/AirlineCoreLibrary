namespace AirlineCoreLibrary.Utility
{
    public enum CompensationType
    {
        Hotel,
        Meal,
        HotelAndMeal,
        Voucher,
        Miles
    }

    public enum CompStatus
    {
        Offered,
        NotEligible,
        Pending,
        Accepted,
        Declined,
        Voided
    }

    public enum EventType
    {
        Controllable,
        UnControllable
    }

    public enum CabinType
    {
        Economy,
        Premium,
        Business
    }

    public enum PaxStatus
    {
        Gold,
        Silver,
        Platinum,
        General
    }

    public enum EventReason
    {
        Cancel,
        Delay,
        Unknown
    }

    public enum NotificationType
    {
        Email,
        SMS
    }

    public enum NotificationStatus
    {
        Sent,
        Failed
    }


}
