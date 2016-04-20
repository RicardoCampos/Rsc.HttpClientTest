using System;
using System.Threading;
using System.Threading.Tasks;
using Rsc.HttpClient.Util;

namespace Rsc.HttpClientTest
{
	class WebRequester
	{
		//NOTE: Change this if you just want to run this locally and not in Docker.
		string _url="http://nodeapp:3000";
		int _requestCount;
	    readonly IHttpClientRegister _register;
		const string Default="Default";

	    readonly HttpRequestOptions _options = new HttpRequestOptions
		{
			AddHeadersFunc = () => {return CorrelationHeaderFactory.Create(null);}
		};

		public WebRequester (IHttpClientRegister register)
		{
			_register = register;
		}

		public void KeepDoingIt()
		{
			var processors = System.Environment.ProcessorCount;
			var tasks = new Task[processors];

			for (int i = 0; i < processors; i++)
			{
				tasks [i] = Task.Run (async () => await PleaseDoIt ());
			}

			Task.WaitAll (tasks);
		}

		public async Task PleaseDoIt()
		{
			while (true)
			{
				await DoIt();
				Thread.Sleep (1);
			}
		}

		public async Task DoIt()
		{
			var client = _register.GetClient(Default);
			if(client.AllowRequest())
			{
				await client.GetStringAsync(_url,_options);
				Interlocked.Increment (ref _requestCount);
				Console.WriteLine(string.Format("Request # {0}.",_requestCount));
			}
		}
	}


}
