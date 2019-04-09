using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using Lang_BigSchool.Models;
using Lang_BigSchool.DTOs;

namespace Lang_BigSchool.Controllers
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FolloweeID == userId && f.FolloweeID == followingDto.FolloweeID))
                return BadRequest("Following already exists!");

            var following = new Following
            {
                FollowerID = userId,
                FolloweeID = followingDto.FolloweeID
            };
            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();

            //following = _dbContext.Followings
            //    .Where(x => x.FolloweeId == followingDto.FolloweeId && x.FollowerId == userId)
            //    .Include(x => x.Followee)
            //    .Include(x => x.Follower).SingleOrDefault();

            //var followingNotification = new FollowingNotification()
            //{
            //    Id = 0,
            //    Logger = following.Follower.Name + " following " + following.Followee.Name
            //};
            //_dbContext.FollowingNotifications.Add(followingNotification);
            //_dbContext.SaveChanges();


            return Ok();
        }

    }
}