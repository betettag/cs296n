using System.Linq;
using CommunitySite.Models;
using System.Collections.Generic;

namespace CommunitySite.Repositories
{
    public interface IGuestRepo
    {
        List<Message> Responses { get; }
        void AddResponse(Message response);
    }
}
