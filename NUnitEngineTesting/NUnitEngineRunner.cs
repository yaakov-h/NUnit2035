using System;
using System.Xml;
using NUnit.Engine;

namespace NUnitEngineTesting
{
	public class NUnitEngineRunner
	{
		public static string RunAllTests(string pathToAssembly)
		{
			XmlNode xml;

			using (var activator = new CustomTestEngineActivator())
			using (var engine = activator.CreateInstance())
			{
				using (var runner = engine.GetRunner(new TestPackage(pathToAssembly)))
				{
					var filter = new TestFilterBuilder().GetFilter();
					xml = runner.Run(new NopTestEventListener(), filter);
				}
			}

			return xml.ToString();
		}


		[Serializable]
		sealed class NopTestEventListener : ITestEventListener
		{
			public void OnTestEvent(string report)
			{
			}
		}
	}
}
