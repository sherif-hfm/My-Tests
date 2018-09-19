using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallOracleStoredProcedure
{
    class SearchParameters
    {
        [ParametersMapper(ParameterName = "pTransfer_From_Department_Code", MapperTemplates = "")]
        public decimal TransferFromDepartmentCode { get; set; }
    }

    class SearchParametersPrnt
    {
        [ParametersMapper(ParameterName = "pREFERENCE_NUMBER_old", MapperTemplates = "")]
        public string ReferenceNo { get; set; }

        [ParametersMapper(IsContainer = true, MapperTemplates = "")]
        public SearchParameters2 SearchParameters { get; set; }
    }

    class SearchParameters2
    {
        [ParametersMapper(ParameterName = "pREFERENCE_NUMBER", MapperTemplates = "")]
        public string ReferenceNo { get; set; }

        [ParametersMapper(ParameterName = "pTRANSFER_SEQUENCE", MapperTemplates = "")]
        public decimal TransferSequence { get; set; }
    }

    public class SearchFollowDocsResult
    {
        [DataFieldMapper(FieldName = "REFERENCE_NUMBER", MapperTemplates = "")]
        public string RefNumber { get; set; }

        [DataFieldMapper(FieldName = "TRANSFER_SEQUENCE", MapperTemplates = "")]
        public decimal RefSequence { get; set; }

        [DataFieldMapper(IsContainer = true, MapperTemplates = "")]
        public DocDltInfo DocDltInfo { get; set; }
    }

    public class DocDltInfo
    {
        [DataFieldMapper(FieldName = "TRANSFER_NUMBER", MapperTemplates = "")]
        public string TransferNumber { get; set; }

        [DataFieldMapper(FieldName = "TRANSFER_TO_DEPARTMENT_CODE", MapperTemplates = "")]
        public string TransferToDepartmentCode { get; set; }

        [DataFieldMapper(FieldName = "LETTER_CONTENTS", MapperTemplates = "")]
        public string LetterContents { get; set; }
    }
}
