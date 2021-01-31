using System;

namespace NetCoreSample.Interfaces
{
    public interface IJobTaskRunner
    {
        void Run(Guid id);
    }
}
