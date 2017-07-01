using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoFcgiTest.Contracts
{
    public class SomeComplexType
    {
        [Flags]
        public enum SomeEnum
        {
            Have,
            Some,
            Values
        }

        public SomeEnum HaveSomeFlags { get; set; }

        public class SomeSubtype
        {
            public SomeComplexType SomeComplexType { get; set; }
        }

        public SomeSubtype[] SomeSubtypes { get; set; }
        public Guid? Guid { get; set; }
        public long int64 { get; set; }

        public static SomeComplexType Factory(int recursion)
        {
            recursion--;
            if (recursion < -1) return null;
            var r = new Random();
            var t = new SomeComplexType
            {
                Guid = System.Guid.NewGuid(),
                int64 = int.MaxValue + r.Next(),
            };
            var requiredSubtypes = r.Next(1, 4);
            var subtypes = new List<SomeSubtype>();
            while (subtypes.Count <= requiredSubtypes)
            {
                var newChild = Factory(recursion);
                if(newChild == null) break;
                subtypes.Add(new SomeSubtype()
                {
                    SomeComplexType = newChild
                });
            }
            t.SomeSubtypes = subtypes.ToArray();

            switch (r.Next(1,4))
            {
                case 1: t.HaveSomeFlags = SomeEnum.Some | SomeEnum.Values; break;
                case 2: t.HaveSomeFlags = SomeEnum.Values; break;
                case 3: t.HaveSomeFlags = SomeEnum.Some; break;
            }

            return t;
        }
    }

}