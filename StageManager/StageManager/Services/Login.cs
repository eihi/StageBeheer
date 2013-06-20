using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StageManager.Models;

namespace StageManager.Services
{
    public class  Login
    {
        public administrators Connect(String username, String password)
        {
            if (username != null && password != null)
            {
                System.Diagnostics.Debug.WriteLine("Connect");
                stagemanagerEntities smE = new stagemanagerEntities();
                administrators user = null;

                List<administrators> admins = smE.administrators.ToList();
                for (int i = 0; i < admins.Count; i++)
                {
                    if (admins[i].users.email == username && admins[i].password == password)
                    {
                        user = admins[i];
                    }
                }

                if (user!=null)
                {
                    System.Diagnostics.Debug.WriteLine("Logged in as " + user.users.name + " " + user.users.surname);
                    return user;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Invalid Username or Password");
                    return null;
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Invalid Stuff");
                return null;
            }
        }

    }
}

