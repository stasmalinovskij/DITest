using DItest.MwExample;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DItest
{
    public class MyMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<MyMiddleware> logger;

        //В конструктор мидлвари можем инжектить только синглтоны и опшинсы, ибо создается
        //мидлварь единожды
        public MyMiddleware(RequestDelegate next, string str, ILogger<MyMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
            logger.LogWarning("Заинжектели за щеку строку " + str);
        }

        //Можем инжектить любую хурму - один запрос один инвок
        public async Task InvokeAsync(HttpContext context, IGovno govno)
        {
            //если юзеров четное кол-во прерываем вызов последующих мидлварей
            if (await govno.DoShitAsync())
            {
                logger.LogWarning("Сорян работаю только если юзеров нечетно");
                return;
            }

            await next(context);
        }
    }
}
