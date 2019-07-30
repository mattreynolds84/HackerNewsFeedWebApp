using BusinessLogic.Repositories;
using Moq.AutoMock;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class RepositoryTests
    {
        private AutoMocker _mocker;

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();
        }

        [Test]
        public void GetNewStoryIds_IntegrationSuccess()
        {
            var sut = _mocker.CreateInstance<HackerNewsRepository>();

            var stories = sut.GetNewStoryIds(0, 10).Result;

            Assert.IsTrue(stories.Any());
        }

        [Test]
        public void Get_IntegrationSuccess()
        {
            var sut = _mocker.CreateInstance<HackerNewsRepository>();

            var stories = sut.GetNewStoryIds(0, 10).Result;
            var story = sut.GetStoryById(stories.First()).Result;

            Assert.IsNotNull(story);
        }
    }
}