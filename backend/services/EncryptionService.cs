using System.Text;
using backend.Encryption;

namespace backend.Services
{
	public class EncryptionService
	{
        private readonly ILogger<EncryptionService> _logger;
		private readonly KmsHelper _kmsHelper;

        public EncryptionService(ILogger<EncryptionService> logger, KmsHelper kmsHelper)
		{
			_logger = logger;
			_kmsHelper = kmsHelper;
        }

		public async Task<string> EncryptString(string field)
		{
			var result = await _kmsHelper.EncryptAsync(field);
			var stringResult = Encoding.Unicode.GetString(result);

			_logger.LogInformation($"Encrypted field to value: {stringResult}");

			return stringResult;
		}

        public async Task<string> DecryptString(string field)
        {
			var byteArray = Encoding.Unicode.GetBytes(field);
            var stringResult = await _kmsHelper.DecryptAsync(byteArray);

            _logger.LogInformation($"Decrypted field to value: {stringResult}");

            return stringResult;
        }
    }
}

