using System;
using System.Linq.Expressions;
using Rawpotion.Api.Domain;
using Rawpotion.Api.Models;

namespace Rawpotion.Api.Models
{
    public static partial class UserMapper
    {
        public static UserDto AdaptToDto(this User p1)
        {
            return p1 == null ? null : new UserDto()
            {
                Id = p1.Id,
                UserName = p1.UserName,
                Email = p1.Email,
                Name = p1.Name,
                Location = p1.Location
            };
        }
        public static UserDto AdaptTo(this User p2, UserDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            UserDto result = p3 ?? new UserDto();
            
            result.Id = p2.Id;
            result.UserName = p2.UserName;
            result.Email = p2.Email;
            result.Name = p2.Name;
            result.Location = p2.Location;
            return result;
            
        }
        public static Expression<Func<User, UserDto>> ProjectToDto => p4 => new UserDto()
        {
            Id = p4.Id,
            UserName = p4.UserName,
            Email = p4.Email,
            Name = p4.Name,
            Location = p4.Location
        };
        public static User AdaptToUser(this UserAdd p5)
        {
            return p5 == null ? null : new User()
            {
                UserName = p5.UserName,
                Email = p5.Email,
                Name = p5.Name,
                Location = p5.Location
            };
        }
        public static User AdaptTo(this UserUpdate p6, User p7)
        {
            if (p6 == null)
            {
                return null;
            }
            User result = p7 ?? new User();
            
            result.UserName = p6.UserName;
            result.Email = p6.Email;
            result.Name = p6.Name;
            result.Location = p6.Location;
            return result;
            
        }
    }
}