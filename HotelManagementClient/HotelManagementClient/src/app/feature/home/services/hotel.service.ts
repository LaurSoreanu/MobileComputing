import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HotelModel } from 'src/app/shared/models/hotel.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class HotelService {
    constructor(private httpClient: HttpClient) { }

    public getHotels(): Observable<HotelModel[]> {
        const url: string = environment.settings.apiUrl + "/hotel";

        return this.httpClient.get<HotelModel[]>(url);
    }

    public saveHotel(path: any): Observable<boolean | {}> {
        const url: string = environment.settings.apiUrl + "/hotel";

        // const user: IUser = {
        //     email: email,
        //     username: username,
        //     password: password
        // }
        const hotel: HotelModel = {
            name: '',
            img: path.toString(),
            description: ''
        };

        return this.httpClient.post<any>(url, hotel);
    }
}