using ProjectForCompany2.Data;
using ProjectForCompany2.Models;
using ProjectForCompany2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectForCompany2.Presenter
{
    public class EntityConverterPresenter
    {
        private readonly IEntityConverterView _view;
        private readonly IEntityConverterRepository _repository;

        public EntityConverterPresenter(IEntityConverterView view, IEntityConverterRepository repository)
        {
            _view = view;
            view.Presenter = this;
            _repository = repository;

            UpdateResxNodeListView();
        }

        public EntityConverterPresenter()
        {

        }

        private void UpdateResxNodeListView()
        {
            _view.Entities = _repository.GetAllEntites();
        }


        public void AddEntity(IEnumerable<Entity> entitiesFromfile)
        {
            _repository.AddEntites(entitiesFromfile);
            UpdateResxNodeListView();
        }

        public void RemoveEntitesFromList()
        {
            _repository.RemoveAll();
            UpdateResxNodeListView();
        }

        public IEnumerable<Entity> GetAllEntites()
        {
            return _repository.GetAllEntites();
        }
    }
}
