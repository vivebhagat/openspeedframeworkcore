using AutoFixture;
using DAO.CQ;
using DAO.CQ.Access.PagAccessCQ.Query;
using Moq;
using SpeedFramework.DAO.Commmon;
using System;
using System.Linq;
using Xunit;

namespace SPFDaoTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test_CheckLink_For_InvalidUrl()
        {
            var fixture = new Fixture();
            var query = fixture.Create<CheckLinkQuery>();

       
            var mockModelContext = new Mock<IModelContext>();
            var mockHandler = new Mock<IQueryHandler<CheckLinkQuery>>();

            var result = mockHandler.Object.Handle(query);

            It.Equals(mockModelContext.Object.PageAccesses.Where(m => m.RoleId == 1 & !m.Inactive & m.Link.url.ToLower() == query.url.ToLower()).FirstOrDefault(), true);


        }
    }
}
