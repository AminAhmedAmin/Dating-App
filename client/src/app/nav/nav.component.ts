import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AccountsService } from '../_services/acounts.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor( public accountservices :AccountsService ) { }

  ngOnInit(): void {
    }

  model:any ={}
  


  Login(){
      this.accountservices.login(this.model).subscribe(response =>
        {
          console.log(response);


        },

        error =>{console.error(error);})





  }



  Logout(){


        this.accountservices.logout();


        }




}
