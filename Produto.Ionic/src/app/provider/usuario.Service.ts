import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable()
export class UsuarioService {

    constructor(public httpClient: HttpClient) {
      
    }
     
    sendPostRequest() {
      //---
      //IONIC E API FUNCIONANDO. PENDENTE TERMINAR LOGIN
      this.httpClient.get("http://localhost:63042/api/login/auth?login=alesfsi&senha=123"
        , {observe: 'response'})
        .subscribe(data => {
          console.log(data['body']);
         }, error => {
          console.log(error);
        });
    }

  
}