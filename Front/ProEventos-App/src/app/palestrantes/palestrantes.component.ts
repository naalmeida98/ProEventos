import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-palestrantes', //seletor do meu componente de palestrantes
                                //que utilizarei no meu escopo principal de html
  templateUrl: './palestrantes.component.html',
  styleUrls: ['./palestrantes.component.scss']
})

export class PalestrantesComponent implements OnInit {

  public palestrantes: any;

  ngOnInit(): void { //método que será chamado antes da inicialização, antes do html ser interpretado
    this.getPalestrantes();
  }

  constructor(private http: HttpClient) { } //faz a declaração do http client para o BD

  //declaração de objetos para palestrantes
  public getPalestrantes(): void {
    this.palestrantes = [
      {
        Nome: 'Joao',
        Sobrenome: 'Silva'
      },
      {
        Nome: 'Maria',
        Sobrenome: 'Fernandes'
      }
    ]
  }



}
