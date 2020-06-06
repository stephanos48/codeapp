export interface Ncr {
    ncrId: number;
    ncrNo: number;
    dateCreated: Date;
    ncrTypeId: number;
    customerId: number;
    customerDivisionId: number;
    supplierId: number;
    partNumber: string;
    partDescription: string;
    serailNumber: string;
    partCost: string;
    quantity: number;
    defectDescription: string;
    defectCode: string;
    mlsDivisionId: number;
    dispositionId: number;
    dispositionDate: Date;
    dispositionBy: string;
    ncrStatusId: number;
    reworkNo: string;
    reworkCompletedBy: string;
    reworkHrs: string;
    reworkPartsUsed: string;
    reworkPartsScrapped: string;
    reworkQty: number;
    reworkStatus: string;
    reworkNotes: string;
    scrapNo: string;
    scrapApprovedBy: string;
    scrapApprovalDate: Date;
    scrappedBy: string;
    scrapDate: Date;
    scrapQty: number;
    scrapStatus: string;
    scrapNotes: string;
    completionDate: Date;
    notes: string;
}