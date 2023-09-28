using RayaTask.ViewModels;

namespace RayaTask.Interface
{
    public interface IEmployeeRepo
    {
        public void AddEmployee(EmployeeVM employee);
        public IEnumerable<EmployeeVM> GetAll();
        public EmployeeVM GetEmployee(int id);
        public void DeleteEmployee(int id);
        public void EditEmployee(EmployeeVM employee);
        public IEnumerable<EmployeeVM> Filter(EmployeeVM model);
    }
}
