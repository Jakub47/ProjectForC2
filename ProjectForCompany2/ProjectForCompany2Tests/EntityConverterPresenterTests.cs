using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjectForCompany2.Data;
using ProjectForCompany2.Models;
using ProjectForCompany2.Presenter;
using ProjectForCompany2.Views;

namespace ProjectForCompany2Tests
{
    [TestClass]
    public class EntityConverterPresenterTests
    {
        private readonly EntityConverter entityConverter = new EntityConverter();
        private readonly IEntityConverterView mockEntityView;
        private readonly IEntityConverterRepository mockEntityRepository;
        private readonly EntityConverterPresenter presenter;

        public EntityConverterPresenterTests()
        {
            entityConverter.Entities = new List<Entity>
            {
                new Entity(){Name = "Name1",Value = "Value1",Comment = "Comment1"},
                new Entity(){Name = "Name2",Value = "Value2",Comment = String.Empty},
                new Entity(){Name = "Name3",Value = "Value3",Comment = "Comment3"},
                new Entity(){Name = "Name4",Value = "Value4",Comment = String.Empty},
                new Entity(){Name = "Name5",Value = "Value5",Comment = "Comment5"}
            };

            mockEntityView = Mock.Of<IEntityConverterView>(view =>
                  view.Entities == new List<Entity>());

            mockEntityRepository = Mock.Of<IEntityConverterRepository>(repository =>
                repository.GetAllEntites() == entityConverter.Entities);

            presenter = new EntityConverterPresenter(mockEntityView, mockEntityRepository);
        }

        [TestMethod]
        public void Presenter_shouldFillList()
        {
            var entitesNames = entityConverter.Entities;
            Assert.AreEqual(mockEntityView.Entities, entitesNames);
        }

        [TestMethod]
        public void Presenter_change_file_shoudlChangeList()
        {
            var mockRepo = Mock.Get(mockEntityRepository);
            mockRepo.Setup(repo => repo.GetAllEntites()).Returns(NewData());

            var mm = mockEntityRepository.GetAllEntites();

            var mockView = Mock.Get(mockEntityView);
            mockView.Setup(view => view.Entities).Returns(mockEntityRepository.GetAllEntites);



            Assert.AreEqual(mockEntityView.Entities.ToList().ElementAt(0).Name, NewData().ElementAt(0).Name);
        }

        [TestMethod]
        public void Presenter_clear_shouldEmptyList()
        {
            var mockRepo = Mock.Get(mockEntityRepository);
            mockRepo.Setup(repository => repository.GetAllEntites()).Returns(new List<Entity>());

            presenter.RemoveEntitesFromList();

            var mockView = Mock.Get(mockEntityView);
            mockView.VerifySet(view => view.Entities = new List<Entity>());
        }


        private IEnumerable<Entity> NewData()
        {
            return new List<Entity>
            {
                new Entity(){Name = "NameNew6",Value = "ValueNew6",Comment = "CommentNew6"},
                new Entity(){Name = "NameNew7",Value = "ValueNew7",Comment = String.Empty},
            };
        }
    }
}
