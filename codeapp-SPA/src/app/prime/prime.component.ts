import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-prime',
  templateUrl: './prime.component.html',
  styleUrls: ['./prime.component.css']
})
export class PrimeComponent implements OnInit {
  jap: any = '../assets/img/jap.jpg';

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

}
