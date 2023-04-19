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
    public class WorkerManager : IWorkerService
    {
        IWorkerDal _workerDal;

        public WorkerManager(IWorkerDal workerDal)
        {
            _workerDal = workerDal;
        }

        public List<EmployeeWorker> GetList()
        {
            return _workerDal.GetListAll();
        }

        public List<EmployeeWorker> GetListWorkerWithEmployee()
        {
            return _workerDal.GetListWorkerWithEmployee();
        }

        public List<EmployeeWorker> GetListWorkerWithId(int id)
        {
            return _workerDal.GetListWorkerWithId(id);

        }

        public void TAdd(EmployeeWorker t)
        {
            _workerDal.Insert(t);
        }

        public void TDelete(EmployeeWorker t)
        {
            _workerDal.Delete(t);
        }

        public EmployeeWorker TGetById(int id)
        {
            return _workerDal.GetById(id);
        }

        public void TUpdate(EmployeeWorker t)
        {
            _workerDal.Update(t);
        }
    }
}
