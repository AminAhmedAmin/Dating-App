import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountsService } from './_services/acounts.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  implements OnInit {
  title = 'Dating App';
  users :any;
  loggedin:boolean;

  constructor (private accountsservice:AccountsService){}

  ngOnInit() {
// this.getusers();
this.SetCurrentUser()
        }


        SetCurrentUser(){
          const user :User = JSON.parse(localStorage.getItem('user'));
          this.accountsservice.SetCurrentUser(user);
        }

    // getusers(){
    //   this.http.get('https://localhost:5001/API/Users').subscribe(response =>
    //   {this.users =response;
    //     console.log(response);
    //     this.loggedin=true
    //   },

    //   error =>{console.error(error);})


    //           }



}
