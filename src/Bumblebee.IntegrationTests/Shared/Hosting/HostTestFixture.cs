﻿using System;

using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Shared.Hosting
{
	[TestFixture]
	public abstract class HostTestFixture
	{
		private IHost _host;

		protected HostTestFixture() : this("http://localhost:50001")
		{
		}

		protected HostTestFixture(string baseUrl)
		{
			BaseUrl = baseUrl;
		}

		[TestFixtureSetUp]
		public void Init()
		{
			_host = new Host(new Uri(BaseUrl));
			_host.Start();
		}

		[TestFixtureTearDown]
		public void Dispose()
		{
			_host.Stop();
		}

		protected virtual string GetUrl(string page)
		{
			return String.Format("{0}{1}{2}", BaseUrl, "/Content/", page);
		}

		protected string BaseUrl { get; private set; }
	}
}
