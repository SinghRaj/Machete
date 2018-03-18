﻿namespace Machete.X12Schema.V5010.Layouts
{
    using X12;


    public interface L2430_837I :
        X12Layout
    {
        Segment<SVD> LineAdjudicationInformation { get; }
        
        SegmentList<CAS> LineAdjustment { get; }
        
        Segment<DTP> LineCheckOrRemittanceDate { get; }
        
        Segment<AMT> RemainingPatientLiability { get; }
    }
}