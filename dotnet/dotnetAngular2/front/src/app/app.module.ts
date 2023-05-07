import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

// Material imports
import { ToolbarComponent } from './toolbar/toolbar.component'; // https://material.angular.io/components/toolbar/api

import { MatToolbarModule } from '@angular/material/toolbar';
import { CarComponent } from './car/car.component';

@NgModule({
  declarations: [AppComponent, ToolbarComponent, CarComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: [MatToolbarModule],
})
export class AppModule {}
