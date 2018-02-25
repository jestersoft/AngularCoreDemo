import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'app-value-list',
    templateUrl: './value-list.component.html',
    styleUrls: ['./value-list.component.css']
})
export class ValueListComponent implements OnInit {
    constructor(private _httpService: Http) { }

    listValues: string[] = [];

    ngOnInit() {
        this._httpService.get('/api/values').subscribe(values => {
            this.listValues = values.json() as string[];
        });
    }
}