using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MnCloudService.Models;

namespace MnCloudService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MnCloudContext _context;

        public UsersController(MnCloudContext context)
        {
            _context = context;
        }


        [HttpGet("Getuser")]
        public async Task<ActionResult<List<MnTblUser>>> GetUsers()
        {
            return Ok(await _context.MnTblUsers.ToListAsync());
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser ([FromBody] Mnusers mnusers) 
        {
            DataResult? dataresult = null;

            try
            {
               
                var user = await _context.MnTblUsers.SingleOrDefaultAsync(u => u.Mobile == mnusers.Mobile || u.UserEmail==mnusers.Email);
                if (user == null)
                {
                    MnTblUser mnTblUser = new()
                    {

                        UserId = 0,
                        UserName = mnusers.Name,
                        UserEmail = mnusers.Email,
                        Mobile = mnusers.Mobile,
                        UserPassword = mnusers.Password,
                        Message = mnusers.Discription,
                        Createddatetime = DateAndTime.Now,
                        Updateddatetime = null


                    };

                    _context.MnTblUsers.Add(mnTblUser);

                    await _context.SaveChangesAsync();

                    dataresult = new() { Result = true, Message = "Successfully Data Saved." };
                }
                else
                {
                    dataresult = new() { Result = false, Message = "Mobile Or Eamil is already Exist." };
                }
            }
            catch (Exception ex)
            {
                 dataresult = new() { Result = false, Message = "Successfully Data is not Saved." };
            }

            return Ok(dataresult);

        }


        [HttpPost("Login")]
        public async Task<ActionResult> Login( [FromBody] Login userLogin)
        {
            DataResult dataresult;
            var user = await _context.MnTblUsers.SingleOrDefaultAsync(u => u.Mobile == userLogin.Mobile && u.UserPassword == userLogin.Password);
            if (user != null)
            {
                 dataresult = new() { Result = true, Message = "User logged in Successfully." };
            }
            else
            {
                 dataresult = new() { Result = false, Message = "User logged in Failed." };
            }
            return Ok(dataresult);

        }
    }
}
