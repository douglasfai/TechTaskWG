using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTaskWG.DTO;

namespace TechTaskWG.DAL
{
    public interface IBaseDAL<T> where T : Base
    {
        string Create(T obj);
        T ReadById(int id);
        List<T> ReadAll();
        string Update(T obj);
        string Delete(int id);
    }
}
