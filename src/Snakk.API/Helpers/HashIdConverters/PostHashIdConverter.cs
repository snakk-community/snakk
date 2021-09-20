//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Microsoft.Extensions.Configuration;

namespace Snakk.API.Helpers.HashIdConverters
{
    public interface IPostHashIdConverter : IBaseHashIdConverter
    {
    }

    public class PostHashIdConverter : BaseHashIdConverter, IPostHashIdConverter
    {
        public PostHashIdConverter(IConfiguration configuration)
            : base(configuration.GetValue<string>("PostHashidSecretSalt"))
        {
        }
    }
}
