import { Injectable } from '@angular/core';
import { User } from '../models/user';
import axios from 'axios';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UserApiService {
  constructor() {
    axios.defaults.baseURL = environment.BASE_URL;
  }

  async getUsers() {
    try {
      const response = await axios.get('/api/users');
      return response.data;
    } catch (error) {
      console.error(error);
    }
  }

  async createNewUser(user: User) {
    try {
      console.log(user);
      await axios.post('/api/users', user);
    } catch (error) {
      console.error(error);
    }
  }
}
