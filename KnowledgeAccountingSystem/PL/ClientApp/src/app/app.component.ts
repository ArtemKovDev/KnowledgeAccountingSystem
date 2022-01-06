import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from './shared/services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  title = 'app';
  constructor(private _authService: AuthenticationService){}
  ngOnInit(): void {
    if(this._authService.isUserAuthenticated())
      this._authService.sendAuthStateChangeNotification(true);
  }
}
