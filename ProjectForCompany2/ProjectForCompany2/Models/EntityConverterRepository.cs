using ProjectForCompany2.Data;
using System;
using System.Collections.Generic;

namespace ProjectForCompany2.Models
{
    public class EntityConverterRepository : IEntityConverterRepository
    {
        private IEnumerable<Entity> _entities;

        public void AddEntites(IEnumerable<Entity> entitiesFromFile)
        {
            _entities = entitiesFromFile;
        }

        public IEnumerable<Entity> GetAllEntites()
        {
            return _entities;
        }

        public void RemoveAll()
        {
            _entities = new List<Entity>();
        }

        public string GetFileType()
        {
            throw new NotImplementedException();
        }
    }
}
