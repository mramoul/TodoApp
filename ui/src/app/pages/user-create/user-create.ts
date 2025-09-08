import { Component, signal, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

interface UserModel {
  id: string;
  firstName: string;
  lastName: string;
}

@Component({
  selector: 'app-user-create',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './user-create.html',
  styleUrls: ['./user-create.scss']
})
export class UserCreate {
  @Output() userCreated = new EventEmitter<void>();

  private _firstName = signal('');
  private _lastName = signal('');
  errorMessage = signal('');

  users = signal<UserModel[]>([]);

  get firstName() { return this._firstName(); }
  set firstName(value: string) { this._firstName.set(value); }

  get lastName() { return this._lastName(); }
  set lastName(value: string) { this._lastName.set(value); }

  constructor(private http: HttpClient) {
    this.loadUsers();
  }

  loadUsers() {
    this.http.get<any>(`${environment.apiUrl}/api/user-list`)
      .subscribe({ next: data => this.users.set(data.usersList) });
  }

  createTask() {
    if (!this.firstName.trim() || !this.lastName.trim()) {
      this.errorMessage.set('First name and last name are required.');
      return;
    }

    const payload = {
      firstName: this.firstName.trim(),
      lastName: this.lastName.trim(),
    };

    this.http.post<UserModel>(`${environment.apiUrl}/api/user`, payload)
      .subscribe({
        next: () => {
          this._firstName.set('');
          this._lastName.set('');
          this.errorMessage.set('');
          this.loadUsers();
          this.userCreated.emit();
        },
        error: err => {
          this.errorMessage.set('Failed to create user.');
          console.error('Failed to create user', err);
        }
      });
  }
}