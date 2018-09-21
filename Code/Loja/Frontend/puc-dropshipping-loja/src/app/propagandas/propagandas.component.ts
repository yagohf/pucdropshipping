import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-propagandas',
  templateUrl: './propagandas.component.html',
  styleUrls: ['./propagandas.component.css']
})
export class PropagandasComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  images = [1, 2, 3].map(() => `https://picsum.photos/900/500?random&t=${Math.random()}`);
}
