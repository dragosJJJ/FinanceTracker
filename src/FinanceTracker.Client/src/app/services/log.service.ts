import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LogService {
  private logContainer: HTMLElement;

  constructor() {
    this.logContainer = document.createElement('div');
    this.logContainer.style.position = 'fixed';
    this.logContainer.style.bottom = '10px';
    this.logContainer.style.right = '10px';
    this.logContainer.style.backgroundColor = '#333';
    this.logContainer.style.color = 'white';
    this.logContainer.style.padding = '10px 20px';
    this.logContainer.style.maxHeight = '200px';
    this.logContainer.style.overflowY = 'scroll';
    this.logContainer.style.zIndex = '9999';
    this.logContainer.style.borderRadius = '5px';
    this.logContainer.style.fontSize = '12px';
    this.logContainer.style.boxShadow = '0 0 10px rgba(0, 0, 0, 0.5)';

    document.body.appendChild(this.logContainer);

    this.overrideConsole();
  }

  private overrideConsole() {
    const originalLog = console.log;
    const originalError = console.error;
    const originalWarn = console.warn;

    console.log = (...args: any[]) => {
      this.displayLog(args, 'log');
      originalLog.apply(console, args);
    };

    console.error = (...args: any[]) => {
      this.displayLog(args, 'error');
      originalError.apply(console, args);
    };

    console.warn = (...args: any[]) => {
      this.displayLog(args, 'warn');
      originalWarn.apply(console, args);
    };
  }

  private displayLog(args: any[], type: 'log' | 'error' | 'warn') {
    const logMessage = args
      .map((arg) => (typeof arg === 'object' ? JSON.stringify(arg) : arg))
      .join(' ');

    const logDiv = document.createElement('div');
    logDiv.style.padding = '5px';
    logDiv.style.marginBottom = '5px';
    logDiv.style.borderRadius = '3px';
    logDiv.style.fontSize = '12px';

    if (type === 'log') {
      logDiv.style.backgroundColor = '#444';
    } else if (type === 'error') {
      logDiv.style.backgroundColor = '#f44336';
    } else if (type === 'warn') {
      logDiv.style.backgroundColor = '#ff9800';
    }

    logDiv.innerText = logMessage;

    this.logContainer.appendChild(logDiv);
    
    setTimeout(() => {
      logDiv.style.opacity = '0';
      setTimeout(() => {
        logDiv.remove();
      }, 300);
    }, 3000);
  }
}
