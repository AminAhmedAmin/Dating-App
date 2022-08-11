import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountsService } from '../_services/acounts.service';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {

  constructor(private accountservice:AccountsService ) { }

  model:any ={};
  @Input() usersfromhomecompnant:any;
  @Output() CancelRegister =new EventEmitter();

  ngOnInit(): void {
  }

  register(){
    this.accountservice.register(this.model).subscribe(response=>
      {console.log(response);
        this.Cancel()
      },error =>
      {console.log(error)}
      )

    console.log(this.model);
  }

  Cancel(){
    console.log("canceled")
    this.CancelRegister.emit(false);
  }



}
