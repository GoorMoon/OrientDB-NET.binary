using System;
using System.Linq;
using System.Collections.Generic;
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
            using (var database = new ODatabase(TestConnection.GlobalTestDatabaseAlias))
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
            using (var database = new ODatabase(TestConnection.GlobalTestDatabaseAlias))
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
            using (var database = new ODatabase(TestConnection.GlobalTestDatabaseAlias))
            {
                var document = database
                    .Query("select expand(indexes) from metadata:indexmanager");
                Assert.IsTrue(document.Count > 0);
            }
        }

        [TestMethod]
        [TestCategory("Metadata")]
        public void ShouldCreateAndRetrieveSchemaFromDatabase()
        {
            using (var context = new TestDatabaseContext())
            using (var database = new ODatabase(TestConnection.GlobalTestDatabaseAlias))
            {
                database
                    .Create
                    .Class<TestVertexClass>()
                    .CreateProperties()
                    .Run();

                var document = database.Schema.Properties<TestVertexClass>();
                
                validateSchema("Bool", OType.Boolean, document);
                validateSchema("Float1", OType.Float, document);
                validateSchema("Float", OType.Float, document);
                validateSchema("Foo", OType.String, document);
                validateSchema("Bar", OType.Integer, document);
                validateSchema("Long", OType.Long, document);
                validateSchema("Long1", OType.Long, document);
                validateSchema("Short", OType.Short, document);
                validateSchema("Short1", OType.Short, document);
                validateSchema("Double", OType.Double, document);
                validateSchema("Datetime", OType.DateTime, document);
                validateSchema("Binary", OType.Binary, document);
                validateSchema("Link", OType.Link, document);
                validateSchema("Byte", OType.Byte, document);
                validateSchema("Char", OType.Byte, document);
                validateSchema("Decimal", OType.Decimal, document);
                validateSchema("Document", OType.Embedded, document);
                validateSchema("LinkList_list", OType.LinkList, document);
                validateSchema("LinkList_ienumeratable", OType.LinkList, document);
                validateSchema("LinkMap", OType.LinkMap, document);
                validateSchema("EmbeddedMap", OType.EmbeddedMap, document);
                validateSchema("EmbededList_roc", OType.EmbeddedList, document);
                validateSchema("LinkedSet", OType.LinkSet, document);
                validateSchema("EmbeddedSet", OType.EmbeddedSet, document);
                validateSchema("EmbeddedSet_iset", OType.EmbeddedSet, document);
                validateSchema("EmbeddedList_ilist", OType.EmbeddedList, document);
            }
        }

        [TestMethod]
        [TestCategory("Metadata")]
        [ExpectedException(typeof(OException))]
        public void QueryMetadataNotSupported()
        {
            using (var context = new TestDatabaseContext())
            using (var database = new ODatabase(TestConnection.GlobalTestDatabaseAlias))
            {
                var document = database
                    .Query("select expand(indexes) from metadata:blaaa");
            }
        }

        private void validateSchema(string fieldName, OType type, IEnumerable<ODocument> document)
        {
            Assert.IsTrue(document.Any(d => d.GetField<string>("name") == fieldName));
            Assert.AreEqual<OType>(type, document.FirstOrDefault(d => d.GetField<string>("name") == fieldName).GetField<OType>("type"));
        }
    }
}
