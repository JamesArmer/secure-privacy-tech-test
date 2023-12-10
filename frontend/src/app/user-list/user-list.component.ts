import {
  ChangeDetectionStrategy,
  Component,
  OnInit,
  signal,
} from '@angular/core';
import { UserApiService } from '../user-api.service';
import { NgFor } from '@angular/common';
import { User } from '../models/user';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [NgFor, RouterModule],
  templateUrl: './user-list.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UserListComponent implements OnInit {
  readonly users = signal<User[]>([]);

  constructor(private readonly userApiService: UserApiService) {}

  async ngOnInit(): Promise<void> {
    this.users.set(await this.userApiService.getUsers());
  }

  userTrackBy(index: number, user: User) {
    return user._id;
  }
}
