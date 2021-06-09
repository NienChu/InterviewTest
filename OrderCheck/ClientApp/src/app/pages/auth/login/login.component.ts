import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../../../shared-services/api-service/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  account: string;
  password: string;

  constructor(private accountService: AccountService,
    private router: Router) { }

  ngOnInit(): void {
  }

  onLogin() {
    this.accountService.login({ username: this.account, password: this.password })
      .subscribe(res => {
        this.router.navigate(['/order']);
      }, error => console.log(error.message));
  }
}
