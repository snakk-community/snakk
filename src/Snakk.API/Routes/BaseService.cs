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
