import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { HotelService } from '../../services/hotel.service';

@Component({
  selector: 'app-hotel-add',
  templateUrl: './hotel-add.component.html',
  styleUrls: ['./hotel-add.component.scss'],
})
export class HotelAddComponent implements OnInit {

  public formGroup: FormGroup;

  constructor(private readonly formBuilder: FormBuilder, private readonly hotelService: HotelService) { }

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      img: [''],
    });
  }

  public submit(){
    this.hotelService.saveHotel(this.formGroup.get('img').value).subscribe();
  }

}
