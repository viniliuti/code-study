import { Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'dotnetAngular';

  @ViewChild('sidenav', { static: false })
  sidenav!: MatSidenav;

  clicando() {
    this.sidenav.toggle();

    console.log('clicando');
  }
}
