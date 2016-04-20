using System;
using System.Threading;
using Rsc.HttpClient;
using Rsc.HttpClient.Util;

namespace Rsc.HttpClientTest
{
	class MainClass
	{
		public static HttpClientRegister Register=new HttpClientRegister();
		public static void Main (string[] args)
		{
			Console.WriteLine("Hello World!");
			var client= new NoRetryClient(TimeSpan.FromSeconds(1));
			Register.RegisterClient ("Default", client);

			var requester = new WebRequester(Register);
			requester.KeepDoingIt();
			Thread.Sleep(Timeout.Infinite);
		}
	}


}
