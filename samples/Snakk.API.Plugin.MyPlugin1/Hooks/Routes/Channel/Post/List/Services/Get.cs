//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Snakk.API.Dto.Routes.Channel.Post.List.Get;
using System;

namespace Snakk.API.Plugin.MyPlugin1.Hooks.Routes.Channel.Post.List.Services
{
    public class Get : PluginFramework.Hooks.Routes.Channel.Post.List.Services.IGet
    {
        public void After(string channelUrlIdentifier, ResponseDto responseDto)
        {
            Console.WriteLine($"Hello from {GetType().FullName}.After()");
        }

        public void Before(string channelUrlIdentifier, ResponseDto responseDto)
        {
            Console.WriteLine($"Hello from {GetType().FullName}.Before()");
        }
    }
}
