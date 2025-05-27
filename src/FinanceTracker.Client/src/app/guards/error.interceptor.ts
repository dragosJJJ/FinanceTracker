import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        // Adăugați o verificare dacă este o eroare de tip HTTP
        const errorMessage = error.error?.message || error.message || 'Unknown error';

        // Afișați eroarea pe ecran
        this.showErrorOnScreen(errorMessage);

        // Aruncați eroarea pentru a fi gestionată mai departe
        return throwError(() => error);
      })
    );
  }

  // Funcția care adaugă mesajul de eroare pe ecran
  private showErrorOnScreen(message: string): void {
    const div = document.createElement('div');
    div.innerText = `⚠️ ${message}`;
    div.style.position = 'fixed';
    div.style.bottom = '10px';
    div.style.left = '10px';
    div.style.backgroundColor = '#f44336';
    div.style.color = 'white';
    div.style.padding = '10px 15px';
    div.style.borderRadius = '4px';
    div.style.boxShadow = '0 0 5px rgba(0,0,0,0.3)';
    div.style.zIndex = '9999';

    document.body.appendChild(div);

    // Elimină mesajul după 5 secunde
    setTimeout(() => {
      document.body.removeChild(div);
    }, 5000);
  }
}
