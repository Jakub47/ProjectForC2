using ProjectForCompany2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForCompany2.Models
{
    public interface IEntityConverterRepository
    {
        IEnumerable<Entity> GetAllEntites();
        void AddEntites(IEnumerable<Entity> entitiesFromFile);
        void RemoveAll();
        string GetFileType();
    }
}
