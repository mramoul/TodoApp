import { Routes } from '@angular/router';
import { TaskList } from './pages/task-list/task-list';
import { TaskCreate } from './pages/task-create/task-create';
import { HomePage } from './pages/home-page/home-page';
import { UserCreate } from './pages/user-create/user-create';

export const routes: Routes = [
    {
        path: '',
        component: HomePage,
    },
    {
        path: 'tasks',
        component: TaskList,
    },
    {
        path: 'tasks/create',
        component: TaskCreate,
    },
    {
        path: 'users/create',
        component: UserCreate,
    },
];