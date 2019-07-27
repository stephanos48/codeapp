export interface Scrum {
    id: number;
    createdBy: string;
    dateCreated: Date;
    responsibleId: number;
    responsible: string;
    action: string;
    dueDate: Date;
    completionDate: Date;
    notes: string;
}
