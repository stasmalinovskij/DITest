using DItest.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DItest.MwExample
{
    //public interface IGovno
    //{
    //    Task<bool> DoShitAsync();
    //}

    //public class Govnoservice : IGovno
    //{
    //    private readonly Microsoft.AspNetCore.Identity.UserManager<Microsoft.AspNetCore.Identity.IdentityUser> userManager;

    //    public Govnoservice(Microsoft.AspNetCore.Identity.UserManager<Microsoft.AspNetCore.Identity.IdentityUser> userManager)
    //    {
    //        this.userManager = userManager;
    //    }

    //    //Четно ли количество юзеров
    //    public async Task<bool> DoShitAsync()
    //    {
    //        //можно тянуть из базы, но мне лень создавать базу
    //        // /|\ у тебя есть база така которая предоставляется встроенной миграцией, сделай update-database что бы ее создать

    //        var usr = await userManager.FindByNameAsync("test"); // <-сдесь должен быть userManager вместо контекста

            
    //        if (usr != null) // какая-то заглушка потому что команды посчитать пользователей в userManager
    //            return  true;
    //        else
    //            return false;
    //    }
    //}
}
