using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTaskWG.DTO;

namespace TechTaskWG.BLL
{
    public interface IBaseBLL<T> where T : Base
    {
        string Create(T obj);
        T ReadById(int id);
        List<T> ReadAll();
        string Update(T obj);
        string Delete(int id);
    }
}
