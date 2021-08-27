using System;
using FizzWare.NBuilder;

namespace FluentTests.Helpers
{
    public class DataBuilder<T>
    {
        private T _data;

        public DataBuilder()
        {
            _data = new Builder().CreateNew<T>()
                                 .Build();
        }

        public DataBuilder<T> Set(Action<T> action)
        {
            action(_data);
            return this;
        }

        public T Build()
        {
            return _data;
        }
    }
}
