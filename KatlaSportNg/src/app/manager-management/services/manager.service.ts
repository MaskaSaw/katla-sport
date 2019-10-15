import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { ManagerItem } from '../models/manager-item';

@Injectable({
  providedIn: 'root'
})
export class ManagerService {
  private url = environment.apiUrl + 'api/manager/';

  constructor(private http: HttpClient) { }

  getManagers(): Observable<Array<ManagerItem>> {
    return this.http.get<Array<ManagerItem>>(this.url);
  }

  getManager(managerid: number): Observable<ManagerItem> {
    return this.http.get<ManagerItem>(`${this.url}${managerid}`);
  }

  addManager(manager: ManagerItem, file: File): Observable<ManagerItem> {
      console.log(file);
    const formdata = new FormData();
    formdata.append('Image', file);
    formdata.append('data',JSON.stringify(manager));
    return this.http.post<ManagerItem>(`${this.url}`, formdata);
  }

  updateManager(manager: ManagerItem, file: File): Observable<Object> {
    const formdata = new FormData();
    console.log(file);
    formdata.append('Image', file);
    formdata.append('data',JSON.stringify(manager));
    return this.http.put<Object>(`${this.url}${manager.id}`, formdata);
  }

  deleteManager(managerid: number): Observable<Object> {
    return this.http.delete<Object>(`${this.url}${managerid}`);
  }
}
