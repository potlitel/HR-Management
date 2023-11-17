namespace HR_Management_WebAPI.Contracts
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeResponse>> GetEmployees();

        Task<Employee> GetEmployeeByName(string name);

        Task<Employee> GetEmployeeById(int employee_id);

        Task<Employee> GetEmployeeByEmail(string email);

        Task<int> GetEmployeeLatestRevisionDate(int employee_id);

        Task<CustomResponse> AddEmployeeSalaryIncrease(int employee_id, int pending_months);

        Task<List<HistoricalSalaries>> SelEmployeeHistoricalSalaries(int employee_id);

        Task<CustomResponse> CreateEmployee(Employee employee);

        Task<CustomResponse> UpdateEmployee(int employee_id, Employee employee);

        Task<CustomResponse> DeleteEmployee(int employee_id);
    }
}