namespace CleanIntegration.Core.Procon.Entities
{
    public class Enterprise
    {
        public static class Factory
        {
            public static Enterprise NewFromConfig(EnterpriseConfiguration enterpriseConfiguration)
                => new Enterprise();
        }
    }

    public class EnterpriseConfiguration {}
}
