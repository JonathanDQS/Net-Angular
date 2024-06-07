import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CONFIGURATION } from '../constants/constants';
import { Observable } from 'rxjs';
import { Form } from '../interfaces/form';

@Injectable({
  providedIn: 'root'
})
export class FormsService {

  constructor(private http: HttpClient) { }

  getListForms(): Observable<Form[]> {
    return this.http.get<Form[]>(`${CONFIGURATION.SERVER}Forms`);
  }

  saveForm(form: Form): Observable<Form> {
    return this.http.post<Form>(`${CONFIGURATION.SERVER}Forms`, form);
  }

  saveEdit(form: Form): Observable<Form> {
    return this.http.post<Form>(`${CONFIGURATION.SERVER}Forms/Update`, form);
  }

  delete(form: Form): Observable<Form> {
    return this.http.delete<Form>(`${CONFIGURATION.SERVER}Forms/${form.id}`);
  }

  deleteField(fieldId: number): Observable<Form> {
    return this.http.delete<Form>(`${CONFIGURATION.SERVER}Forms/Field/${fieldId}`);
  }

}
