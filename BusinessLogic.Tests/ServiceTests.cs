using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class ServiceTests
    {
        private AutoMocker _mocker;

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();
        }

        [Test]
        public void ValidatePage_False()
        {
            var sut = _mocker.CreateInstance<HackerNewsService>();

            var validPage = sut.ValidatePage(50);

            Assert.IsFalse(validPage);
        }

        [Test]
        public void ValidatePage_True()
        {
            var sut = _mocker.CreateInstance<HackerNewsService>();

            var validPage = sut.ValidatePage(10);

            Assert.IsTrue(validPage);
        }

        [Test]
        public void GetStoryFromCache_Pass()
        {
            var mockCallRepository = _mocker.GetMock<IHackerNewsRepository>();

            mockCallRepository
                .Setup(x => x.GetNewStoryIds(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(CreateStories().Select(x => x.Id).ToList());

            mockCallRepository
                .Setup(x => x.GetStoryById(It.IsAny<int>()))
                .ReturnsAsync(CreateStories().First());

            var sut = _mocker.CreateInstance<HackerNewsService>();
            var stories = sut.GetNewStories(0).Result;
            var story = stories.First();

            var cachedStory = sut.GetStoryFromCache(story.Id);

            Assert.AreSame(story, cachedStory);
        }


        [Test]
        public void GetStoryFromCache_Fail()
        {
            var sut = _mocker.CreateInstance<HackerNewsService>();
            var story = new HackerNewsStory() { Id = 1 };

            var cachedStory = sut.GetStoryFromCache(story.Id);

            Assert.AreNotSame(story, cachedStory);
        }

        private ICollection<HackerNewsStory> CreateStories()
        {
            return new List<HackerNewsStory>() { new HackerNewsStory() { Id = 1 } };
        }
    }
}