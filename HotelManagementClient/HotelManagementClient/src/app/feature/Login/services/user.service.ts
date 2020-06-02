import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpParams, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IUser } from '../interfaces/user';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    constructor(private httpClient: HttpClient) { }

    public login(username: string, password: string): Observable<any | {}> {
        const url: string = environment.settings.apiUrl + "/user/login";
        const options = {
            params: new HttpParams().set("username", username).set("password", password)
        };


        return this.httpClient.get<any>(url, options);
    }

    public register(email: string, username: string, password: string): Observable<boolean | {}> {
        const url: string = environment.settings.apiUrl + "/user/register";

        const user: IUser = {
            email: email,
            username: username,
            password: password
        }

        return this.httpClient
            .post<any>(url, user);
    }
}
