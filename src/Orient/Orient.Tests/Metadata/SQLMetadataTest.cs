using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orient.Client;

namespace Orient.Tests.Metadata
{
    [TestClass]
    public class SQLMetadataTest
    {
        [TestMethod]
        [TestCategory("Metadata")]
        public void QuerySchemaClasses()
        {
            using (var context = new TestDatabaseContext())
            using(var database = new ODatabase(TestConnection.GlobalTestDatabaseAlias))
            {
                var document = database
                    .Query("select expand(classes) from metadata:schema");
                Assert.IsTrue(document.Count > 0); 
            }
        }

        [TestMethod]
        [TestCategory("Metadata")]
        public void QuerySchemaProperties()
        {
            using (var context = new TestDatabaseContext())
            using(var database = new ODatabase(TestConnection.GlobalTestDatabaseAlias))
            {
                var document = database
                    .Query("select expand(properties) from (select expand(classes) from metadata:schema) where name = 'OUser'");
                Assert.IsTrue(document.Count > 0); 
            }
        }

        [TestMethod]
        [TestCategory("Metadata")]
        public void QueryIndexes()
        {
            using (var context = new TestDatabaseContext())
            using(var database = new ODatabase(TestConnection.GlobalTestDatabaseAlias))
            {
                var document = database
                    .Query("select expand(indexes) from metadata:indexmanager");
                Assert.IsTrue(document.Count > 0); 
            }
        }

        [TestMethod]
        [TestCategory("Metadata")]
        [ExpectedException(typeof(OException))]
        public void QueryMetadataNotSupported()
        {
            using (var context = new TestDatabaseContext())
            using(var database = new ODatabase(TestConnection.GlobalTestDatabaseAlias))
            {
                var document = database
                    .Query("select expand(indexes) from metadata:blaaa");
            }
        }
    }
}
