import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { HomePage } from './home.page';
import { SharedModule } from 'src/app/shared/shared.module';
import { HotelAddComponent } from './component/hotel-add/hotel-add.component';

@NgModule({
  imports: [CommonModule, FormsModule, IonicModule, SharedModule],
  declarations: [HomePage, HotelAddComponent],
})
export class HomePageModule {}
