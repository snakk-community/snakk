//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Snakk.API.Dto.Routes.Thread.Get;
using System;

namespace Snakk.API.Plugin.MyPlugin1.Hooks.Routes.Thread.Services.Get
{
    public class Service : PluginFramework.Hooks.Routes.Thread.Services.Get.IService
    {
        public void After(long commentId, ResponseDto responseDto)
        {
            Console.WriteLine($"Hello from {GetType().FullName}.After()");
        }

        public void Before(long commentId, ResponseDto responseDto)
        {
            Console.WriteLine($"Hello from {GetType().FullName}.Before()");
        }
    }
}
