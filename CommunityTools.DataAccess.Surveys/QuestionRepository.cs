using System.Collections.Generic;
using System.Linq;
using CommunityTools.DataAccess.Common;
using CommunityTools.Domain.Surveys;
using System.Data.Entity;

namespace CommunityTools.DataAccess.Surveys
{
    public class QuestionRepository : BaseRepository<QuestionEntity>, IQuestionRepository
    {
        public QuestionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}