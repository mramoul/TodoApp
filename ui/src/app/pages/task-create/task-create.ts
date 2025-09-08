import { Component, signal, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment.development';

interface UserModel {
  id: string;
  firstName: string;
  lastName: string;
}

@Component({
  selector: 'app-task-create',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './task-create.html',
  styleUrls: ['./task-create.scss']
})
export class TaskCreate {
  @Output() taskCreated = new EventEmitter<void>(); // new event

  private _title = signal('');
  private _description = signal('');
  private _assignedUserId = signal('');

  users = signal<UserModel[]>([]);
  errorMessage = signal('');

  get title() { return this._title(); }
  set title(value: string) { this._title.set(value); }

  get description() { return this._description(); }
  set description(value: string) { this._description.set(value); }

  get assignedUserId() { return this._assignedUserId(); }
  set assignedUserId(value: string) { this._assignedUserId.set(value); }

  constructor(private http: HttpClient) {
    this.loadUsers();
  }

  loadUsers() {
    this.http.get<any>(`${environment.apiUrl}/api/user-list`)
      .subscribe({ next: data => this.users.set(data.usersList) });
  }

  createTask() {
    if (!this.title.trim() || !this.description.trim()) {
      this.errorMessage.set('Title and description are required.');
      return;
    }
    const payload = {
      title: this.title,
      description: this.description,
      assignedUserId: this.assignedUserId || null
    };

    this.http.post(`${environment.apiUrl}/api/task`, payload)
      .subscribe({
        next: () => {
          this._title.set('');
          this._description.set('');
          this._assignedUserId.set('');
          this.errorMessage.set('');

          this.taskCreated.emit();
        },
        error: err => console.error('Failed to create task', err)
      });
  }
}