using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("users")]
public class UsersController: ControllerBase{

    private readonly UsersDb usersDb;

    public UsersController(UsersDb userDb)
    {
        this.usersDb = userDb;
    }

    [HttpGet("getUsers")]
    public async Task<IEnumerable<Users>> GetUsers(){
        return await usersDb.users.ToListAsync();
    }

    [HttpPost("postUser")]
    public async Task<Users> PostUser([FromBody] Users user){
        usersDb.Add(user);
        await usersDb.SaveChangesAsync();
        return user;
    }

    [HttpGet("getUser")]
    public async Task<Users?> GetUser([FromQuery] UsersDto user){
        return await usersDb.users.SingleOrDefaultAsync(u => u.email == user.email && u.password == user.password);
    }
    
    [HttpPut("updateUser")]
    public async Task<string> UpdateUser([FromBody] Users userUpdate, [FromQuery] UsersDto user){
        var userOld = await usersDb.users.SingleOrDefaultAsync(u => u.email == user.email && u.password == user.password);

        userOld.name = userUpdate.name;
        userOld.address = userUpdate.address;
        userOld.password = userUpdate.password;

        await usersDb.SaveChangesAsync();

        return "actualizado";
    }
}