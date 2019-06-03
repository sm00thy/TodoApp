import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {TodoItem} from '../model/todoItem';
import { map } from 'rxjs/operators';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  private apiUrl = 'https://localhost:5001/items/';

  constructor(private http: HttpClient) {
  }

 public getItems(): Observable<any> {
   return this.http.get<TodoItem[]>(this.apiUrl + 'all')
     .pipe(map((res) => {
       return res;
     }));
 }

 public getItem(id: string) {
   return this.http.get(this.apiUrl + id);
 }

  public postItem(item: any): Observable<any> {
    const reqHeader = new HttpHeaders({'Content-Type': 'application/json'});
    return this.http.post(this.apiUrl + 'create', item,
      {headers: reqHeader});
  }

  public update(item: any): Observable<any> {
    return this.http.put(this.apiUrl, item);
  }

  public deleteItem(id: string) {
    return this.http.delete(this.apiUrl + id);
  }
}
