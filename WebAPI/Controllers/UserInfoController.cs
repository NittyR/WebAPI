using System;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using WebAPI.Repository;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUserInfoRepository _userInfo;

        public UserInfoController(IWebHostEnvironment env,
          IUserInfoRepository userinfo)
        {
            _env = env;
            _userInfo = userinfo ?? throw new ArgumentNullException(nameof(userinfo));
        }

        [HttpGet]
        [Route("GetUserInfo")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userInfo.GetUserInfo());
        }

        [HttpPost]
        [Route("AddUserInfo")]
        public async Task<IActionResult> Post(UserInfo _info)
        {

            var result = await _userInfo.InsertUserInfo(_info);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }

            return Ok("Added Successfully");
        }

        [HttpPut]
        [Route("UpdateUserInfo")]
        public async Task<IActionResult> Put(UserInfo _info)
        {
            var result = await _userInfo.UpdateUserInfo(_info);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var result = _userInfo.DeleteUserInfo(id);
            return new JsonResult("Deleted Successfully");
        }
     
    }
}
