import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tabs',
  templateUrl: 'tabs.page.html',
  styleUrls: ['tabs.page.scss']
})
export class TabsPage {

  constructor(public router : Router) {}

  ngOnInit() {
    this.loadPage();
  }

  loadPage() {
    let token = localStorage.getItem("PRODUTO_TOKEN");
    
    if (token == null)
    {
      this.router.navigateByUrl('/login');
    }else{
      localStorage.getItem("PRODUTO_NOMEUSUARIO");
    }
  }
}
