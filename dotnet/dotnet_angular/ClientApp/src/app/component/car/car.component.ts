import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Car } from 'src/app/entities/car';

@Component({
	selector: 'app-car',
	templateUrl: './car.component.html',
	styleUrls: ['./car.component.css'],
})
export class CarComponent implements OnInit {
	private _http: HttpClient;
	private _baseUrl: string;

	constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
		this._http = http;
		this._baseUrl = baseUrl;
	}

	ngOnInit(): void {
		this._http.get<Car[]>(this._baseUrl + '/car').subscribe({
			complete: () => console.info,
			error: (e) => console.error(e),
		});
	}
}
