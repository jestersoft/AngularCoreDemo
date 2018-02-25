import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'app-main-menu',
    templateUrl: './main-menu.component.html',
    styleUrls: ['./main-menu.component.css']
})
export class MainMenuComponent implements OnInit {
    constructor(private _httpService: Http) { }

    menuValues: string[] = [];

    ngOnInit() {
        this._httpService.get('/api/menu').subscribe(values => {
            this.menuValues = values.json() as string[];
        });
    }
}