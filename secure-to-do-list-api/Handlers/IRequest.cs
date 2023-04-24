using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secure_to_do_list_api.Handlers
{
    public interface IRequest<in TIn,out TOut>
    {
        TOut Handle(TIn request);
    }
}
