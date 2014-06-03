namespace Stripe
{
    public abstract class StripeService
    {
        protected string ApiKey { get; set; }
        protected IMapper Mapper { get; set; }
        protected IRequestor Requestor { get; set; }
        protected IParameterBuilder ParameterBuilder { get; set; }

        public StripeService(string apiKey = null)
        {
            ApiKey = apiKey;
            Mapper = new Mapper();
            Requestor = new Requestor(Mapper);
            ParameterBuilder = new ParameterBuilder();
        }

        public StripeService(string apiKey, IMapper mapper, IRequestor requestor, IParameterBuilder parameterBuilder)
        {
            ApiKey = apiKey;
            Mapper = mapper;
            Requestor = requestor;
            ParameterBuilder = parameterBuilder;
        }
    }
}

