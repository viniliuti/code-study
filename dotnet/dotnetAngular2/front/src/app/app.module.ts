import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

// Material imports
import { ToolbarComponent } from './toolbar/toolbar.component'; // https://material.angular.io/components/toolbar/api

import { CarComponent } from './car/car.component';
import { CustomMaterialModule } from './custom-material/custom-material.module';

@NgModule({
  declarations: [AppComponent, ToolbarComponent, CarComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CustomMaterialModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
