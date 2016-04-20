using System;
using System.Collections.Generic;
using Rsc.HttpClient.Util;

namespace Rsc.HttpClientTest
{
	public static class CorrelationHeaderFactory
	{
		private const string Key = "x-correlation-id";
		public static IEnumerable<Header> Create(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				return CreateHeader(Guid.NewGuid().ToString());
			}
			return CreateHeader(value);
		}

		private static IEnumerable<Header> CreateHeader(string value)
		{
			return new[] {new Header(Key, new[] {value})};
		}
	}
}

