// This file was automatically generated and may be regenerated at any
// time. To ensure any changes are retained, modify the tool with any segment/component/group/field name
// or type changes.
namespace Machete.HL7Schema.V26
{
    using HL7;

    /// <summary>
    /// MFN_M09_MF_TEST_CATEGORICAL (Group) - 
    /// </summary>
    public interface MFN_M09_MF_TEST_CATEGORICAL :
        HL7V26Layout
    {
        /// <summary>
        /// MFE
        /// </summary>
        Segment<MFE> MFE { get; }

        /// <summary>
        /// OM1
        /// </summary>
        Segment<OM1> OM1 { get; }

        /// <summary>
        /// MF_TEST_CAT_DETAIL
        /// </summary>
        Layout<MFN_M09_MF_TEST_CAT_DETAIL> MfTestCatDetail { get; }
    }
}