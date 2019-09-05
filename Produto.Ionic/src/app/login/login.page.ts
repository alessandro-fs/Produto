import { UsuarioService } from './../provider/usuario.Service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: 'login.page.html',
  styleUrls: ['login.page.scss'],
})
export class LoginPage implements OnInit {
  txtLogin : string = "";
  txtSenha : string = "";
  constructor(public router : Router, private usuarioService : UsuarioService) { }

  ngOnInit() {
    
  }
    autenticaUsuario()
    {
      this.usuarioService.sendPostRequest();
      localStorage.setItem("PRODUTO_TOKEN", "123456");
      localStorage.setItem("PRODUTO_NOMEUSUARIO", this.txtLogin);
      this.router.navigateByUrl('/tabs');
      this.txtLogin = "";
      this.txtSenha = "";
    }
}
