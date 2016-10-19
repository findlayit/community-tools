using System.Collections.Generic;
using System.Linq;
using CommunityTools.DataAccess.Common;
using CommunityTools.Domain.Surveys;
using System.Data.Entity;

namespace CommunityTools.DataAccess.Surveys
{
    public class QuestionAnswerRepository : BaseRepository<QuestionAnswerEntity>, IQuestionAnswerRepository
    {
        public QuestionAnswerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}