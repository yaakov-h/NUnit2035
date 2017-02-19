using System.IO;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace NUnitEngineTesting
{
	class NUnitEngineRunnerTest
	{
		[Test]
		public void NUnitIssue2035()
		{
			Assert.That(true);

			var pathToAssembly = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestAssembly.dll");
			var xml = NUnitEngineRunner.RunAllTests(pathToAssembly);

			Assert.That(false);
		}
	}
}
