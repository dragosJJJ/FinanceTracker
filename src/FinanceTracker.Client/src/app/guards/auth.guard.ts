import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(): boolean {
    const token = this.authService.getToken();

    if (token) {
      console.log('Token JWT găsit:');
    } else {
      console.log('Token JWT nu este salvat.');
    }

    if (this.authService.isAuthenticated()) {
      return true;
    } else {
      console.log('Accesul a fost refuzat. Utilizatorul nu este autentificat.');
      this.router.navigate(['/login']);
      return false;
    }
  }
}
