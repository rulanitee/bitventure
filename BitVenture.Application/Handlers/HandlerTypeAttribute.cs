using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitVenture.Application.Handlers
{
    public class HandlerTypeAttribute : Attribute
    {
        public HandlerTypeAttribute(HandlerType handlerType)
        {
            theHandlerType = handlerType;
        }

        protected HandlerType theHandlerType;

        public HandlerType TypeOfHandler
        {
            get { return theHandlerType; }
            set { theHandlerType = value; }
        }
    }
}
