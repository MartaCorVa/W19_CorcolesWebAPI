using Dapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using W19_CorcolesWebAPI.Models;

namespace W19_CorcolesWebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class CollectibleController
    {
        // POST api/Collectible/InsertCollectible
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [HttpPost]
        [Route("InsertCollectible")]
        public bool InsertNewPlayer(CollectibleAPIModel coll)
        {
            using (IDbConnection cnn = new ApplicationDbContext().Database.Connection)
            {
                string sql = $"INSERT INTO dbo.Collectible(Id, Name, Quantity, PlayerId)" +
                    $" VALUES ('{coll.Id}','{coll.Name}','{coll.Quantity}','{coll.PlayerId}')";
                int rows = cnn.Execute(sql);
                if (rows != 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }

        // GET api/Collectible
        [Authorize]
        [RoutePrefix("api/Collectible")]
        public class PlayerController : ApiController
        {
            [HttpGet]
            [Route("GetCollectibleInfo")]
            public CollectibleAPIModel GetPlayerInfo()
            {
                string authenticatedAspNetUserId = RequestContext.Principal.Identity.GetUserId();
                using (IDbConnection cnn = new ApplicationDbContext().Database.Connection)
                {
                    string sql = $"SELECT Id, Name, Quantity, PlayerId FROM dbo.Collectible " +
                        $"WHERE Id LIKE '{authenticatedAspNetUserId}'";
                    var coll = cnn.Query<CollectibleAPIModel>(sql).FirstOrDefault();
                    return coll;
                }
            }
        }
}