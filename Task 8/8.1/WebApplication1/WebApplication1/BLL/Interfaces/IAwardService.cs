using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.BLL.Interfaces
{
    interface IAwardService
    {
        void AddAward(Award award);
        List<Award> GetAllAward();
        Award GetAward(Guid id);  
    }
}
