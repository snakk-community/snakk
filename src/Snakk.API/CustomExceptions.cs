//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;

namespace Snakk.API
{
    public class HttpResponseException : Exception
    {
        public int StatusCode { get; set; } = 500;

        public HttpResponseException(
            string message,
            int statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }

    public class HashIdToIdConvertionException : HttpResponseException
    {
        public HashIdToIdConvertionException()
            : base("Unsupported hashid provided", 500)
        {
        }
    }

    public class IdToHashIdConvertionException : HttpResponseException
    {
        public IdToHashIdConvertionException()
            : base("Unsupported id provided", 500)
        {
        }
    }
}
