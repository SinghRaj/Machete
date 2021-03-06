namespace Machete.HL7.Testing
{
    using System.Linq;
    using Machete.Testing;


    public class HL7MacheteTestHarness<TVersion, TSchema> :
        IMacheteTestHarness<TSchema>
        where TSchema : HL7Entity
        where TVersion : TSchema
    {
        static readonly MacheteTestHarness<TSchema> _harness = new Harness();

        public ISchema<TSchema> Schema => _harness.Schema;
        public IParser<TSchema> Parser => _harness.Parser;
        public IStructure<TSchema> Structure => _harness.Structure;

        public string CleanupText(string text)
        {
            string cleaned = text
                .Replace("\r\n", "\r")
                .Replace("\n", "\r")
                .Replace("\r\r", "\r")
                .Trim('\r', '\n');

            string trimmed = string.Join("\r",
                cleaned.Split('\r').Select(line => line.TrimEnd('|')).ToArray());

            return trimmed;
        }


        class Harness :
            MacheteTestHarness<TSchema>
        {
            protected override ISchema<TSchema> CreateSchema()
            {
                return Machete.Schema.Factory.CreateHL7<TSchema>(cfg => cfg.AddFromNamespaceContaining<TVersion>());
            }

            protected override IParser<TSchema> CreateParser(ISchema<TSchema> schema)
            {
                return Machete.Parser.Factory.CreateHL7(schema);
            }

            protected override IStructure<TSchema> CreateStructure(ISchema<TSchema> schema)
            {
                return Machete.Structure.Factory.CreateHL7(schema, cfg => cfg.AddFromNamespaceContaining<TVersion>());
            }
        }
    }
}