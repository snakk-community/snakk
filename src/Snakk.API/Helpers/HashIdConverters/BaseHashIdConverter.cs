using HashidsNet;

namespace Snakk.API.Helpers.HashIdConverters
{
    public interface IBaseHashIdConverter
    {
        long GetIdFromHash(string hash);
        string GetHashFromId(long id);
    }

    public class BaseHashIdConverter
    {
        private readonly Hashids _hashIds;

        public BaseHashIdConverter(string salt)
        {
            _hashIds = new Hashids(salt);
        }

        public long GetIdFromHash(string hash)
        {
            var ids = _hashIds.DecodeLong(hash);

            if (ids == null || ids.Length != 1)
            {
                throw new HashIdToIdConvertionException();
            }

            return ids[0];
        }

        public string GetHashFromId(long id) {
            var hash = _hashIds.EncodeLong(id);

            if (string.IsNullOrEmpty(hash))
            {
                throw new IdToHashIdConvertionException();
            }

            return hash;
        }
    }
}
