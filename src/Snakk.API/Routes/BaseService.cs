//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System.Collections.Generic;

namespace Snakk.API.Routes
{
    public class BaseService
    {
        protected Dictionary<string, dynamic> _pluginDataDictionary;

        public BaseService()
        {
            _pluginDataDictionary = new Dictionary<string, dynamic>();
        }
    }
}
