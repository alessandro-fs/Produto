import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tab3',
  templateUrl: 'tab3.page.html',
  styleUrls: ['tab3.page.scss']
})
export class Tab3Page {

  constructor(public router: Router) {}
  nomeUsuario : string = "";
  ngOnInit() {
    this.loadPage();
  }

  loadPage()
  {
    this.nomeUsuario = localStorage.getItem("PRODUTO_NOMEUSUARIO");
  }
  logOff()
  {
    localStorage.clear();
    this.router.navigateByUrl("/login");
  }
}
