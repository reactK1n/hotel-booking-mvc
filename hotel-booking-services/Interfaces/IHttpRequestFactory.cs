using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace hotel_booking_services.Interfaces
{
	public interface IHttpRequestFactory
	{
		/// <summary>
		/// Makes a HttpDelete request to the api with baseURl
		/// to delete an entity of type TRes from the database
		/// name-identifiers should be passed as query parameter in url
		/// </summary>
		/// <typeparam name="TRes"></typeparam>
		/// <param name="requestUrl"></param>
		/// <param name="baseUrl"></param>
		/// <returns>A BasicResponse<TRes> object that has a success field thats is ture if only the request succeded</returns>
		Task<TRes> DeleteRequestAsync<TRes>(string requestUrl, string baseUrl = null) where TRes : class;

		/// <summary>
		/// Makes a HttpGet request to the api with baseUrl to 
		/// to search for the eneity of type TRes swith name-identifier
		/// which is passed in the url
		/// a TRes object         /// </summary>
		/// <typeparam name="TRes"></typeparam>
		/// <param name="requestUrl"></param>
		/// <param name="baseUrl"></param>
		/// <returns>A BasicResponse<TRes> object that has a success field thats is ture if only the request succeded</returns>
		Task<TRes> GetRequestAsync<TRes>(string requestUrl, string baseUrl = null) where TRes : class;

		/// <summary>
		/// Makes a HttpPost request to the api with baseUrl 
		/// with a TReq entity while expecting a TRes entity back from the api
		/// TReq -Request value(s) sending to the api
		/// TRes -Expected value(s) form api
		/// </summary>
		/// <typeparam name="TReq"></typeparam>
		/// <typeparam name="TRes"></typeparam>
		/// <param name="requestUrl"></param>
		/// <param name="content"></param>
		/// <param name="baseUrl"></param>
		/// <returns>A BasicResponse<TRes> object that has a success field thats is ture if only the request succeded</returns>
		Task<TRes> PostRequestAsync<TReq, TRes>(string requestUrl, TReq content, string baseUrl = null)
			where TReq : class
			where TRes : class;

		/// <summary>
		/// Makes a HttpPost to the api with baseUrl
		/// Send a file of the IFormFile format to the api
		/// which will give back a uri
		/// </summary>
		/// <typeparam name="TReq"></typeparam>
		/// <typeparam name="TRes"></typeparam>
		/// <param name="requestUrl"></param>
		/// <param name="file"></param>
		/// <param name="baseUrl"></param>
		/// <returns>A BasicResponse<TRes> object that has a success field thats is ture if only the request succeded</returns>
		Task<TRes> UploadFileAsync<TReq, TRes>(string requestUrl, TReq file, string baseUrl = null)
			where TReq : IFormFile
			where TRes : class;

		Task<TRes> UpdateRequestAsync<TReq, TRes>(string requestUrl, TReq content, string baseUrl = null) 
			where TRes : class 
			where TReq : class;

	}
}