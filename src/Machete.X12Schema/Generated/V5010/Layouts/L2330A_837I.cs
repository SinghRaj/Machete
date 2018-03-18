﻿namespace Machete.X12Schema.V5010.Layouts
{
    using X12;


    public interface L2330A_837I :
        X12Layout
    {
        Segment<NM1> Subscriber { get; }
        
        Segment<N3> Address { get; }
        
        Segment<N4> GeographicInformation { get; }
        
        Segment<REF> SecondaryIdentification { get; }
    }
}