import {
  ChangeDetectionStrategy,
  Component,
  OnInit,
  signal,
} from '@angular/core';
import { UserApiService } from '../services/user-api.service';
import { CommonModule, NgFor } from '@angular/common';
import { User } from '../models/user';
import { RouterModule } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

interface AppState {
  message: string;
}

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [NgFor, RouterModule, CommonModule],
  templateUrl: './user-list.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UserListComponent implements OnInit {
  readonly users = signal<User[]>([]);

  message$: Observable<string>;

  constructor(
    private readonly userApiService: UserApiService,
    private store: Store<AppState>
  ) {
    this.message$ = this.store.select('message');
  }

  async ngOnInit(): Promise<void> {
    this.users.set(await this.userApiService.getUsers());
  }

  userTrackBy(index: number, user: User) {
    return user._id;
  }

  spanishMessage() {
    this.store.dispatch({ type: 'SPANISH' });
  }

  frenchMessage() {
    this.store.dispatch({ type: 'FRENCH' });
  }
}
