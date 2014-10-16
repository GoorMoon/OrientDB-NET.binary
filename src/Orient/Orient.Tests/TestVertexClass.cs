using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orient.Client;

namespace Orient.Tests
{
    public class TestVertexClass
    {
        public bool Bool { get; set; }
        public Single Float1 { get; set; }
        public float Float { get; set; }
        public string Foo { get; set; }
        public int Bar { get; set; }
        public long Long { get; set; }
        public Int64 Long1 { get; set; }
        public short Short { get; set; }
        public Int16 Short1 { get; set; }
        public double Double { get; set; }
        public DateTime Datetime { get; set; }
        public byte[] Binary { get; set; }
        public ORID Link { get; set; }
        public Byte Byte { get; set; }
        public Char Char { get; set; }
        public Decimal Decimal { get; set; }
        public ODocument Document { get; set; }
        public List<ORID> LinkList_list { get; set; }
        public Dictionary<string, ORID> LinkMap { get; set; }
        public Dictionary<string, ODocument> EmbeddedMap { get; set; }
        public HashSet<ORID> LinkedSet { get; set; }
        public HashSet<ODocument> EmbeddedSet { get; set; }

    }

    public class TestVertexClass2
    {
        public string Foo { get; set; }
        public int Bar { get; set; }
    }
}
