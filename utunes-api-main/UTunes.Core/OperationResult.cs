using System;
namespace UTunes.Core
{
    public class OperationResult
    {
        public OperationResult()
        {
            this.Succeeded = false;
        }

        public OperationResult(bool succeeded)
            : this()
        {
            this.Succeeded = succeeded;
        }

        public OperationResult(Error error)
            : this()
        {
            this.Error = error;
        }

        public bool Succeeded { get; protected set; }

        public Error Error { get; set; }

        public static implicit operator bool(OperationResult value)
        {
            return value.Succeeded;
        }

        public static implicit operator OperationResult(bool value)
        {
            return new OperationResult(value);
        }
    }
}

