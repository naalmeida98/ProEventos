import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any;

  constructor(private http: HttpClient) { } //faz a declaração do http client para o BD

  ngOnInit(): void { //método que será chamado antes da inicialização, antes do html ser interpretado
    this.getEventos();
  }

  public getEventos(): void { //integração com BD
    this.http.get('https://localhost:5001/api/evento').subscribe(
      response => this.eventos = response,
      error => console.log(error)

    ); //me inscrevo nesse http
  }




}
