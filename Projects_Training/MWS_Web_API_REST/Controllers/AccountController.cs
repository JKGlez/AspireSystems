//To access JWT generator and validator
using Microsoft.AspNetCore.Authentication.Cookies;
using MWS_API_EF.Controllers.JWT;
//To access LOGIN Class
using MWS_API_EF.Models;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MWS_API_EF.Controllers
{
    [AllowAnonymous]
    public class AccountController : ApiController
    {
        /// <summary>
        /// Method use to implement Authentification 
        /// </summary>
        /// <param name="theLogin"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Login([FromBody] Login theLogin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (MechanicalWorkshop_Entities db = new MechanicalWorkshop_Entities())
            {

                var obj_User = db.tbl_Users.Where(d => d.NickName_User == theLogin.Username && d.Password_User == theLogin.Password).FirstOrDefault();
                
                if (obj_User != null)
                {
                    if (obj_User.AdminRights_User)
                    {
                        var jwkToken = TokenGenerator.GenerateTokenJwt(theLogin.Username, "Administrator");
                        var token = new JWT_Model(obj_User.NickName_User, jwkToken, "Administrator");
                        return Ok(token);
                    }
                    else
                    {
                        var jwkToken = TokenGenerator.GenerateTokenJwt(theLogin.Username, "Employee");
                        var token = new JWT_Model(obj_User.NickName_User, jwkToken, "Employee");
                        return Ok(token);
                    }
                }
                else
                {
                    var token = new JWT_Model("NoOne", "", "Unauthorized");
                    return Ok(token);
                    //return Unauthorized(); //status code 401
                }

            }
        }
    }
}
