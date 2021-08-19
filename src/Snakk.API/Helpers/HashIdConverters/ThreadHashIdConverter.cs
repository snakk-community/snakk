//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Microsoft.Extensions.Configuration;

namespace Snakk.API.Helpers.HashIdConverters
{
    public interface IThreadHashIdConverter : IBaseHashIdConverter
    {
    }

    public class ThreadHashIdConverter : BaseHashIdConverter, IThreadHashIdConverter
    {
        public ThreadHashIdConverter(IConfiguration configuration)
            : base(configuration.GetValue<string>("ThreadHashidSecretSalt"))
        {
        }
    }
}
