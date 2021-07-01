using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.BLL.Interfaces;
using WebApplication1.DAL;
using WebApplication1.Model;

namespace WebApplication1.BLL
{
    public class AwardServiceImpl : IAwardService
    {
        private AwardJsonRepository awardRepository;

        public AwardServiceImpl(AwardJsonRepository awardJsonRepository)
        {
            awardRepository = awardJsonRepository;
        }
        public void AddAward(Award award)
        {
            awardRepository.AddAward(award);
        }

        public List<Award> GetAllAward()
        {
            return awardRepository.GetAllAward();
        }

        public Award GetAward(Guid id)
        {
            return awardRepository.GetAward(id);
        }
    }
}