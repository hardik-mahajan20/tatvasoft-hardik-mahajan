﻿using Data_Logic_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Logic_Layer
{
    public class DALLogin
    {
        private AppDbContext _context;

        public DALLogin(AppDbContext context)
        {
            _context = context;
        }

        public User LoginUser(User user)
        {
            User userObj = new User();      
            try
            {   //Select Logic
                var query = from u in _context.User
                            where u.EmailAddress == user.EmailAddress
                            select new
                            {
                                u.Id,
                                u.FirstName,
                                u.LastName,
                                u.Password,
                                u.PhoneNumber,
                                u.EmailAddress,
                                u.UserType
                            };
                var userData = query.FirstOrDefault();
                if ((userData != null))
                {
                    if(userData.Password==user.Password)
                    {
                         userObj.Id = userData.Id;
                        userObj.FirstName = userData.FirstName;     
                        userObj.LastName = userData.LastName;    
                        userObj.PhoneNumber = userData.PhoneNumber; 
                        userObj.EmailAddress = userData.EmailAddress;
                        userObj.UserType = userData.UserType;
                        userObj.Message = "Login Successfully";
                    }
                    else
                    {
                        userObj.Message = "Password incorrect";
                    }
                }
                else
                {
                    userObj.Message = "EmailAddress not found";
                }
            }
            catch(Exception ex)
            {
                userObj.Message = ex.Message;   
            }
            return userObj;
        }
    }
}
