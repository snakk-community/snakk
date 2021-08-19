//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Microsoft.Extensions.Configuration;

namespace Snakk.API.Helpers.HashIdConverters
{
    public interface ICommentHashIdConverter : IBaseHashIdConverter
    {
    }

    public class CommentHashIdConverter : BaseHashIdConverter, ICommentHashIdConverter
    {
        public CommentHashIdConverter(IConfiguration configuration)
            : base(configuration.GetValue<string>("CommentHashidSecretSalt"))
        {
        }
    }
}
