namespace ARS_ProjectSystem.Recaptcha
{
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class GoogleRecaptchaService
    {
        private readonly ReCAPTCHASettings _settings;
        public GoogleRecaptchaService(IOptions<ReCAPTCHASettings> settings)
        {
            _settings = settings.Value;
        }

        public virtual async Task<GoogleResponse> VerifyReCaptcha(string _Token)
        {
            GoogleRecaptchaData _MyData = new GoogleRecaptchaData
            {
                Response=_Token,
                Secret=_settings.Secret
            };

            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"https://www.google.com/recaptcha/api/siteverify?=secret{_MyData.Secret}&response={_MyData.Response}");
            var capResponse = JsonConvert.DeserializeObject<GoogleResponse>(response);

            return capResponse;

        }
    }
    public class GoogleRecaptchaData
    {
        public string Response { get; set; }//token

        public string Secret { get; set; }
    }
    public class GoogleResponse
    {
        public bool Success { get; set; }

        public double Score { get; set; }

        public string Action { get; set; }

        public DateTime Challenge_ts { get; set; }

        public string HostName { get; set; }
    }
}
