import { PhotoAudit } from './photoaudit';

export interface Audit {
    auditId: number;
    auditNo: string;
    auditTypeId: number;
    auditName: string;
    auditScope: string;
    plannedAuditStartDate: Date;
    plannedAuditEndDate: Date;
    actualAuditStartDate: Date;
    actualAuditEndDate: Date;
    photoUrl: string;
    auditors: string;
    auditReason: string;
    auditSummary: string;
    notes: string;
    photoaudits?: PhotoAudit[];
}
