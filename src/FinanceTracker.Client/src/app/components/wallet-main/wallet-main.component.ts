import { CommonModule, NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { CardsService } from '../../services/cards.service';
import { CardModel } from '../../models/CardModels';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-wallet-main',
  imports: [NgFor, CommonModule],
  templateUrl: './wallet-main.component.html',
  styleUrl: './wallet-main.component.css',
})
export class WalletMainComponent {
  tokens: CardModel[] = [];
  totalBalance: number = 0;

  constructor(private cardsService: CardsService) {}

  ngOnInit(): void {
    this.cardsService.getCards().subscribe({
      next: (cards) => {
        this.tokens = cards;
        this.totalBalance = this.calculateTotalBalance(cards);
      },
      error: (err) => console.error('Eroare la preluarea cardurilor:', err),
    });
  }

  private calculateTotalBalance(cards: CardModel[]): number {
    return cards.reduce((sum, card) => {
      const numeric = Number(
        card.amount.replace(/[^0-9.-]+/g, '').replace(',', '')
      );
      return sum + (isNaN(numeric) ? 0 : numeric);
    }, 0);
  }

editCard(index: number) {
  const card = this.tokens[index];
  const savedTheme = localStorage.getItem('theme');
  const customClass = savedTheme === 'dark' ? 'swal2-dark' : '';

  Swal.fire({
    title: 'Edit Card',
    html: `
      <input id="swal-input1" class="swal2-input" placeholder="Currency" value="${card.currency}">
      <input id="swal-input2" class="swal2-input" placeholder="Amount" value="${card.amount}">
      <input id="swal-input3" class="swal2-input" placeholder="Holder" value="${card.holder}">
      <input id="swal-input4" type="date" class="swal2-input" value="${card.expiry.split('T')[0]}">
      <input id="swal-input5" class="swal2-input" placeholder="CVV" value="${card.cvv}">

      <select id="swal-input6" class="swal2-input">
        <option value="" disabled ${!card.currencyLogo ? 'selected' : ''}>Select Currency Logo</option>
        <option value="EURO.png" ${card.currencyLogo === 'EURO.png' ? 'selected' : ''}>EUR</option>
        <option value="GBP.png" ${card.currencyLogo === 'GBP.png' ? 'selected' : ''}>GBP</option>
        <option value="USD.png" ${card.currencyLogo === 'USD.png' ? 'selected' : ''}>USD</option>
      </select>

      <select id="swal-input7" class="swal2-input">
        <option value="" disabled ${!card.providerLogo ? 'selected' : ''}>Select Provider Logo</option>
        <option value="visa.png" ${card.providerLogo === 'visa.png' ? 'selected' : ''}>Visa</option>
        <option value="master card.png" ${card.providerLogo === 'master card.png' ? 'selected' : ''}>MasterCard</option>
        <option value="citigroup.png" ${card.providerLogo === 'citigroup.png' ? 'selected' : ''}>CitiGroup</option>
      </select>
    `,
    customClass: {
      popup: customClass,
    },
    showCancelButton: true,
    confirmButtonText: 'Save',
    focusConfirm: false,
    preConfirm: () => {
      const currency = (document.getElementById('swal-input1') as HTMLInputElement).value;
      const amount = (document.getElementById('swal-input2') as HTMLInputElement).value;
      const holder = (document.getElementById('swal-input3') as HTMLInputElement).value;
      const expiry = (document.getElementById('swal-input4') as HTMLInputElement).value;
      const cvv = (document.getElementById('swal-input5') as HTMLInputElement).value;
      const currencyLogo = (document.getElementById('swal-input6') as HTMLSelectElement).value;
      const providerLogo = (document.getElementById('swal-input7') as HTMLSelectElement).value;

      if (!currency || !amount || !holder || !expiry || !cvv || !currencyLogo || !providerLogo) {
        Swal.showValidationMessage('Please fill in all fields');
        return;
      }

      return { currency, amount, holder, expiry, cvv, currencyLogo, providerLogo };
    },
  }).then((result) => {
    if (result.isConfirmed && result.value) {
      const updatedCard: CardModel = {
        ...card,
        ...result.value,
      };

      this.cardsService.updateCard(updatedCard).subscribe({
        next: () => {
          this.tokens[index] = updatedCard;
          this.tokens = this.sortAndPrioritize(this.tokens); // dacă ai o funcție de sortare
          this.calculateTotalBalance(this.tokens);
          Swal.fire('Updated!', 'Your card has been updated.', 'success');
        },
        error: () => {
          Swal.fire('Error', 'Failed to update card.', 'error');
        },
      });
    }
  });
}



  private sortAndPrioritize(cards: CardModel[]): CardModel[] {
    return cards
      .slice()
      .sort((a, b) => parseFloat(b.amount) - parseFloat(a.amount))
      .map((card, index) => ({
        ...card,
        priority: index + 1,
      }));
  }

  deleteCard(index: number) {
    const savedTheme = localStorage.getItem('theme');
    const customClass = savedTheme === 'dark' ? 'swal2-dark' : '';

    const cardId = this.tokens[index].id;

    Swal.fire({
      title: 'Are you sure?',
      text: 'You will not be able to recover this card!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'Cancel',
      customClass: {
        popup: customClass,
      },
    }).then((result) => {
      if (result.isConfirmed) {
        this.cardsService.deleteCardById(cardId).subscribe({
          next: () => {
            this.tokens.splice(index, 1);
            this.calculateTotalBalance(this.tokens);

            Swal.fire({
              title: 'Deleted!',
              text: 'The card has been deleted.',
              icon: 'success',
              customClass: {
                popup: customClass,
              },
            });
          },
          error: () => {
            Swal.fire({
              title: 'Error!',
              text: 'Failed to delete the card.',
              icon: 'error',
              customClass: {
                popup: customClass,
              },
            });
          },
        });
      }
    });
  }

  addCard() {
    const savedTheme = localStorage.getItem('theme');
    const customClass = savedTheme === 'dark' ? 'swal2-dark' : '';

    Swal.fire({
      title: 'Add New Card',
      html: `
      <input id="swal-input1" class="swal2-input" placeholder="Currency">
      <input id="swal-input2" class="swal2-input" placeholder="Amount">
      <input id="swal-input3" class="swal2-input" placeholder="Holder">
      <input id="swal-input4" type="date" class="swal2-input" placeholder="Expiry">
      <input id="swal-input5" class="swal2-input" placeholder="CVV">
      <select id="swal-input6" class="swal2-input">
        <option value="" disabled selected>Select Currency Logo</option>
        <option value="EURO.png">EUR</option>
        <option value="GBP.png">GBP</option>
        <option value="USD.png">USD</option>
      </select>
      <select id="swal-input7" class="swal2-input">
        <option value="" disabled selected>Select Provider Logo</option>
        <option value="visa.png">Visa</option>
        <option value="master card.png">MasterCard</option>
        <option value="citigroup.png">CitiGroup</option>
      </select>
    `,
      customClass: {
        popup: customClass,
      },
      showCancelButton: true,
      confirmButtonText: 'Add',
      preConfirm: () => {
        const currency = (
          document.getElementById('swal-input1') as HTMLInputElement
        ).value;
        const amount = parseFloat(
          (document.getElementById('swal-input2') as HTMLInputElement).value
        );
        const holder = (
          document.getElementById('swal-input3') as HTMLInputElement
        ).value;
        const expiry = (
          document.getElementById('swal-input4') as HTMLInputElement
        ).value;
        const cvv = (document.getElementById('swal-input5') as HTMLInputElement)
          .value;
        const currencyLogo = (
          document.getElementById('swal-input6') as HTMLSelectElement
        ).value;
        const providerLogo = (
          document.getElementById('swal-input7') as HTMLSelectElement
        ).value;

        if (
          !currency ||
          isNaN(amount) ||
          !holder ||
          !expiry ||
          !cvv ||
          !currencyLogo ||
          !providerLogo
        ) {
          Swal.showValidationMessage(
            'Please fill in all required fields correctly.'
          );
          return;
        }

        if (currency.length > 4) {
          Swal.showValidationMessage('Currency must be 4 characters or less');
          return;
        }

        return {
          currency,
          amount,
          holder,
          expiry,
          cvv,
          currencyLogo,
          providerLogo,
        };
      },
    }).then((result) => {
      if (result.isConfirmed && result.value) {
        const newCard = result.value;

        this.cardsService.addCard(newCard).subscribe({
          next: (card) => {
            this.tokens.push(card);
            this.totalBalance = this.calculateTotalBalance(this.tokens);
            Swal.fire('Success', 'Card added successfully!', 'success');
            this.cardsService.getCards().subscribe({
              next: (cards) => {
                this.tokens = cards;
                this.totalBalance = this.calculateTotalBalance(cards);
              },
              error: (err) =>
                console.error('Eroare la preluarea cardurilor:', err),
            });
          },
          error: (err) => {
            console.error(err);
            Swal.fire('Error', 'Failed to add card.', 'error');
          },
        });
      }
    });
  }
}
