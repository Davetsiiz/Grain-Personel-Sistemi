using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class QuitManager : IQuitService
    {
        IQuitDal _quitDal;

        public QuitManager(IQuitDal quitDal)
        {
            _quitDal = quitDal;
        }

        public List<EmployeeQuit> GetList()
        {
            return _quitDal.GetListAll();
        }

        public List<EmployeeQuit> GetListQuitWithEmployee()
        {
            return _quitDal.GetListQuitWithEmployee();
        }

        public List<EmployeeQuit> GetListQuitWithId(int id)
        {
            return _quitDal.GetListQuitWithId(id);
        }

        public void TAdd(EmployeeQuit t)
        {
            _quitDal.Insert(t);
        }

        public void TDelete(EmployeeQuit t)
        {
            _quitDal.Delete(t);
        }

        public EmployeeQuit TGetById(int id)
        {
            return _quitDal.GetById(id);
        }

        public void TUpdate(EmployeeQuit t)
        {
            _quitDal.Update(t);
        }
    }
}
