import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
	selector: 'app-car',
	templateUrl: './car.component.html',
	styleUrls: ['./car.component.css'],
})
export class CarComponent implements OnInit {
	private _http: HttpClient;
	private _baseUrl: string;

	constructor(
		http: HttpClient,
		@Inject('BASE_URL') baseUrl: string
	) {
		this._http = http;
		this._baseUrl = baseUrl;
	}

	ngOnInit(): void {
		this._http.get<boolean>(
			this._baseUrl + 'api/car'
		).subscribe({
			complete: () => console.info,
			error: (e) => console.error(e)
		});
	}
}
