import { Component } from '@angular/core';

//componentes que decoram meu AppComponent
@Component({
  selector: 'app-root', //seletor que está no meu index.html
  templateUrl: './app.component.html', //faz referência ao arquivo app.component.html que terá códigos html da aplicação
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ProEventos-App';
}
