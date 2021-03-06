﻿namespace Machete.HL7
{
    public interface HL7Component :
        HL7Entity
    {
        Value<bool> IsEmpty { get; }
        ValueArray<string> Fields { get; }
    }
}