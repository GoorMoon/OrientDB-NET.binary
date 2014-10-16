using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orient.Client.Protocol;
using Orient.Client.Protocol.Operations;

namespace Orient.Client.API.Query
{
    public class OSqlSchema
    {
        private Connection _connection;
        private string query = "select expand(classes) from metadata:schema";
        private IEnumerable<ODocument> _schema;

        internal OSqlSchema(Connection connection)
        {
            _connection = connection;
            _schema = Run();
        }

        public IEnumerable<ODocument> Properties(string @class)
        {
            var pDocument = _schema.FirstOrDefault(d => d.GetField<string>("name") == @class);
            return pDocument != null ? pDocument.GetField<HashSet<ODocument>>("properties") : null;
        }

        public IEnumerable<ODocument> Properties<T>()
        {
            var @class = typeof(T).Name;
            return Properties(@class);
        }

        private IEnumerable<ODocument> Run()
        {
            CommandPayload payload = new CommandPayload();
            payload.Type = CommandPayloadType.Sql;
            payload.Text = query;
            payload.NonTextLimit = -1;
            payload.FetchPlan = "*:0";
            payload.SerializedParams = new byte[] { 0 };

            Command operation = new Command();
            operation.OperationMode = OperationMode.Asynchronous;
            operation.ClassType = CommandClassType.Idempotent;
            operation.CommandPayload = payload;

            ODocument document = _connection.ExecuteOperation(operation);

            return document.GetField<List<ODocument>>("Content");

        }
    }
}
