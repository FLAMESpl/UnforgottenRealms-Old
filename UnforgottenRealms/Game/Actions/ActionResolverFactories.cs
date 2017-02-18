using UnforgottenRealms.Game.Objects;

namespace UnforgottenRealms.Game.Actions
{
    public class ActionResolverFactories
    {
        public delegate IdleActionResolver IdleActionResolverFactory();

        public delegate ObjectActionResolver ObjectActionResolverFactory(GameObject selectedObject);

        public IdleActionResolverFactory IdleAction { get; private set; }
        public ObjectActionResolverFactory ObjectAction { get; private set; }

        public ActionResolverFactories(
            IdleActionResolverFactory idleActionResolverFactory,
            ObjectActionResolverFactory objectActionResolverFactory)
        {
            IdleAction = idleActionResolverFactory;
            ObjectAction = objectActionResolverFactory;
        }
    }
}
