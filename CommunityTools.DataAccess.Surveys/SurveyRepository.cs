using System.Collections.Generic;
using System.Linq;
using CommunityTools.DataAccess.Common;
using CommunityTools.Domain.Surveys;
using System.Data.Entity;

namespace CommunityTools.DataAccess.Surveys
{
    public class SurveyRepository : BaseRepository<SurveyEntity>, ISurveyRepository
    {
        public SurveyRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}