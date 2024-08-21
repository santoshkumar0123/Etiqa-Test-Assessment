using Etiqa_Assessment_REST_API.Models;
using Etiqa_Assessment_REST_API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Etiqa_Assessment_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository ??
                throw new ArgumentNullException(nameof(userRepository));
        }

        [HttpGet]
        [Route("GetUserLists")]
        //[Authorize]
        public async Task<ActionResult<ApiResponse>> GetUserLists(int pageIndex = 1, int pageSize = 1)
        {
            var userLists = await _userRepository.GetUserLists(pageIndex, pageSize);
            return new ApiResponse(true, null, userLists);
        }

        [HttpPost]
        [Route("RegisterNewUser")]
        public async Task<IActionResult> Post(User userDetails)
        {
            if (userDetails == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            try
            {
                var response = await _userRepository.RegisterNewUser(userDetails);
               
                return Ok("New user registered successfully");
            }
            catch
            {
                throw;
            }            
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> Put(User userDetails)
        {
            await _userRepository.UpdateUserDetails(userDetails);
            return Ok("User details updated successfully");
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public JsonResult Delete(string username)
        {
            var result = _userRepository.DeleteUser(username);
            return new JsonResult("User deleted Successfully");
        }
    }
}
