namespace Vk.UserManagementSystem.Domain.Entities;
public class User
{
    public Guid Id { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }    

    public DateTime Created_date { get; set; }  

    public Guid UserGroupId { get; set; }

    public virtual UserGroup UserGroup { get; set; }

    public Guid UserStateId { get; set; }

    public virtual UserState UserState { get; set; }
}

