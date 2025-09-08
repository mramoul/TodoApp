import { Component, signal, computed } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { TaskCreate } from '../task-create/task-create';
import { FormsModule } from '@angular/forms';
import { environment } from '../../../environments/environment';

interface TaskModel {
  id: string;
  title: string;
  description: string;
  status: string;
  assignedUser?: {
    firstName: string;
    lastName: string;
  };
}

@Component({
  selector: 'app-task-list',
  standalone: true,
  imports: [CommonModule, TaskCreate, FormsModule],
  templateUrl: './task-list.html',
  styleUrls: ['./task-list.scss'],
})
export class TaskList {
  tasks = signal<TaskModel[]>([]);
  showCreateForm = signal(false);

  todoTasks = computed(() => this.tasks().filter(t => t.status === 'toDo'));
  doingTasks = computed(() => this.tasks().filter(t => t.status === 'doing'));
  doneTasks = computed(() => this.tasks().filter(t => t.status === 'done'));

  constructor(private http: HttpClient) {
    this.loadTasks();
  }

  loadTasks() {
    this.http.get<any>(`${environment.apiUrl}/api/task-list`)
      .subscribe({
        next: (data) => this.tasks.set(data.tasksList ?? []),
        error: (err) => console.error('Failed to load tasks', err)
      });
  }

  updateStatus(taskId: string, newStatus: string) {
    const payload = { id: taskId, status: newStatus };

    this.http.patch(`${environment.apiUrl}/api/task-update-status`, payload)
      .subscribe({
        next: () => this.loadTasks(),
        error: err => console.error('Failed to update task status', err)
      });
  }


  toggleCreateForm() {
    this.showCreateForm.update(v => !v);
  }
}