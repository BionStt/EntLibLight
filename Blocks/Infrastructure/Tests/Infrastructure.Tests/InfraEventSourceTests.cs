namespace Infrastructure.Tests
{
    using System;

    using EntLibExtensions.Infrastructure;

    using NUnit.Framework;

    [TestFixture]
    [RunInApplicationDomain]
    public class InfraEventSourceTests
    {
        [Test]
        [RunInApplicationDomain]
        public void SetName()
        {
            string anyname = "anyName";

            InfraEventSource.Initialize(anyname);
            Assert.AreEqual(anyname, InfraEventSource.Log.Name);
            Assert.Throws<InvalidOperationException>(() => InfraEventSource.Initialize("anyOtherName"));
            Assert.Throws<InvalidOperationException>(() => InfraEventSource.Initialize(anyname));
        }
    }
}