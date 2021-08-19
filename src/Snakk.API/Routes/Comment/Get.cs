//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Comment
{
    public interface IGet
    {
        Task<object> RunAsync(long id);
    }

    public class Get : IGet
    {
        public Get()
        {
        }

        public async Task<object> RunAsync(long id)
        {
            await Task.Run(() => { System.Threading.Thread.Sleep(1); });

            return new { 
                id = id
            };
        }
    }
}
