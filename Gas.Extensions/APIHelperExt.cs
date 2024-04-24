//using Newtonsoft.Json;
//using System.Net;
//using System.Net.Http.Headers;
//using System.Text;

//namespace Qms.Extensions
//{
//    public static class APIHelperExt
//    {
//        public static Task<T> GetData<T>(string url)
//        {
//            try
//            {
//                HttpClient __client = new HttpClient();
//                var mediaType = "application/json";
//                __client.BaseAddress = new Uri(url);
//                __client.DefaultRequestHeaders.Accept.Clear();
//                __client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
//                var response = __client.GetAsync(__client.BaseAddress).ConfigureAwait(false);
//                var responseResult = response.GetAwaiter().GetResult();
//                HttpStatusCode responseCode = responseResult.StatusCode;

//                if (responseCode == HttpStatusCode.OK)
//                {
//                    var apiResp = responseResult.Content.ReadAsAsync<T>();
//                    return apiResp;
//                }
//                else
//                {
//                    throw new Exception($"Failed with Status Code : {responseResult.StatusCode}", new Exception(responseResult.Content.ToString()));
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException!.Message);
//            }

//        }

//        public static Task<T> PostData<T>(string url, object model)
//        {
//            HttpClient __client = new HttpClient();
//            var mediaType = "application/json";
//            var jsonRequest = JsonConvert.SerializeObject(model);
//            var httpContent = new StringContent(jsonRequest, Encoding.UTF8, mediaType);
//            try
//            {

//                __client.BaseAddress = new Uri(url);
//                __client.DefaultRequestHeaders.Accept.Clear();
//                __client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
//                var response = __client.PostAsync(__client.BaseAddress, httpContent).ConfigureAwait(false);

//                var responseResult = response.GetAwaiter().GetResult();
//                HttpStatusCode responseCode = responseResult.StatusCode;

//                if (responseCode == HttpStatusCode.OK)
//                {
//                    var apiResp = responseResult.Content.ReadAsAsync<T>();
//                    return apiResp;
//                }
//                else
//                {
//                    throw new Exception($"Failed with Status Code : {responseResult.StatusCode}", new Exception(responseResult.Content.ToString()));
//                }

//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException!.Message);
//            }
//            finally
//            {
//                httpContent.Dispose();
//            }

//        }

//        public static Task<T> PostDataWithProblemDetails<T>(string url, object model)
//        {
//            HttpClient __client = new HttpClient();
//            var mediaType = "application/problem+json";
//            var jsonRequest = JsonConvert.SerializeObject(model);
//            var httpContent = new StringContent(jsonRequest, Encoding.UTF8, mediaType);
//            try
//            {

//                __client.BaseAddress = new Uri(url);
//                __client.DefaultRequestHeaders.Accept.Clear();
//                __client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
//                var response = __client.PostAsync(__client.BaseAddress, httpContent).ConfigureAwait(false);

//                var responseResult = response.GetAwaiter().GetResult();
//                HttpStatusCode responseCode = responseResult.StatusCode;

//                if (responseCode == HttpStatusCode.OK)
//                {
//                    var apiResp = responseResult.Content.ReadAsAsync<T>();
//                    return apiResp;
//                }
//                else
//                {
//                    throw new Exception($"Failed with Status Code : {responseResult.StatusCode}", new Exception(responseResult.Content.ToString()));
//                }

//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException!.Message);
//            }
//            finally
//            {
//                httpContent.Dispose();
//            }

//        }

//        public static Task<T> PutData<T>(string url, object model)
//        {
//            HttpClient __client = new HttpClient();
//            var mediaType = "application/json";
//            var jsonRequest = JsonConvert.SerializeObject(model);
//            var httpContent = new StringContent(jsonRequest, Encoding.UTF8, mediaType);
//            try
//            {

//                __client.BaseAddress = new Uri(url);
//                __client.DefaultRequestHeaders.Accept.Clear();
//                __client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
//                var response = __client.PutAsync(__client.BaseAddress, httpContent).ConfigureAwait(false);

//                var responseResult = response.GetAwaiter().GetResult();
//                HttpStatusCode responseCode = responseResult.StatusCode;

//                if (responseCode == HttpStatusCode.OK)
//                {
//                    var apiResp = responseResult.Content.ReadAsAsync<T>();
//                    return apiResp;
//                }
//                else
//                {
//                    throw new Exception($"Failed with Status Code : {responseResult.StatusCode}", new Exception(responseResult.Content.ToString()));
//                }

//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException!.Message);
//            }
//            finally
//            {
//                httpContent.Dispose();
//            }

//        }

//        public static Task<T> PUTData<T>(string url, object model)
//        {
//            HttpClient __client = new HttpClient();
//            var mediaType = "application/json";
//            var jsonRequest = JsonConvert.SerializeObject(model);
//            var httpContent = new StringContent(jsonRequest, Encoding.UTF8, mediaType);
//            try
//            {

//                __client.BaseAddress = new Uri(url);
//                __client.DefaultRequestHeaders.Accept.Clear();
//                __client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
//                var response = __client.PutAsync(__client.BaseAddress, httpContent).ConfigureAwait(false);

//                var responseResult = response.GetAwaiter().GetResult();
//                HttpStatusCode responseCode = responseResult.StatusCode;

//                if (responseCode == HttpStatusCode.OK)
//                {
//                    var apiResp = responseResult.Content.ReadAsAsync<T>();
//                    return apiResp;
//                }
//                else
//                {
//                    throw new Exception($"Failed with Status Code : {responseResult.StatusCode}", new Exception(responseResult.Content.ToString()));
//                }

//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException!.Message);
//            }
//            finally
//            {
//                httpContent.Dispose();
//            }

//        }

//        public static Task<T> DeleteData<T>(string url)
//        {
//            try
//            {
//                HttpClient __client = new HttpClient();
//                var mediaType = "application/json";
//                __client.BaseAddress = new Uri(url);
//                __client.DefaultRequestHeaders.Accept.Clear();
//                __client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
//                var response = __client.DeleteAsync(__client.BaseAddress).ConfigureAwait(false);
//                var responseResult = response.GetAwaiter().GetResult();
//                HttpStatusCode responseCode = responseResult.StatusCode;

//                if (responseCode == HttpStatusCode.OK)
//                {
//                    var apiResp = responseResult.Content.ReadAsAsync<T>();
//                    return apiResp;
//                }
//                else
//                {
//                    throw new Exception($"Failed with Status Code : {responseResult.StatusCode}", new Exception(responseResult.Content.ToString()));
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException!.Message);
//            }

//        }

//    }

//}
