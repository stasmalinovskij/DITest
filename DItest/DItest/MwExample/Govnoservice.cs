using DItest.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DItest.MwExample
{
    public interface IGovno
    {
        Task<bool> DoShitAsync();
    }

    public class Govnoservice : IGovno
    {
        private readonly ApplicationDbContext context;

        public Govnoservice(ApplicationDbContext context)
        {
            this.context = context;
        }

        //Четно ли количество юзеров
        public async Task<bool> DoShitAsync()
        {
            //можно тянуть из базы, но мне лень создавать базу
            //var cnt = await context.Users.CountAsync();
            var cnt = 15;
            return cnt % 2 == 0;
        }
    }
}
