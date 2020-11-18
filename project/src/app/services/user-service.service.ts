import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../entities/user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  api = 'https://localhost:44305/api/users';

  constructor(private http: HttpClient) { }

  addUser(user: User): Observable<User> {
    return this.http.post<any>(this.api + "/add", user);
  }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.api + "/Users");
  }

  delete(identity: string): any {
    return this.http.delete<any>(`${this.api + "/delete/"}${identity}`);
  }

  getUserById(identity: string): Observable<User> {
    return this.http.get<User>(`${this.api + "/User/"}${identity}`);
  }

  updateUser(user: User): Observable<User> {
    return this.http.put<any>(`${this.api + "/update/"}${user.Identity}`, user);
  }
}
