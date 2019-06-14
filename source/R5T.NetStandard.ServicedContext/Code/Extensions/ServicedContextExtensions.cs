using System;


namespace R5T.NetStandard
{
    public static class ServicedContextExtensions
    {
        public static T Get<T>(this ServicedContext context, string key)
        {
            var value = context[key];
            if (value is T valueAsT)
            {
                return valueAsT;
            }
            else
            {
                throw new ArgumentException(ExceptionHelper.UnexpectedTypeExceptionMessage<T>(value));
            }
        }
    }
}
