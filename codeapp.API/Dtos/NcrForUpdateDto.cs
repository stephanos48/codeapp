using System;

namespace codeapp.API.Dtos
{
    public class NcrForUpdateDto
    {
  public int NcrId { get; set; }

        public string NcrNo { get; set; }

        public DateTime DateCreated { get; set; }

        public int NcrTypeId { get; set; }

        public int CustomerId { get; set; }

        public int CustomerDivisionId { get; set; }

        public int SupplierId { get; set;}

        public string PartNumber { get; set; }

        public string PartDescription { get; set; }

        public string SerialNumber { get; set; }

        public string PartCost { get; set; }

        public int Quantity { get; set; }

        public string DefectDescription { get; set; }

        public string DefectCode { get; set; }

        public int MlsDivisionId { get; set; }

        public int DispositionId { get; set; }
        
        public DateTime DispositionDate { get; set; }

        public string DispositionBy { get; set; }

        public int NcrStatusId { get; set; }

        public string ReworkNo { get; set; }

        public string ReworkCompletedBy { get; set; }

        public string ReworkHrs { get; set; }

        public string ReworkPartsUsed { get; set; }

        public string ReworkPartsScrapped { get; set; }

        public int ReworkQty { get; set; }

        public string ReworkStatus { get; set; }

        public string ReworkNotes { get; set; }

        public string ScrapNo { get; set; }

        public string ScarpApprovedBy { get; set; }

        public DateTime ScrapApprovalDate { get; set; }

        public string ScarppedBy { get; set; }

        public DateTime ScrapDate { get; set; }

        public int ScrapQty { get; set; }

        public string ScrapStatus { get; set; }

        public string ScrapNotes { get; set; }

        public DateTime CompletionDate { get; set; }

        public string Notes { get; set; }
        
    }
}