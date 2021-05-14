using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSoftware
{
    /// <summary>
    /// Very simple ServiceLocator implementation, an easy alternative to Dependency Injection for small or legacy projects
    /// </summary>
    public class ServiceLocator
    {
        public static ServiceLocator Default = new ServiceLocator();

        private readonly ConcurrentDictionary<Type, object> container = new ConcurrentDictionary<Type, object>();

        public ServiceLocator()
        {


        }

        public void Set<T>(T t)
        {
            container.TryAdd(typeof(T), t);
        }

        public T Get<T>()
        {
            try
            {
                Type t = typeof(T);
                return (T)container.GetOrAdd(t, _ => (T)Activator.CreateInstance(typeof(T)));
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Service not available: " + ex.Message);
            }
        }

        internal Lazy<T> GetLazy<T>()
        {
            return new Lazy<T>(Get<T>);
        }
    }
}
