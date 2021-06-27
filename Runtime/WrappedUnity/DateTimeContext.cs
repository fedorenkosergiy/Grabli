using SystemInterface;
using SystemWrapper;

namespace Grabli.WrappedUnity
{
    public class DateTimeContext : Context<DateTimeContext, DateTimeWrap, IDateTime>
    {
        protected override bool MoveEventInvocationLists => false;
        
        public DateTimeContext(IDateTime dateTime) : base(dateTime)
        {
        }

        public DateTimeContext()
        {
        }
    }
}
