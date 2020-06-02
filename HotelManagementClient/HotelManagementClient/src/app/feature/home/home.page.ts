import { Component, OnInit } from '@angular/core';
import { HotelService } from './services/hotel.service';
import { HotelModel } from 'src/app/shared/models/hotel.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss'],
})
export class HomePage implements OnInit {

  public hotels: HotelModel[];

  constructor(private hotelService: HotelService) { }

  ngOnInit() {
    this.hotelService.getHotels().subscribe((response) => {
      this.hotels = response;

      response.forEach((data) => {
        let a = data.img;
      })
    });
  }

}
