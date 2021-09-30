//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Microsoft.Extensions.Configuration;

namespace Snakk.API.Helpers.HashIdConverters
{
    public interface IAvatarHashIdConverter : IBaseHashIdConverter
    {
    }

    public class AvatarHashIdConverter : BaseHashIdConverter, IAvatarHashIdConverter
    {
        public AvatarHashIdConverter(IConfiguration configuration)
            : base(configuration.GetValue<string>("AvatarHashidSecretSalt"))
        {
        }
    }
}
