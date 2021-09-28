import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventosComponent } from './eventos/eventos.component';
import { PalestrantesComponent } from './palestrantes/palestrantes.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent, //declara esse componente
    EventosComponent,
    PalestrantesComponent,
    NavComponent
  ],
  imports: [ //importa esses módulos
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule, //auxilia na referência dentro do componente
    CollapseModule.forRoot(), //para estilizar paginas com animações
    FormsModule //para usar com binding do tipo [()]
  ],
  providers: [],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
  bootstrap: [AppComponent] //inicializa a nossa aplicação com esse componente
})
export class AppModule { }
