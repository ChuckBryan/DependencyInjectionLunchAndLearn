namespace DependencyInjection.Web.Services
{
    using System;

    public class Operation : IOperation
    {
        public Operation()
        {
            OperationId = Guid.NewGuid();
        }

        public Operation(Guid guid)
        {
            OperationId = guid;
        }

        public Guid OperationId { get; }
    }
}