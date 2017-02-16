using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaygunTrello.Services
{
    public class ServiceLocator
    {
        private static readonly Dictionary<Type, Type> Types = new Dictionary<Type, Type>();
        private static readonly Dictionary<Type, object> Singletons = new Dictionary<Type, object>();

        public static void RegisterService<T, TU>() where TU : T
        {
            if (!Types.ContainsKey(typeof(T)))
            {
                Types.Add(typeof(T), typeof(TU));
            }
            else
            {
                Types[typeof(T)] = typeof(TU);
            }
        }

        public static void RegisterSingletonService<T, TU>() where TU : T
        {
            RegisterService<T, TU>();
            if (!Singletons.ContainsKey(typeof(T)))
            {
                Singletons.Add(typeof(T), (T) Activator.CreateInstance(typeof(TU)));
            }
        }

        public static T GetService<T>()
        {
            if (!Types.ContainsKey(typeof(T)))
            {
                throw new InvalidOperationException($"no service found matching {typeof(T).Name}");
            }

            var concreteImp = Types[typeof(T)];

            if (Singletons.ContainsKey(concreteImp))
            {
                return (T) Singletons[concreteImp];
            }

            return (T) Activator.CreateInstance(concreteImp);
        }

    }
}