using NUnit.Framework;
using Beaufort.Configuration;

namespace Beaufort_Test.Configuration
{
  [TestFixture]
  [Category( "ConfiguredObject" )]
  class ConfiguredObject_Test
  {
    //-------------------------------------------------------------------------

    class ConfiguredObjectMock : ConfiguredObject
    {
      public bool IsConfigured { get; private set; }

      public override void Configure( IValueStore valueStore )
      {
        IsConfigured = true;
      }
    }

    ConfiguredObjectMock TestObject;

    //-------------------------------------------------------------------------

    [SetUp]
    public void SetUp()
    {
      TestObject = new ConfiguredObjectMock();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ConfigureIsCalled()
    {
      TestObject.Configure();

      Assert.True( TestObject.IsConfigured );
    }

    //-------------------------------------------------------------------------
  }
}
