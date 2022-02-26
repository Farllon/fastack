using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace FaStack.Bus.Abstractions
{
    public interface INotificationStore
    {
        void AddWarning(Warning notification);

        void AddError(Error notification);

        void AddInternalError(InternalError notification);

        void ClearNotifications();

        bool HasWarnings();

        bool HasErrors();

        bool HasInternalErrors();

        IEnumerable<Warning> GetWarnings();

        IEnumerable<Warning> GetWarnings(Expression<Func<Warning, bool>> predicate);

        IEnumerable<Error> GetErrors();

        IEnumerable<Error> GetErrors(Expression<Func<Error, bool>> predicate);

        IEnumerable<InternalError> GetInternalErrors();

        IEnumerable<InternalError> GetInternalErrors(Expression<Func<InternalError, bool>> predicate);
    }
}
