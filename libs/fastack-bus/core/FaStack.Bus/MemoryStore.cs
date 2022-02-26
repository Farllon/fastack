using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using FaStack.Bus.Abstractions;

namespace FaStack.Bus
{
    public class MemoryStore : INotificationStore
    {
        private List<Warning> _warnings;
        private List<Error> _errors;
        private List<InternalError> _internalErrors;

        public MemoryStore()
        {
            _warnings = new List<Warning>();
            _errors = new List<Error>();
            _internalErrors = new List<InternalError>();
        }

        public void AddWarning(Warning notification)
            => _warnings.Add(notification);

        public void AddError(Error notification)
            => _errors.Add(notification);

        public void AddInternalError(InternalError notification)
            => _internalErrors.Add(notification);

        public void ClearNotifications()
        {
            _warnings.Clear();
            _errors.Clear();
            _internalErrors.Clear();
        }

        public bool HasWarnings()
            => _warnings.Any();

        public bool HasErrors()
            => _errors.Any();

        public bool HasInternalErrors()
            => _internalErrors.Any();

        public IEnumerable<Warning> GetWarnings()
            => _warnings;

        public IEnumerable<Warning> GetWarnings(Expression<Func<Warning, bool>> predicate)
            => _warnings.Where(predicate.Compile());

        public IEnumerable<Error> GetErrors()
            => _errors;

        public IEnumerable<Error> GetErrors(Expression<Func<Error, bool>> predicate)
            => _errors.Where(predicate.Compile());

        public IEnumerable<InternalError> GetInternalErrors()
            => _internalErrors;

        public IEnumerable<InternalError> GetInternalErrors(Expression<Func<InternalError, bool>> predicate)
            => _internalErrors.Where(predicate.Compile());
    }
}