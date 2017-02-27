namespace UnforgottenRealms.Common.Definitions.Entity
{
    public static class DepositsDefinitions
    {
        public static EntityId Gems => DepositId("gems");
        public static EntityId Iron => DepositId("iron");
        public static EntityId Pearls => DepositId("pearls");

        private static EntityId DepositId(string value) => new EntityId(EntityClass.Deposit, value);
    }
}
