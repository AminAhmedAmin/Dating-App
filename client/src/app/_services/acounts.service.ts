import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import{map} from'rxjs/operators'
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {

baseUrl='https://localhost:5001/API'
//presistinglogin
private CurrentUserSource =new ReplaySubject<User>(1);
CurrentUser$ =this.CurrentUserSource.asObservable();
  constructor(private http: HttpClient) { }

  login(model:any){
    return this.http.post (this.baseUrl + '/account/Login' ,model) .pipe(  //presistinglogin
      map((response:User)=>{
        const user =response;
        if(user){
          localStorage.setItem('user',JSON.stringify(user));
          this.CurrentUserSource.next(user);
        }

      })
    )
  }



  register(model:any){
    return this.http.post (this.baseUrl + '/account/register' ,model) .pipe(
      map((User:User)=>{
        const user =User;
        if(user){
          localStorage.setItem('user',JSON.stringify(user));
          this.CurrentUserSource.next(user);
        }

      })
    )
  }

//presistinglogin
  SetCurrentUser(user:User){
    this.CurrentUserSource.next(user);
  }

logout(){
  //presistinglogin
  localStorage.removeItem('user')
  this.CurrentUserSource.next(null);

}



}
