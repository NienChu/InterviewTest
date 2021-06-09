import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private url = 'api/Account';

  constructor(private httpClient: HttpClient) { }

  public login(model: { 'username': string, 'password':string}) {
    return this.httpClient.post<any>(`${this.url}/Login`, JSON.stringify(model))
      .pipe(
        catchError(res => throwError(res))
      );
  }
}
