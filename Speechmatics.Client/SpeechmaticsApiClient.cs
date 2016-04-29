using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Speechmatics.Client.Util;

namespace Speechmatics.Client
{

    public class SpeechmaticsApiClient
    {

        readonly HttpClient http;
        Uri apiUri;
        string authToken;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        SpeechmaticsApiClient()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="http"></param>
        public SpeechmaticsApiClient(HttpClient http, Uri apiUri, string apiKey)
            : this()
        {
            Contract.Requires<ArgumentNullException>(http != null);
            Contract.Requires<ArgumentNullException>(apiUri != null);
            Contract.Requires<ArgumentNullException>(apiKey != null);

            this.http = http;
            ApiUri = apiUri;
            AuthToken = apiKey;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="apiUri"></param>
        /// <param name="apiKey"></param>
        public SpeechmaticsApiClient(Uri apiUri, string apiKey)
            : this(new HttpClient(), apiUri, apiKey)
        {
            Contract.Requires<ArgumentNullException>(apiUri != null);
            Contract.Requires<ArgumentNullException>(apiKey != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="apiKey"></param>
        public SpeechmaticsApiClient(string apiKey)
            : this(new Uri("https://api.speechmatics.com"), apiKey)
        {
            Contract.Requires<ArgumentNullException>(apiKey != null);
        }

        /// <summary>
        /// Gets the URI prefix of the Speechmatics API.
        /// </summary>
        public Uri ApiUri
        {
            get { return apiUri; }
            set { Contract.Requires<ArgumentNullException>(value != null); apiUri = value; }
        }

        /// <summary>
        /// Gets the URI prefix for v1.0 of the Speechmatics API.
        /// </summary>
        Uri ApiUriV10
        {
            get { return ApiUri.Combine("v1.0"); }
        }

        /// <summary>
        /// Gets the configured authentication token.
        /// </summary>
        public string AuthToken
        {
            get { return authToken; }
            set { Contract.Requires<ArgumentNullException>(value != null); authToken = value; }
        }

        /// <summary>
        /// Posts a new job.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="media"></param>
        /// <param name="name"></param>
        /// <param name="model"></param>
        /// <param name="notification"></param>
        /// <param name="callback"></param>
        /// <param name="meta"></param>
        /// <param name="diarisation"></param>
        /// <returns></returns>
        public async Task<JobPostResponse> PostJob(
            int userId,
            Stream media,
            string name,
            string model = "en-US",
            JobNotification? notification = null,
            Uri callback = null,
            string meta = null,
            bool? diarisation = null)
        {
            Contract.Requires<ArgumentOutOfRangeException>(userId > 0);
            Contract.Requires<ArgumentNullException>(media != null);
            Contract.Requires<ArgumentNullException>(name != null);
            Contract.Requires<ArgumentNullException>(model != null);

            using (var reqs = new HttpRequestMessage(HttpMethod.Post, ApiUriV10.Combine($"user/{userId}/jobs/?auth_token={AuthToken}")))
            {
                // build multipart body
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(media), "data_file", name);
                content.Add(new StringContent(model), "model");

                // add optional parameters
                if (notification != null)
                    content.Add(new StringContent(notification.ToEnumString()), "notification");
                if (callback != null)
                    content.Add(new StringContent(callback.ToString()), "callback");
                if (meta != null)
                    content.Add(new StringContent(meta), "meta");
                if (diarisation != null)
                    content.Add(new StringContent((bool)diarisation ? "true" : "false"), "diarisation");
                reqs.Content = content;

                // send request
                var rslt = await http.SendAsync(reqs, HttpCompletionOption.ResponseContentRead);
                if (rslt.StatusCode != HttpStatusCode.OK)
                    throw new HttpRequestException(rslt.ReasonPhrase);

                // parse resulting JSON
                var json = await rslt.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<JobPostResponse>(json);
                if (data == null)
                    throw new NullReferenceException();

                // return data
                return data;
            }
        }

        /// <summary>
        /// Gets the specified job.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public async Task<Job> GetJob(int userId, int jobId)
        {
            Contract.Requires<ArgumentOutOfRangeException>(userId > 0);
            Contract.Requires<ArgumentOutOfRangeException>(jobId > 0);

            using (var reqs = new HttpRequestMessage(HttpMethod.Get, ApiUriV10.Combine($"user/{userId}/jobs/{jobId}?auth_token={AuthToken}")))
            {
                // send request
                var rslt = await http.SendAsync(reqs, HttpCompletionOption.ResponseContentRead);
                if (rslt.StatusCode != HttpStatusCode.OK)
                    throw new HttpRequestException(rslt.ReasonPhrase);

                // parse resulting JSON
                var json = await rslt.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<JobResponse>(json)?.Job;
                if (data == null)
                    throw new NullReferenceException();

                // return data
                return data;
            }
        }

        /// <summary>
        /// Gets the transcript of the specified job.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public async Task<JobTranscript> GetTranscript(int userId, int jobId)
        {
            Contract.Requires<ArgumentOutOfRangeException>(userId > 0);
            Contract.Requires<ArgumentOutOfRangeException>(jobId > 0);

            using (var reqs = new HttpRequestMessage(HttpMethod.Get, ApiUriV10.Combine($"user/{userId}/jobs/{jobId}/transcript?auth_token={AuthToken}")))
            {
                // send request
                var rslt = await http.SendAsync(reqs, HttpCompletionOption.ResponseContentRead);
                if (rslt.StatusCode != HttpStatusCode.OK)
                    throw new HttpRequestException(rslt.ReasonPhrase);

                // parse resulting JSON
                var json = await rslt.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<JobTranscript>(json);
                if (data == null)
                    throw new NullReferenceException();

                // return data
                return data;
            }
        }

    }

}
