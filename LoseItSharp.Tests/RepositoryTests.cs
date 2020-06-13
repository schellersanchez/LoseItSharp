using System;
using LoseItSharp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoseItSharp.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        Repository _repository = new Repository(new MockDataAccess());

        [TestMethod]
        public void ShouldReturnMatchObject()
        {

            //Act
            var match = _repository.GetMatch(1);

            //Assert
            Assert.IsNotNull(match);
            Assert.IsTrue(match.Id > 0);

        }
    }
}
