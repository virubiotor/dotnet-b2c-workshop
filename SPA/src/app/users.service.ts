import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { protectedResources } from './auth-config';

export interface UserAnswers {
  authenticationAnswers: Answer;
  oidcAnswers: Answer;
  aadAnswers: Answer;
  b2cAnswers: Answer;
}

export interface Answer {
    yes: number;
    no: number;
    noAnswer: number
}

@Injectable({
    providedIn: 'root'
})
export class UserService {
    url = protectedResources.apiUsers.endpoint;

    constructor(private http: HttpClient) { }

    getAnswers() {
        return this.http.get<UserAnswers>(this.url);
    }
}
