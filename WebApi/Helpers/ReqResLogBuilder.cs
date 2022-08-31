using WebApi.Helpers;
using WebApi.Logging;

namespace InsuranceApi.Helpers
{
    public class ReqResLogBuilder
    {
        private readonly string _appName = "BimeApi";
        private string _userName = string.Empty;
        private HttpResponse? _httpResponse;
        private HttpResponseMessage? _httpResponseMessage;
        private string _summarizedResponse;
        private HttpContext _httpContext = default!;
        private string _body;
        private DateTime _requestDate;
        //private DateTime? _responseDate;

        public ReqResLogBuilder(HttpContext httpContext, DateTime requestedOn)
        {
            _httpContext = httpContext;
            _requestDate = requestedOn;
        }
        public ReqResLogBuilder AddTokenRequestUserName(string userName)
        {
            _userName = userName;
            return this;
        }
        internal ReqResLogBuilder AddHttpResponse(HttpResponse httpResponse)
        {
            _httpResponse = httpResponse;
            _httpResponseMessage = null;
            return this;
        }

        internal ReqResLogBuilder AddHttpResponseMessage(HttpResponseMessage httpResponseMessage)
        {
            _httpResponseMessage = httpResponseMessage;
            _httpResponse = null;
            return this;
        }

        internal ReqResLogBuilder AddCollectionRespone<TCollection>(IEnumerable<TCollection> collection)
        {
            _summarizedResponse = $"{typeof(TCollection)} count = {collection.Count()}";
            return this;
        }
        internal ReqResLogBuilder AddBody(string body)
        {
            _body = body;
            return this;
        }
        internal ReqResLogBuilder AddSummarizedRespnse(string summarizedResponse)
        {
            _summarizedResponse = summarizedResponse;
            return this;
        }

        //internal void AddRequestDateTime(DateTime requestDate)
        //{
        //    _requestDate = requestDate;
        //}

        //internal void AddResponseDateTime(DateTime responseDate)
        //{
        //    _responseDate = responseDate;
        //}

        public ReqResLog Build(DateTime responsedOn)
        {
            bool isSuccess = IsSuccessful();
            int responseCode = ResponseCode();
            return new ReqResLog
            {
                IsSuccessStatusCode = isSuccess,
                Method = _httpContext.Request.Method,
                QueryString = _httpContext.Request.QueryString.ToString(),
                Path = _httpContext.Request.Path,
                Payload = _body,
                Response = _summarizedResponse,
                ResponseCode = responseCode.ToString(),
                UserName = _userName, // _config.AppName,
                RequestCorrelationId = HttpContextHelper.GetCorrelationId(_httpContext),
                RequestedOn = _requestDate,
                RespondedOn = responsedOn // _httpResponse.Headers.Date.Value.DateTime
            };
        }

        private int ResponseCode()
        {
            if (_httpResponse is not null)
                return _httpResponse.StatusCode;

            if (_httpResponseMessage is not null)
                return ((int)_httpResponseMessage.StatusCode);

            return 500;
        }

        private bool IsSuccessful()
        {
            if (_httpResponse is not null)
                return _httpResponse.StatusCode is 200 or 201;

            if (_httpResponseMessage is not null)
                return _httpResponseMessage.IsSuccessStatusCode;

            return false;
        }
    }
}
