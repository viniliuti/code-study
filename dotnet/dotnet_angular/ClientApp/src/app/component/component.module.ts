import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarComponent } from './car/car.component';
import { RouterModule } from '@angular/router';

@NgModule({
	declarations: [CarComponent],
	imports: [
		CommonModule,
		RouterModule.forRoot([{ path: 'car', component: CarComponent }]),
	],
})
export class ComponentModule {}
