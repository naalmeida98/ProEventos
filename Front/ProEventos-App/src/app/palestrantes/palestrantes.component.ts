import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-palestrantes', //seletor do meu componente de palestrantes
                                //que utilizarei no meu escopo principal de html
  templateUrl: './palestrantes.component.html',
  styleUrls: ['./palestrantes.component.scss']
})
export class PalestrantesComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
