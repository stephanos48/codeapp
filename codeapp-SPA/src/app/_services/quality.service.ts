import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { Ncr } from '../_models/ncr';
import { Audit } from '../_models/audit';
import { Finding } from '../_models/finding';

@Injectable({
  providedIn: 'root'
})
export class QualityService {
  baseUrl = environment.apiUrl;
  audit: any;
  currentAudit: Audit;
  photoUrl = new BehaviorSubject<string>('../../assets/user.png');
  currentPhotoUrl = this.photoUrl.asObservable();

constructor(private http: HttpClient) { }

changeAuditPhoto(photoUrl: string) {
  this.photoUrl.next(photoUrl);
}

getNcrs() {
  return this.http.get(this.baseUrl + 'ncrs/getNcrs');
}

updateNcr(id: number, ncr: Ncr) {
  return this.http.put(this.baseUrl + 'ncrs/' + id, ncr);
}

createNcr(ncr: Ncr) {
  return this.http.post(this.baseUrl + 'ncrs/createNcr', ncr);
}

getNcr(id): Observable<Ncr> {
  return this.http.get<Ncr>(this.baseUrl + 'ncrs/' + id);
}

deleteNcr(id: number, ncr: Ncr) {
  return this.http.post(this.baseUrl + 'ncrs/' + id, ncr);
}

getAudits() {
  return this.http.get(this.baseUrl + 'audit/getAudits');
}

updateAudit(id: number, audit: Audit) {
  return this.http.put(this.baseUrl + 'audit/' + id, audit);
}

createAudit(audit: Audit) {
  return this.http.post(this.baseUrl + 'audit/createAudit', audit);
}

getAudit(id): Observable<Audit> {
  return this.http.get<Audit>(this.baseUrl + 'audit/' + id);
}

deleteAudit(id: number, audit: Audit) {
  return this.http.post(this.baseUrl + 'audit/' + id, audit);
}

getAuditTypes() {
  return this.http.get(this.baseUrl + 'AuditTypes/getAuditTypes');
}

getFindings() {
  return this.http.get(this.baseUrl + 'findings/getFindings');
}

updateFinding(id: number, finding: Finding) {
  return this.http.put(this.baseUrl + 'findings/' + id, finding);
}

createFinding(finding: Finding) {
  return this.http.post(this.baseUrl + 'finding/createFinding', finding);
}

getFinding(id): Observable<Finding> {
  return this.http.get<Finding>(this.baseUrl + 'Finding/' + id);
}

deleteFinding(id: number, finding: Finding) {
  return this.http.post(this.baseUrl + 'finding/' + id, finding);
}

getFindingTypes() {
  return this.http.get(this.baseUrl + 'findingTypes/getFindingTypes');
}

setMainPhoto(auditId: number, id: number) {
  return this.http.post(this.baseUrl + 'audit/' + auditId + '/photoaudits/' + id + '/setMain', {});
}

deletePhoto(auditId: number, id: number) {
  return this.http.delete(this.baseUrl + 'audit/' + auditId + '/photoaudits/' + id);
}

}
