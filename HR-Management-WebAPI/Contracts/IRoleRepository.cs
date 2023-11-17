namespace HR_Management_WebAPI.Contracts
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetRoles();

        Task<Role> GetRoleByName(string name);

        Task<Role> GetRoleById(int role_id);

        Task<CustomResponse> CreateRole(Role role);

        Task<CustomResponse> UpdateRole(int role_id, Role role);

        Task<CustomResponse> DeleteRole(int role_id);
    }
}