using System;
using System.Collections.Generic;


namespace R5T.NetStandard
{
    /// <summary>
    /// A context implementation built around a <see cref="Dictionary{TKey, TValue}"/>, TKey: string, TValue: object for instance-per-variable name context.
    /// Derived types can implement typed properties that will get/set instances by variable name out of the protected base-type dictionary.
    /// Includes a <see cref="IServiceProvider"/> from which services for processing the context can be requested.
    /// </summary>
    public class ServicedContext
    {
        public IServiceProvider ServiceProvider { get; }
        protected Dictionary<string, object> Dictionary { get; } = new Dictionary<string, object>();
        public object this[string key]
        {
            get
            {
                var value = this.Dictionary[key];
                return value;
            }
            set
            {
                this.Dictionary[key] = value;
            }
        }


        public ServicedContext(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }

        public void Add(string key, object value)
        {
            this.Dictionary.Add(key, value);
        }

        public object Get(string key)
        {
            var value = this[key];
            return value;
        }

        public bool ContainsKey(string key)
        {
            var containsKey = this.Dictionary.ContainsKey(key);
            return containsKey;
        }

        public void Set(string key, object value)
        {
            this[key] = value;
        }

        public bool Remove(string key)
        {
            bool success = this.Dictionary.Remove(key);
            return success;
        }
    }
}
