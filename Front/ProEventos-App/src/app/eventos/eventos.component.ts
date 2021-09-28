import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  widthImg:number = 150;
  marginImg:number = 2;
  openImg:boolean = true;
  private _filtroLista: string = '';

  constructor(private http: HttpClient) { } //faz a declaração do http client para o BD

  ngOnInit(): void { //método que será chamado antes da inicialização, antes do html ser interpretado
    this.getEventos();
  }

  public getEventos(): void { //integração com BD
    this.http.get('https://localhost:5001/api/evento').subscribe(
    response => {
      this.eventos = response;
    },
    error => console.log(error)
    ); //me inscrevo nesse http
  }

  public get filtroLista(){
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.eventos = this.filtroLista ? this.filtrarEventos(this._filtroLista) : this.getEventos();
  }

  public filtrarEventos(filtro: string): any{
    filtro = filtro.toLocaleLowerCase(); //coloco tudo em minúsculo
    return this.eventos.filter(
      (      evento: { tema: string; }) => evento.tema.toLocaleLowerCase().indexOf(filtro) !== -1
    );
  }

  public clickImg(): void{
    this.openImg = !this.openImg; //toda vez que clicar no button de mostrar imagem, o seu estado
    //será modificado
  }






}
