﻿namespace Snowflake.Identifier
{
    public class IdentifiedMetadata : IIdentifiedMetadata
    {

        public string IdentifierName { get; }
        public string ValueType { get; }
        public string Value { get; }

        public IdentifiedMetadata(string identifierName, string valueType, string value)
        {
            this.IdentifierName = identifierName;
            this.ValueType = valueType;
            this.Value = value;
        }
    }
}