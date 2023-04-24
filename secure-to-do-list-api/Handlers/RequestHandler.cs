namespace secure_to_do_list_api.Handlers
{
    public abstract class RequestHandler<TIn, TOut>
    {
        public abstract TOut Handle(TIn request);
    }
}