﻿using Data_Logic_Layer;
using Data_Logic_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Logic_Layer
{
    public class BALLogin
    {
        public DALLogin _dalLogin;

        public BALLogin(DALLogin dalLogin)
        {
            _dalLogin = dalLogin;
        }

        ResposeResult result = new ResposeResult();
        public ResposeResult LoginUser(User user)
        {
            try
            { 
                User userObj = new User();  
                userObj = UserLogin(user); 
                if (userObj != null)
                {
                    if (userObj.Message.ToString() == "Login Successfully")
                    {
                        result.Message = userObj.Message;   
                        result.Result = ResponseStatus.Success;
                        result.Data = userObj;
                    }
                    else
                    {
                        result.Message = userObj.Message;
                        result.Result = ResponseStatus.Error;
                    }
                }
                else
                {
                    result.Message = "Error In Login";
                    result.Result = ResponseStatus.Error;
                }

            }
            catch(Exception )
            {
                throw;
            }
            return result;  
        }
        public User UserLogin(User user)
        {
            User userObj = new User()
            {
                EmailAddress = user.EmailAddress,
                Password = user.Password
            };
            return _dalLogin.LoginUser(userObj);
        }
    }
}
