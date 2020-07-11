namespace OnlineStore.Ordering.Data
{
    public static class DataConstants
    {
        public static class Orders
        {
            public const int MaxUserIdLength = 450;

            public const int MinPhoneNumberLength = 5;
            public const int MaxPhoneNumberLength = 20;
            public const string PhoneNumberRegularExpression = @"\+[0-9]*";

            public const int MinAddressLength = 5;
            public const int MaxAddressLength = 20;
        }
    }
}
