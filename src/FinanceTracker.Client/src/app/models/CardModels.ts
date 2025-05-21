export interface CardModel {
    id: number;
    priority?: number;
    currency: string;
    amount: string;
    holder: string;
    expiry: string;
    cvv: string;
    currencyLogo: string;
    providerLogo: string;
  }
  