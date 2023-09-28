using CommanderGQL.Models;

namespace CommanderGQL.GraphQL
{
    [GraphQLDescription("Represents the queries available.")]
    public class Subscription
    {

        [Subscribe]
        [Topic]
        [GraphQLDescription("The subscription for added platform.")]
        public Platform OnPlatformAdded([EventMessage] Platform platform)
        {
            return platform;
        }
    }
}
